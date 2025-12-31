function forwardBtnClicked() {
    document.getElementById("forwardPopup").style.display = "flex";
}

let forwardedFileDocument = null;
function handleFileUpload(event) {
    const file = event.target.files[0];
    const fileInfo = document.getElementById("fileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            forwardedFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            forwardedFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", forwardedFileDocument);
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        forwardedFileDocument = null;
    }
}
function closePopup() {
    document.getElementById("forwardPopup").style.display = "none";
}
function submitForward() {
    showLoader();
    const remark = document.getElementById("forwardRemark").value;

    
    if (!remark.trim()) {
        $("#forwardRemarkError").text("Please write forwarding remark.");
        hideLoader();
        return;
    }
    if (!forwardedFileDocument) {
        $("#pdfPickerError").text("Please select a valid PDF file.");
        hideLoader();
        return;
    }
    //if (!forwardedFileDocument) {
    //    alert("Please select a valid PDF file.");
    //    hideLoader();
    //    return;
    //}

    showLoader();
    const data = {
        GrievanceId: $('#hiddenGrievanceId').val(),
        IsForwardedByDO: true,
        DIForwardingComment: remark,
        DIForwardingDate: new Date(),
        DIForwardingDocument: forwardedFileDocument,

        IsAcceptedByZO: false,
        IsRejectedByZO: false,
        IsRevertedByZO: false,
        IsForwardedByZO: false,

        IsAcceptedByHO: false,
        IsRejectedByHO: false,
        IsRevertedByHO: false,
        IsAcceptedByDI: false,
        CreatedOn: new Date(),
        UpdatedOn: new Date()
    };

    console.log("Submitting Forward Request:", data);
    closePopup();
    forwardGrievance(data);
}

function forwardGrievance(data) {
    showLoader();
    const formData = new FormData();

    formData.append("GrievanceId", data.GrievanceId);
    formData.append("IsForwardedByDO", data.IsForwardedByDO);
    formData.append("DIForwardingComment", data.DIForwardingComment);
    formData.append("DIForwardingDocument", new Blob([data.DIForwardingDocument], { type: "application/pdf" }));

    formData.append("IsAcceptedByZO", data.IsAcceptedByZO);
    formData.append("IsRejectedByZO", data.IsRejectedByZO);
    formData.append("IsRevertedByZO", data.IsRevertedByZO);
    formData.append("IsForwardedByZO", data.IsForwardedByZO);

    formData.append("IsAcceptedByHO", data.IsAcceptedByHO);
    formData.append("IsRejectedByHO", data.IsRejectedByHO);
    formData.append("IsRevertedByHO", data.IsRevertedByHO);
    formData.append("IsAcceptedByDI", data.IsAcceptedByDI);
    formData.append("CreatedOn", data.CreatedOn.toISOString());
    formData.append("UpdatedOn", data.UpdatedOn.toISOString());

    $.ajax({
        url: '/Reports/ForwardGrievance',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            if (response.success) {
                // Show success message and reload the window
                alert(response.message);
                window.location.reload();
                hideLoader();
            } else {
                // Show error message
                alert(response.message);
            }
            hideLoader();
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("An error occurred while forwarding the grievance.");
            hideLoader();
        }
    });
}

function reassignBtnClicked() {
    $('#reassignModal').modal('show');
    getSIList();
    GetDistrictUserList();
}

function reassignupdateBtnClicked() {
    const form = document.getElementById('reassignForm');

    if (form.checkValidity()) {
        var GrievanceId = $('#hiddenGrievanceId').val();
        var User = $('#reassignUser').val();
        var SIName = $('#reassignSIName').val();
        var AdminComment = $('#reassignDIComment').val();

        updateReassignmentGrievance(GrievanceId, User, SIName, AdminComment);
    } else {
        form.reportValidity();
    }


}
function updateReassignmentGrievance(GrievanceId, User, SIName, AdminComment) {
    $.ajax({
        url: '/Reports/GrievanceReAssignment', // Ensure this is the correct URL
        dataType: 'html',
        data: { GrievanceId: GrievanceId, AssignedToId: User, SIId: SIName, AdminComment: AdminComment },
        success: function (response) {
            $('#reassignModal').modal('hide');
            alert("Reassigned Successfully...");
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
        }
    });
}


function getSIList() {
    $.ajax({
        url: '/Admin/GetSystemIntegrator',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var SIDropdown = $('#reassignSIName');

            SIDropdown.empty();

            SIDropdown.append($('<option>', {
                value: '',
                text: 'Select SI Name'
            }));
            $.each(data, function (index, item) {
                SIDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching districts:", error);
        }
    });
}

function GetDistrictUserList() {
    $.ajax({
        url: '/Admin/GetDistrictUserList',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var UserDropdown = $('#reassignUser');

            UserDropdown.empty();

            UserDropdown.append($('<option>', {
                value: '',
                text: 'Select User Name'
            }));
            $.each(data, function (index, item) {
                UserDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching districts:", error);
        }
    });
}


function downloadGrievanceCertificatePDF() {
    const image = document.getElementById('certificateimage');
    let base64String = image.src;

    console.log("base64String", base64String);

    // Check if the Base64 string is a PDF
    if (base64String.startsWith("data:application/pdf;base64,") || base64String.startsWith("JVBERi0")) {
        // Remove the prefix if present
        const base64Data = base64String.startsWith("data:application/pdf;base64,")
            ? base64String.replace("data:application/pdf;base64,", "")
            : base64String;
        //console.log(base64String);

        // Convert Base64 string to binary data
        const binaryString = window.atob(base64Data);
        const len = binaryString.length;
        const bytes = new Uint8Array(len);

        for (let i = 0; i < len; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }

        // Create a Blob object
        const blob = new Blob([bytes], { type: "application/pdf" });
        const url = URL.createObjectURL(blob);

        const tempLink = document.createElement('a');
        tempLink.href = url;
        tempLink.download = 'GrievanceFile.pdf';
        document.body.appendChild(tempLink); // Append to the DOM
        tempLink.click(); // Trigger the download
        document.body.removeChild(tempLink); // Remove from the DOM

        // Clean up
        URL.revokeObjectURL(url);
    } else {
        alert("Not a valid Base64 PDF string. Please check");
    }
}

function previewGrievanceCertificatePDF() {
    const image = document.getElementById('certificateimage');
    let base64String = image.src;

    if (base64String.startsWith("data:application/pdf;base64,") || base64String.startsWith("JVBERi0")) {
        const base64Data = base64String.startsWith("data:application/pdf;base64,")
            ? base64String.replace("data:application/pdf;base64,", "")
            : base64String;

        const binaryString = window.atob(base64Data);
        const len = binaryString.length;
        const bytes = new Uint8Array(len);

        for (let i = 0; i < len; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }

        const blob = new Blob([bytes], { type: "application/pdf" });
        const url = URL.createObjectURL(blob);

        window.open(url); // Open the PDF in a new tab

        URL.revokeObjectURL(url); // Clean up
    } else {
        alert("Not a valid Base64 PDF string. Please check");
    }


}
