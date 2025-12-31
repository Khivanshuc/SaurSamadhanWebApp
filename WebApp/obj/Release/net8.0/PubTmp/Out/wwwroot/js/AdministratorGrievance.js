function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}
function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}
function getGrievanceList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus = 0, StartDate = null, EndDate = null, filterStatus = 0) {
    // If StartDate or EndDate is not provided, use the current date
    showLoader();
    if (!StartDate) {
        StartDate = new Date().toISOString().split('T')[0]; // Default: Today’s date (YYYY-MM-DD)
    }
    if (!EndDate) {
        EndDate = new Date().toISOString().split('T')[0]; // Default: Today’s date (YYYY-MM-DD)
    }

    $.ajax({
        url: '/Administrator/GrievancesList',
        dataType: 'html',
        data: {
            DistrictId: District,
            BlockId: Block,
            VillageId: Village,
            SIId: SIId,
            WorkingStatus: WorkingStatus,
            StartDate: StartDate,
            EndDate: EndDate,
            filterStatus: filterStatus
        },
        success: function (response) {
            $('#grievanceListPartialView').html(response);

            // Re-initialize DataTable after partial view loads
            $('#grievanceTable').DataTable({
                "pageLength": 10,
                "lengthMenu": [5, 10, 25, 50, 100],
                "ordering": true,
                "searching": true,
                "info": true,
                "autoWidth": false
            });

            hideLoader();
        },
        error: function (xhr, status, error) {
            console.error("Error fetching grievances:", error);
        }
    });
}
function revertModalCloseBtnClicked() {
    $('#revertModal').modal('hide');
}
function revertBtnClicked(grievanceId) {
    $('#hiddenGrievenceId').val(grievanceId);
    $('#revertModal').modal('show');
}
function revertSubmitBtnClicked1() {
    var grievanceId = $('#hiddenGrievenceId').val();
    var grievanceStatus = $('#revertStatus').val();
    var grievanceComment = $('#grievanceRevertReason').val();
    $.ajax({
        url: '/Administrator/StepBackComplaint',
        type: 'GET',
        data: { GrievanceId: grievanceId, GrievanceStatus: grievanceStatus, RevertionComment: grievanceComment },
        success: function (response) {
            hideLoader();
            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error:", error);
            alert("An error occurred while accepting the grievance.");
        }
    });
    $('#revertModal').modal('hide');
}
function revertSubmitBtnClicked() {
    let form = document.getElementById("revertForm");

    // Check if the form is valid
    if (!form.checkValidity()) {
        form.reportValidity(); // Show default validation messages
        return;
    }

    var grievanceId = $('#hiddenGrievenceId').val();
    var grievanceStatus = $('#revertStatus').val().trim();
    var grievanceComment = $('#grievanceRevertReason').val().trim();

    // Show loader if applicable
    showLoader();

    $.ajax({
        url: '/Administrator/StepBackComplaint',
        type: 'GET',
        data: { GrievanceId: grievanceId, GrievanceStatus: grievanceStatus, RevertionComment: grievanceComment },
        success: function (response) {
            hideLoader();
            if (response.success) {
                alert(response.message); // Show success message
                location.reload(); // Reload the page if needed
            } else {
                alert(response.message); // Show error message
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error:", error);
            alert("An error occurred while processing the grievance.");
        }
    });

    $('#revertModal').modal('hide');
}


function deleteBtnClicked(GrievanceId) {
    $("#deleteGrievanceId").val(GrievanceId);
    $("#remarkModal").modal('show');
}


function confirmDeleteClicked() {
    const remark = $("#remark").val().trim();
    const grievanceId = $("#deleteGrievanceId").val();

    if (remark === "") {
        $("#remark").focus();
        return;
    }

    $.ajax({
        url: "/Administrator/DeleteGrievance",
        type: "Post",
        data: {
            GrievanceId: grievanceId,
            Remark:remark
        },
        success: function (response) {
            if (response.success) {
                alert("Deleted Id: " + response.id + "\nMessage: " + response.message);
                $("#remarkModal").modal('hide');
                getGrievanceList();
            } else {
                alert("Delete failed: " + (response.message || "Unknown error"));
            }
        },
        error: function () {
            alert("An error occurred while deleting the grievance.");
        }
    });
}


function deleteSubmitBtnClicked() {

}

function uploadModalCloseBtnClicked() {
    $('#uploadModal').modal('hide');
}
function uploadBtnClicked(grievanceId) {
    $('#hiddenGrievenceId').val(grievanceId);
    $('#uploadModal').modal('show');
}
function toggleFields() {
    var status = document.getElementById("uploadStatus").value;
    document.getElementById("inProgressFields").style.display = (status === "InProgress") ? "block" : "none";
    document.getElementById("verifiedFields").style.display = (status === "Verified") ? "block" : "none";
}

async function uploadSubmitBtnClicked() {
    var grievanceId = $('#hiddenGrievenceId').val();
    var GrievanceStatus = document.getElementById("uploadStatus").value;

    if (!GrievanceStatus) {
        alert("Please select a upload type.");
        return;
    }

    var requestData = {
        GrievanceId: grievanceId,
        Id: grievanceId,
        GrievanceStatus: GrievanceStatus
    };

    var imageInput, pdfInput, dateTime, geoTag, verificationComment;
    var errorMessage = "";

    if (GrievanceStatus === "InProgress") {
        imageInput = document.getElementById("uploadImageInProgress").files[0];
        dateTime = document.getElementById("dateTimeInProgress").value;
        geoTag = document.getElementById("latitudeLongitudeInProgress").value;

        if (!imageInput) errorMessage += "Please upload an image.\n";
        if (!dateTime) errorMessage += "Please select Date & Time.\n";
        if (!geoTag.trim()) errorMessage += "Please enter Latitude, Longitude.\n";

        if (errorMessage) {
            alert(errorMessage);
            return;
        }

        requestData.ImageBase64 = await convertToBase64(imageInput);
        requestData.DateTime = dateTime;
        requestData.GeoTag = geoTag;
    }
    else if (GrievanceStatus === "Verified") {
        imageInput = document.getElementById("uploadImageVerified").files[0];
        pdfInput = document.getElementById("uploadPdfVerified").files[0];
        dateTime = document.getElementById("verifiedDateTime").value;
        verificationComment = document.getElementById("verificationComment").value;
        geoTag = document.getElementById("latitudeLongitudeVerified").value;

        if (!imageInput) errorMessage += "Please upload an image.\n";
        if (!pdfInput) errorMessage += "Please upload a PDF.\n";
        if (!dateTime) errorMessage += "Please select Date & Time.\n";
        if (!verificationComment.trim()) errorMessage += "Please enter a Verification Comment.\n";
        if (!geoTag.trim()) errorMessage += "Please enter Latitude, Longitude.\n";

        if (errorMessage) {
            alert(errorMessage);
            return;
        }

        requestData.ImageBase64 = await convertToBase64(imageInput);
        requestData.DocumentBase64 = await convertToBase64(pdfInput);
        requestData.DateTime = dateTime;
        requestData.VerificationComment = verificationComment;
        requestData.GeoTag = geoTag;
    }

    // Print requestData JSON
    console.log("Request Data:", JSON.stringify(requestData, null, 2));

    // Send JSON Data
    sendData(requestData);
}

// Function to convert file to Base64
function convertToBase64(file) {
    return new Promise((resolve, reject) => {
        if (!file) {
            resolve(null);
            return;
        }

        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {
            resolve(reader.result.split(',')[1]); // Remove "data:image/png;base64," prefix
        };
        reader.onerror = error => reject(error);
    });
}

// Function to send AJAX request as JSON
function sendData(requestData) {
    $.ajax({
        url: "/Administrator/UploadImageDocument",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(requestData),
        success: function (response) {
            alert("Data uploaded successfully!");
            location.reload();
        },
        error: function (xhr, status, error) {
            alert("Error: " + xhr.responseText);
        }
    });
}