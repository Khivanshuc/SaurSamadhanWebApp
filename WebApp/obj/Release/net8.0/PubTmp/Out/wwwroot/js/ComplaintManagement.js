
// Clear error messages when typing in the field
$("input, select").on("input change", function () {
    $(this).next(".error").text("");
});

function validateForm() {
    $(".error").text("");

    let isValid = true;
    // Define validation rules as an array of objects
    const fields = [
        { id: "txtappname", errorId: "appnameError", message: "आवेदक का नाम आवश्यक है।" },
        { id: "txtdate", errorId: "DateError", message: "कृपया तारीख का चयन करें।" },
        { id: "txtjila", errorId: "distNameError", message: "कृपया जिला का चयन करें।" },
        { id: "txtvikaskhand", errorId: "blockNameError", message: "कृपया विकासखंड का चयन करें।" },
        { id: "txtVillage", errorId: "villageNameError", message: "कृपया गांव का चयन करें।" },
        { id: "txtSite", errorId: "siteNameError", message: "कृपया साइट का चयन करें।" },
        { id: "txtComplaintRemark", errorId: "complaintRemarkError", message: "शिकायत का विषय आवश्यक है।" }

    ];

    // Loop through the fields and validate each one
    fields.forEach(field => {
        let value = $("#" + field.id).val();
        if (value === "" || (field.checkValue && value === field.checkValue)) {
            $("#" + field.errorId).text(field.message);
            isValid = false;
        } else if (field.regex && !field.regex.test(value)) {
            $("#" + field.errorId).text(field.regexMessage || field.message);
            isValid = false;
        } else {
            $("#" + field.errorId).text("");  // Clear error if valid
        }
    });
    if (isValid) {
        return true;
    }
}

function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}

function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}

function getSIName() {
    showLoader();
    $.ajax({
        url: '/Admin/GetSystemIntegrator',
        type: 'GET',
        success: function (data) {
            var siDropdown = $('#txtSIname');
            siDropdown.empty();

            siDropdown.append($('<option>', {
                value: '',
                text: 'Please Select SI'
            }));

            siDropdown.append($('<option>', {
                value: 'NotAssigned',
                text: 'Not Assigned'
            }));

            $.each(data, function (index, item) {
                siDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            getBlockByDistrict();
            hideLoader();
        }
    });
}

function getSI() {
    showLoader();
    $.ajax({
        url: '/Admin/GetSystemIntegrator',
        type: 'GET',
        success: function (data) {
            var siDropdown = $('#SystemIntegrator');
            siDropdown.empty();

            siDropdown.append('<option value="0" selected>Please Select SI</option>');

            $.each(data, function (index, item) {
                siDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            hideLoader();
        }
    });
}

function getDistrict() {
    showLoader();
    $.ajax({
        url: '/Admin/GetDistrictsFromAdminPanel',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#txtjila');
            districtDropdown.empty();
            districtDropdown.append($('<option>', {
                value: '',
                text: 'जिला'
            }));

            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            getBlockByDistrict();
            hideLoader();
        }
    });
}

function getDist() {
    showLoader();
    $.ajax({
        url: '/Admin/GetDistrictsForAdminPanel',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#District');
            districtDropdown.empty();

            districtDropdown.append('<option value="0" selected>Please Select District</option>');

            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });

            districtDropdown.val("0"); // reset

            hideLoader();
        }
    });
}

function getStatus() {
    let siDropDown = $("#statusFilter");

    console.log(siDropDown);
    siDropDown.empty();

    siDropDown.append('<option value="0" selected>Select Forwarding Status</option>');

    let statuses = [
        { value: "1", text: "Forwarded to Head Office" },
        { value: "2", text: "Accepted By Head Office" },
        { value: "3", text: "Rejected By Head Office" },
        { value: "4", text: "Reverted By Head Office" },
        { value: "5", text: "Forwarded To Zonal Office" },
        { value: "6", text: "Accepted By Zonal Office" },
        { value: "7", text: "Reverted By Zonal Office" },
        { value: "8", text: "Rejected By Zonal Office" },
        { value: "9", text: "Forwarded By Zonal Office" },
        { value: "10", text: "Closed" }
    ];

    $.each(statuses, function (i, status) {
        siDropDown.append($("<option>", {
            value: status.value,
            text: status.text
        }));
    });

    // Auto-select "Select Forwarding Status"
    siDropDown.val("0");

}

function getBlockByDistrict() {
    showLoader();
    var districtId = $('#txtjila').val();
    $.ajax({
        url: '/Admin/GetBlockByDistricts',
        type: 'GET',
        data: { districtId: districtId },
        success: function (data) {
            var blockDropdown = $('#txtvikaskhand');
            blockDropdown.empty();
            const allOption = $('<option>', {
                value: 0, // You can set this to a specific value if needed
                text: 'विकासखंड'
            });

            // Append the "All" option to the dropdown
            blockDropdown.append(allOption);
            $.each(data, function (index, item) {
                blockDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            //searchComplaintList();
            hideLoader();
        }
    });
}
function blockOptionClicked() {
    getVillageByBlock();
}
function getVillageByBlock() {
    showLoader();
    var blockId = $('#txtvikaskhand').val();
    $.ajax({
        url: '/Admin/GetVillageByBlocks',
        type: 'GET',
        data: { blockId: blockId },
        success: function (data) {
            var villageDropdown = $('#txtVillage');

            villageDropdown.empty();
            const allOption = $('<option>', {
                value: 0,
                text: 'ग्राम'
            });

            villageDropdown.append(allOption);
            $.each(data, function (index, item) {
                villageDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            //searchComplaintList()
            hideLoader();
        }
    });
}
function villageOptionClicked() {
    getSiteByVillage();
}
function getSiteByVillage() {
    showLoader();
    var VillageId = $('#txtVillage').val();
    $.ajax({
        url: '/Admin/GetSitesByVillageId',
        type: 'GET',
        data: { VillageId: VillageId },
        success: function (data) {
            var siteDropdown = $('#txtSite');
            siteDropdown.empty();
            const allOption = $('<option>', {
                value: 0,
                text: 'साइट'
            });

            siteDropdown.append(allOption);
            $.each(data, function (index, item) {
                siteDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            hideLoader();
        }
    });
}
function workingStatusClicked() {
    searchComplaintList();
}
function registerPublicGrievanceComplaintBtnClicked() {
    var registrationData = getPublicGrievanceRegistrationData();
    console.log("Your Data", registrationData);

    registerComplaint(registrationData);
}
function convertFilesToByteArray(file, callback) {
    var reader = new FileReader();
    reader.onload = function (event) {
        var byteArray = new Uint8Array(event.target.result);
        callback(byteArray);
    };
    reader.readAsArrayBuffer(file);
}
function getPublicGrievanceRegistrationData() {
    var districtId = document.getElementById("hiddenDistrictId").value;
    var grievanceId = document.getElementById("hiddenGrievanceId").value;
    var blockId = document.getElementById("hiddenBlockId").value;
    var villageId = document.getElementById("hiddenVillageId").value;
    var siteId = document.getElementById("hiddenSiteId").value;
    var area = document.getElementById("txtappname").value;
    var complaintDate = document.getElementById("txtdate").value;
    var complaintRemark = document.getElementById("txtComplaintRemark").value;
    var complaintStatus = document.getElementById("txtComplaintStatus").value;
    var complainCame = document.getElementById("complainCame").value;
    var actionTaken = document.querySelector('input[name="actionTaken"]:checked').value;
    var letterDate = document.getElementById("letterDate").value;
    var letterNumber = document.getElementById("letterNumber").value;
    var fileUpload = document.getElementById("fileUpload").files[0];  // File input
    var otherFileUpload = document.getElementById("OtherfileUpload").files[0];  // File input

    var fileUploadByte;
    var otherFileUploadByte;



    if (fileUpload) {
        convertFilesToByteArray(fileUpload, function (byteArray) {
            fileUploadByte = byteArray;
            console.log("FileUpload byte array:", fileUploadByte);

        });
    }

    if (otherFileUpload) {
        convertFilesToByteArray(otherFileUpload, function (byteArray) {
            otherFileUploadByte = byteArray
            console.log("OtherFileUpload byte array:", otherFileUploadByte);

        });
    }


    var registrationData = {
        ComplaintNumber: "",
        UserId: 0,
        PublicGrievanceId: grievanceId,
        DistrictId: districtId,
        BlockId: blockId,
        VillageId: villageId,
        SiteId: siteId,
        BeneficiaryName: area,
        ComplaintReceiveMedium: complainCame,
        ComplaintStatus: complaintStatus,
        ComplaintDate: complaintDate,
        ComplaintRemark: complaintRemark,
        ActionTakenByDistrict: actionTaken,
        LetterDate: letterDate,
        LetterNumber: letterNumber,
        UploadLetter: fileUploadByte,
        OtherAttachment: otherFileUploadByte,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    };

    return registrationData;
}
function getComplaintRegistrationData() {

    //var applicantName = document.getElementById("txtappname").value;
    //var complaintDate = document.getElementById("txtdate").value;
    //var district = document.getElementById("txtjila").value;
    //var block = document.getElementById("txtvikaskhand").value;
    //var village = document.getElementById("txtVillage").value;
    //var site = document.getElementById("txtSite").value;
    //var complaintRemark = document.getElementById("txtComplaintRemark").value;
    //var complaintStatus = document.getElementById("txtComplaintStatus").value;


    var districtId = document.getElementById("txtjila").value;
    var grievanceId = 0;
    var blockId = document.getElementById("txtvikaskhand").value;
    var villageId = document.getElementById("txtVillage").value;
    var siteId = document.getElementById("txtSite").value;
    var applicantName = document.getElementById("txtappname").value;
    var complaintDate = document.getElementById("txtdate").value;
    var complaintRemark = document.getElementById("txtComplaintRemark").value;
    var complaintStatus = document.getElementById("txtComplaintStatus").value;
    var complainCame = document.getElementById("complainCame").value;
    var actionTaken = document.querySelector('input[name="actionTaken"]:checked').value;
    var letterDate = document.getElementById("letterDate").value;
    var letterNumber = document.getElementById("letterNumber").value;
    var fileUpload = document.getElementById("cmpFileUpload").files[0];  // File input
    var otherFileUpload = document.getElementById("cmpOtherAttach").files[0];  // File input

    //var registrationData = {
    //    ComplaintNumber: "",
    //    UserId: 0,
    //    DistrictId: districtId,
    //    BlockId: block,
    //    VillageId: village,
    //    SiteId: site,
    //    ComplaintStatus: complaintStatus,
    //    ComplaintDate: complaintDate,
    //    ComplaintRemark: complaintRemark,
    //    CreatedBy: "Admin",
    //    CreatedOn: new Date().toISOString(),
    //    UpdatedBy: "Admin",
    //    UpdatedOn: new Date().toISOString()
    //};


    var fileUploadByte;
    var otherFileUploadByte;



    if (fileUpload) {
        convertFilesToByteArray(fileUpload, function (byteArray) {
            fileUploadByte = byteArray;
            console.log("FileUpload byte array:", fileUploadByte);

        });
    }

    if (otherFileUpload) {
        convertFilesToByteArray(otherFileUpload, function (byteArray) {
            otherFileUploadByte = byteArray
            console.log("OtherFileUpload byte array:", otherFileUploadByte);

        });
    }

    var registrationData = {
        ComplaintNumber: "",
        UserId: 0,
        PublicGrievanceId: grievanceId,
        DistrictId: districtId,
        BlockId: blockId,
        VillageId: villageId,
        SiteId: siteId,
        BeneficiaryName: applicantName,
        ComplaintReceiveMedium: complainCame,
        ComplaintStatus: complaintStatus,
        ComplaintDate: complaintDate,
        ComplaintRemark: complaintRemark,
        ActionTakenByDistrict: actionTaken,
        LetterDate: letterDate,
        LetterNumber: letterNumber,
        UploadLetter: fileUploadByte,
        OtherAttachment: otherFileUploadByte,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    };

    return registrationData;

}

function registerComplaintBtnClicked() {
    event.preventDefault();
    if (validateForm()) {
        var registrationData = getComplaintRegistrationData();

        registerComplaint(registrationData);
    }
    //window.location.href = 'ComplaintList';
}

function registerComplaint(registrationData) {
    event.preventDefault();
    $.ajax({
        url: '/ComplaintManagement/SaveComplaint', // Ensure this matches your routing setup
        type: 'POST',
        data: registrationData,
        dataType: 'json',
        success: function (response) {
            console.log("Registration successful:", response);
            saveAuditData(response.insertedId);
            saveComplaintStatusData(response.insertedId);
            window.location.href = 'ComplaintList';
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("Failed to save data.");
        }
    });
}

function saveAuditData(complaintId) {
    var auditData = {
        ComplaintId: complaintId,
        ComplaintNumber: '',
        OfficeLevel: 0,
        IsAccepted: 0,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    }
    $.ajax({
        url: '/ComplaintManagement/SaveComplaintAudit',
        type: 'POST',
        data: auditData,
        dataType: 'json',
        success: function (response) {
            console.log("Registration successful:", response);
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("Failed to save data.");
        }
    });
}

function saveComplaintStatusData(complaintId) {
    var statusData = {
        ComplaintId: complaintId,
        ComplaintNumber: "",
        IsApprovedByDO: 0,
        IsApprovedByZO: 0,
        IsApprovedByHO: 0,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    }
    $.ajax({
        url: '/ComplaintManagement/SaveComplaintStatus', // Ensure this matches your routing setup
        type: 'POST',
        data: statusData,
        dataType: 'json',
        success: function (response) {
            console.log("successful: ", response);
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("Failed to save data.");
        }
    });
}

function getComplaintList(District = 0, Block = 0, WorkingStatus = 0, SIId = 0) {
    showLoader();

    $.ajax({
        url: '/ComplaintManagement/_ComplaintList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#ComplaintListPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}
function SIOptionClicked() {
    searchComplaintList();
    clearDistrictList();
    clearBlockList();
}

function searchComplaintList() {
    var District = $('#txtjila').val();
    var Block = $('#txtvikaskhand').val();
    var WorkingStatus = $('#WorkingStatus').val();
    var SIId = $('#txtSIname').val();

    getComplaintList(District, Block, WorkingStatus, SIId);
}

function viewComplaintDetail(ComplaintId) {
    event.preventDefault();
    showLoader();

    $.ajax({
        url: '/ComplaintManagement/_ViewComplaintDetail',
        dataType: 'html',
        data: { ComplaintId: ComplaintId },

        success: function (response) {
            $('#ComplaintListPartialView').html('');
            $('#FaultFiltersView').html('');
            $('#ComplaintDetailPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function editComplaintDetail() {
    event.preventDefault();
    showLoader();

    $.ajax({
        url: '/ComplaintManagement/_EditComplaintDetail',
        dataType: 'html',

        success: function (response) {
            $('#ComplaintListPartialView').html('');
            $('#FaultFiltersView').html('');
            $('#ComplaintListPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}
function actionComplaintDetail(ComplaintId) {
    event.preventDefault();
    showLoader();

    $.ajax({
        url: '/ComplaintManagement/_ActionComplaintDetail',
        dataType: 'html',
        data: { ComplaintId: ComplaintId },

        success: function (response) {
            console.log(response);
            $('#ComplaintListPartialView').html('');
            $('#FaultFiltersView').html('');
            $('#ComplaintListPartialView').html(response);
            //actionDetailLoad();
            hideLoader();
        },
        error: function (xhr, status, error) {

        }
    });
}

function assignComplaintToSIBtnClicked() {
    var ComplaintId = document.getElementById("txtComplaintId").value;
    var ComplaintNumber = document.getElementById("txtComplaintNumber").value;
    var SystemIntegratorId = document.getElementById("txtSIname").value;
    var AssignedDatetoSI = document.getElementById("txtAssignedDate").value;
    var DistrictId = document.getElementById("txtjila").value;
    var BlockId = document.getElementById("txtBlock").value;
    var VillageId = document.getElementById("txtVillage").value;
    var SiteId = document.getElementById("txtSite").value;
    var Remark = document.getElementById("txtRemark").value;
    var ExpectedTimeLimit = document.getElementById("txtLimitedDay").value;

    var data = {
        ComplaintId: ComplaintId,
        ComplaintNumber: ComplaintNumber,
        SystemIntegratorId: SystemIntegratorId,
        AssignedDatetoSI: AssignedDatetoSI,
        DistrictId: DistrictId,
        BlockId: BlockId,
        VillageId: VillageId,
        SiteId: SiteId,
        Remark: Remark,
        ExpectedTimeLimit: ExpectedTimeLimit,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    }
    saveComplaintActionData(data);
}

function saveComplaintActionData(data) {
    event.preventDefault();
    showLoader();

    $.ajax({
        url: '/ComplaintManagement/SaveComplaintAction',
        dataType: 'html',
        data: data,

        success: function (response) {
            console.log(response);
            pageReload();
            getComplaintList();
            hideLoader();
        },
        error: function (xhr, status, error) {

        }
    });
}

function remindComplaintBtnClicked() {
    var ComplaintId = document.getElementById("txtComplaintId").value;
    var ComplaintNumber = document.getElementById("txtComplaintNumber").value;
    var SystemIntegratorId = document.getElementById("txtSIname").value;
    var AssignedDatetoSI = document.getElementById("txtAssignedDate").value;
    var DistrictId = document.getElementById("txtjila").value;
    var BlockId = document.getElementById("txtBlock").value;
    var VillageId = document.getElementById("txtVillage").value;
    var SiteId = document.getElementById("txtSite").value;
    var Remark = document.getElementById("txtRemark").value;
    var ExpectedTimeLimit = document.getElementById("txtLimitedDay").value;

    var data = {
        ComplaintId: ComplaintId,
        ComplaintNumber: ComplaintNumber,
        SystemIntegratorId: SystemIntegratorId,
        AssignedDatetoSI: new Date().toISOString(),
        DistrictId: DistrictId,
        BlockId: BlockId,
        VillageId: VillageId,
        SiteId: SiteId,
        Remark: Remark,
        ExpectedTimeLimit: ExpectedTimeLimit,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    }
    //saveComplaintActionData(data);
}
function actionDetailLoad() {
    getSIName();
}

function BacktoList() {
    window.location.href = 'ComplaintList';
}

function BackToDashboard() {
    window.location.href = '/Dashboards/LandingPage';
}

function BacktoHome() {
    window.location.href = 'Index';
}

function pageReload() {
    location.reload();
}

function escalateComplaintBtnClicked() {

    getEscalatedComplaintDetailforSave();
    //Save data in the escalation table

    //save data in the audit table
    var complaintId = document.getElementById("txtComplaintId").value;
    //saveAuditData(complaintId)
}

function getEscalatedComplaintDetailforSave() {

    var ComplaintId = document.getElementById("txtComplaintId").value;
    var ComplaintNumber = document.getElementById("txtComplaintNumber").value;

    var escalationData = {
        EscalatedBy: 0,
        EscalatedTo: 0,
        ComplaintId: ComplaintId,
        ComplaintNumber: ComplaintNumber,
        //EscalatedByRemark: "",
        IsAccepted: false,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    }

    saveEscalationData(escalationData)
}

function saveEscalationData(escalationData) {
    $.ajax({
        url: '/ComplaintManagement/SaveEscalationComplaint',
        dataType: 'html',
        data: escalationData,

        success: function (response) {
            console.log(response);
            pageReload();
            getComplaintList();
            hideLoader();
        },
        error: function (xhr, status, error) {

        }
    });
}

function toggleActionFields(radio) {
    var actionFields = document.getElementById('actionFields');
    if (radio.value === 'yes') {
        actionFields.style.display = 'flex';
    } else {
        actionFields.style.display = 'none';
        document.getElementById('actionDate').value = '';
        document.getElementById('actionNumber').value = '';
        document.getElementById('sentId').value = '';
    }
}

//document.getElementById('fileUpload').addEventListener('change', function () {
//    var allowedExtensions = /(\.pdf|\.doc|\.docx)$/i;
//    var filePath = this.value;
//    var fileError = document.getElementById('fileError');
//    var deleteIcon = document.getElementById('deleteIcon');

//    if (!allowedExtensions.exec(filePath)) {
//        fileError.textContent = 'Please upload file having extensions .pdf/.doc/.docx only.';
//        this.value = '';
//        deleteIcon.style.display = 'none';
//        return false;
//    } else {
//        fileError.textContent = '';
//        deleteIcon.style.display = 'inline';
//    }
//});

//document.getElementById('deleteIcon').addEventListener('click', function () {
//    var fileInput = document.getElementById('fileUpload');
//    fileInput.value = '';
//    this.style.display = 'none';
//    document.getElementById('fileError').textContent = '';
//});
document.addEventListener("DOMContentLoaded", function () {
    const tabs = document.querySelectorAll('.tab');
    const contents = document.querySelectorAll('.tab-content');

    tabs.forEach(tab => {
        tab.addEventListener('click', function () {
            // Remove 'active' class from all tabs and content
            tabs.forEach(t => t.classList.remove('active'));
            contents.forEach(c => c.classList.remove('active'));

            // Add 'active' class to the clicked tab and the corresponding content
            tab.classList.add('active');
            document.getElementById(tab.dataset.target).classList.add('active');
        });
    });
});

function showContainer(radio) {
    var notificationContainer = document.getElementById('notificationContainer');
    if (radio.value === 'yes') {
        notificationContainer.style.display = 'block';
    } else {
        notificationContainer.style.display = 'none';
        document.getElementById('notificationTab').value = '';
    }

    getComplaintRegistrationNotification();
}

function confirmForward(event) {
    event.preventDefault();
    if (confirm("Are you sure you want to forward this complaint?")) {
        closeForwardModal();

        document.getElementById('successModal').style.display = 'flex';
    }
}
function closeForwardModal() {
    document.getElementById('forwardModal').style.display = 'none';
}

function closeSuccessModal() {
    document.getElementById('successModal').style.display = 'none';
}

function toggleDropdown(element) {
    event.preventDefault();
    document.querySelectorAll('.dropdown').forEach(function (dropdown) {
        console.log("aa");
        dropdown.classList.remove('show');
    });

    var dropdown = element.nextElementSibling;
    dropdown.classList.toggle('show');
}


function showReturnModal() {
    document.getElementById('returnModal').style.display = 'block';
}
function closeReturnModal() {
    document.getElementById('returnModal').style.display = 'none';
}
function confirmReturn(event) {
    event.preventDefault();
    if (confirm("Are you sure you want to return this complaint?")) {
        closeReturnModal();

        document.getElementById('successModal2').style.display = 'flex';
    }
}
function closeSuccessModal2() {
    document.getElementById('successModal2').style.display = 'none';
}

function showForwardModal() {
    document.getElementById('forwardModal').style.display = 'block';
}

window.onclick = function (event) {
    //if (!event.target.matches('.dot-menu')) {
    //    document.queryselectorall('.dropdown').foreach(function (dropdown) {
    //        dropdown.classlist.remove('show');
    //    });
    //}

    // close modal if clicked outside
    //var modal = document.getelementbyid('returnmodal');
    //if (event.target === modal) {
    //    modal.style.display = 'none';
    //}
};

function districtOptionClick() {
    getBlockByDistrict(this);
    clearSystemIntegratorList();
}
function clearButtonClicked() {
    clearDistrictList();
    clearBlockList();
    clearStatusList();
    clearSystemIntegratorList();
}
function clearDistrictList() {
    $('#txtjila').empty();
    $('#txtjila').append($('<option>', {
        value: '',
        text: 'Select District'
    }));
    getDistrict();
}
function clearBlockList() {
    $('#txtvikaskhand').empty();
    $('#txtvikaskhand').append($('<option>', {
        value: '',
        text: 'Select Block'
    }));
}
function clearStatusList() {
    $('#WorkingStatus').empty();
    $('#WorkingStatus').append($('<option>', {
        value: '',
        text: 'Select Status'
    }));
}
function clearSystemIntegratorList() {
    $('#txtSIname').empty();
    $('#txtSIname').append($('<option>', {
        value: '',
        text: 'Select System Integrator'
    }));
    getSIName();
}

function RegisterComplaintNotificationClicked() {
    getComplaintRegistrationNotification();
}
function GrievanceNotificationClicked() {
    getGrievanceNotification();
}

function getComplaintRegistrationNotification() {
    $.ajax({
        url: '/ComplaintManagement/GetTodayRegisterdComplntNotification',
        type: 'GET',
        success: function (data) {

            // Select the complaint container where notifications will be displayed
            const complaintContainer = $('#complaint-container');
            complaintContainer.empty(); // Clear any existing notifications

            // Loop through each item in the data array
            data.forEach(function (item, index) {
                const complaintHtml = `
                <div id="complaint-content" class="complaint-content">
                    <a style="text-decoration: none;">
                        <div class="notification">
                            <div class="icon-circle">
                                <div class="icon">${index + 1}.</div>
                            </div>
                            <div>
                                <h6 class="header">${item.districtName} - ${item.blockName}</h6>
                                <p>${item.complaintRemark}</p>
                            </div>
                        </div>
                    </a>
                </div>    
                `;
                // Append the generated HTML to the complaint container
                complaintContainer.append(complaintHtml);
            });
        },
        error: function (error) {
            console.error('Error fetching complaint notifications:', error);
        }
    });
}
function getGrievanceNotification() {
    $.ajax({
        url: '/ComplaintManagement/GetTodayRegisterdGrievanceNotification',
        type: 'GET',
        success: function (data) {

            // Select the grievance container where notifications will appear
            const grievanceContainer = $('#grievance-container');
            grievanceContainer.empty(); // Clear any previous notifications

            // Check if data array is empty
            if (data.length === 0) {
                const grievanceHtml = `
                <div id="grievance-content" class="grievance-content">
                    <a style="text-decoration: none;">
                        <div class="notification">
                            <div>
                                <p>No Grievances assigned yet</p>
                            </div>
                        </div>
                    </a>
                </div>
                `;
                grievanceContainer.append(grievanceHtml);
                return;
            }

            // Loop through each item in the data array
            data.forEach(function (item, index) {
                const grievanceHtml = `
                <div id="grievance-content" class="grievance-content">
                    <a style="text-decoration: none;">
                        <div class="notification" onclick="getPublicGrievanceData(${item.id})">
                            <div class="icon-circle">
                                <div class="icon">${index + 1}.</div>
                            </div>
                            <div>
                                <h6 class="header">${item.districtName} - ${item.blockName}</h6>
                                <p>${item.complaintRemark}</p>
                            </div>
                        </div>
                    </a>
                </div>
                `;
                // Append the grievance HTML to the container
                grievanceContainer.append(grievanceHtml);
            });
        },
        error: function (error) {
            console.error('Error fetching grievance notifications:', error);
        }
    });
}
function forwardHOClick() {
    window.location.href = "ForwardHOLandingPage";
}

function getPublicGrievanceData(GrievanceId) {
    showLoader();
    $.ajax({
        url: '/ComplaintManagement/GetPublicGrievanceDataById',
        type: 'GET',
        data: { GrievanceId: GrievanceId },
        success: function (data) {

            hideLoader();
        },
        error: function (error) {
            console.error('Error fetching grievance notifications:', error);
        }
    });
}

function forwardedListBtnClicked() {
    getForwardedComplaintList();
}

function getForwardedComplaintList() {
    showLoader();

    let siId = $("#SystemIntegrator").val();
    let distId = $("#District").val();
    let statusId = $("#statusFilter").val();

    $.ajax({
        url: '/ComplaintManagement/ForwardedComplaintList',
        type: 'GET',
        data: {
            siId: siId,
            distId: distId,
            forwardStatus: statusId
        },
        success: function (data) {
            $("#forwardedComplaintListPartialView").html('');
            $("#forwardedComplaintDetailPartialView").html('');
            $("#forwardedComplaintListPartialView").html(data);
            hideLoader();
        },
        error: function (error) {
            console.error('Error fetching grievance notifications:', error);
        }
    });
}

function getForwardedGrievanceDetail(GrievanceId) {
    showLoader();
    $.ajax({
        url: '/ComplaintManagement/ForwardedComplaintDetail',
        type: 'GET',
        data: { GrievanceId: GrievanceId },
        success: function (data) {
            $("#filterHeader").html('');
            $("#forwardedComplaintListPartialView").html('');
            $("#forwardedComplaintDetailPartialView").html('');
            $("#forwardedComplaintDetailPartialView").html(data);
            hideLoader();
        },
        error: function (error) {
            console.error('Error fetching grievance notifications:', error);
        }
    });
}

function fdComplaintAcceptBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Accept Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="acceptInput" class="form-label d-flex">Enter Details:</label>
        <input type="text" id="acceptInput" class="form-control" placeholder="Enter details">
        <span id="acceptInputError" class="text-danger"></span>
        <div></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitAcceptForm()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('acceptInput').addEventListener('input', function () {
            document.getElementById('acceptInputError').innerText = "";
        });

    }, 100);
}

function fdComplaintRejectBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Reject Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="rejectInput" class="form-label d-flex">Enter Reason:</label>
        <input type="text" id="rejectInput" class="form-control" placeholder="Enter reason">
        <span id="rejectInputError" class="text-danger"></span>

        <label for="rejectFile" class="form-label d-flex mt-4">Attach PDF:</label>
        <input type="file" id="rejectedpdfPicker" class="form-control" accept="application/pdf" onchange="rejectedFileUpload(event)">
        <span id="rejectedpdfPickerError" class="text-danger"></span>

        <div id="rejectedfileInfo" class="text-muted"></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitRejectBtnClicked()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('rejectInput').addEventListener('input', function () {
            document.getElementById('rejectInputError').innerText = "";
        });

        document.getElementById('rejectedpdfPicker').addEventListener('change', function () {
            document.getElementById('rejectedpdfPickerError').innerText = "";
        });
    }, 100);
}

function fdComplaintRevertBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Revert Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="revertInput" class="form-label d-flex">Enter Remarks:</label>
        <input type="text" id="revertInput" class="form-control" placeholder="Enter remarks">
        <span id="revertInputError" class="text-danger"></span>

        <label for="revertFile" class="form-label d-flex mt-4">Attach PDF:</label>
        <input type="file" id="revertedpdfPicker" class="form-control" accept="application/pdf" onchange="revertedFileUpload(event)">
        <span id="revertedpdfPickerError" class="text-danger"></span>

        <div id="revertedfileInfo" class="text-muted"></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitRevertBtnClicked()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('revertInput').addEventListener('input', function () {
            document.getElementById('revertInputError').innerText = "";
        });

        document.getElementById('revertedpdfPicker').addEventListener('change', function () {
            document.getElementById('revertedpdfPickerError').innerText = "";
        });
    }, 100);
}

function openModal(content) {
    document.getElementById("popupContent").innerHTML = content;
    document.getElementById("popupModal").style.display = "block";
}

function closeModal() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');
    modal.style.display = 'none';
    popupContent.innerHTML = '';
}


function submitAcceptForm() {
    showLoader();

    // Retrieve form data
    var forwardedId = $('#hiddenForwardedId').val();
    var grievanceId = $('#hiddenGrievanceId').val();
    var acceptRemark = $('#acceptInput').val();
    var acceptanceDate = new Date();

    if (!acceptRemark) {
        $("#acceptInputError").text("Please write accept remark.");
        hideLoader();
        return;
    }

    // Prepare data
    const data = {
        Id: forwardedId,
        GrievanceId: grievanceId,
        HOAcceptanceComment: acceptRemark,
        HOAcceptanceDate: acceptanceDate
    };

    // Send data via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceAccept',
        type: 'POST',
        data: data,
        success: function (response) {
            hideLoader();
            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
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

    closeModal();
}


let rejectedFileDocument = null;
function rejectedFileUpload(event) {
    showLoader();
    const file = event.target.files[0];
    const fileInfo = document.getElementById("rejectedfileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            rejectedFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            rejectedFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", rejectedFileDocument);
            hideLoader();
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        rejectedFileDocument = null;
    }
    hideLoader();
}
function submitRejectBtnClicked() {
    showLoader();
    var ForwardedId = $('#hiddenForwardedId').val();
    var GrievanceId = $('#hiddenGrievanceId').val();
    var RejectedComment = $('#rejectInput').val();
    var RejectedPdf = $('#rejectedpdfPicker').val();
    var RejectionDate = new Date();

    if (!RejectedComment) {
        $("#rejectInputError").text("Please write forwarding remark.");
        hideLoader();
        return;
    }

    //if (!RejectedPdf) {
    //    $("#rejectedpdfPickerError").text("Please attach pdf.");
    //    hideLoader();
    //    return;
    //}

    const data = {
        Id: ForwardedId,
        GrievanceId: GrievanceId,
        HORejectionComment: RejectedComment,
        HORejectionDate: RejectionDate,
        HORejectedDocument: rejectedFileDocument,
    };

    console.log("Submitting Rejected Form:", data);
    submitRejectForm(data)
    closeModal();
}
function submitRejectForm(data) {
    showLoader();
    const formData = new FormData();

    // Append all data fields to FormData
    formData.append("Id", data.Id);
    formData.append("GrievanceId", data.GrievanceId);
    formData.append("HORejectionComment", data.HORejectionComment);
    formData.append("HORejectionDate", data.HORejectionDate);
    formData.append("HORejectedDocument", new Blob([data.HORejectedDocument], { type: "application/pdf" }));

    // Send FormData via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceReject',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            hideLoader();

            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error: ", error);
            alert("An error occurred while rejecting the grievance.");
        }
    });
}


let revertedFileDocument = null;
function revertedFileUpload(event) {
    const file = event.target.files[0];
    const fileInfo = document.getElementById("revertedfileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            revertedFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            revertedFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", revertedFileDocument);
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        revertedFileDocument = null;
    }
}
function submitRevertBtnClicked() {
    showLoader();
    var ForwardedId = $('#hiddenForwardedId').val();
    var GrievanceId = $('#hiddenGrievanceId').val();
    var RevertRemark = $('#revertInput').val();
    var RevertPdf = $('#revertedpdfPicker').val();
    var ReversionDate = new Date();

    if (!RevertRemark) {
        $("#revertInputError").text("Please write revert remark.");
        hideLoader();
        return;
    }
    if (!RevertPdf) {
        $("#revertedpdfPickerError").text("Please attach pdf.");
        hideLoader();
        return;
    }

    const data = {
        Id: ForwardedId,
        GrievanceId: GrievanceId,
        HOReversionComment: RevertRemark,
        HOReversionDate: ReversionDate,
        HOReversionDocument: revertedFileDocument,
    };

    console.log("Submitting Reverted Form:", data);
    submitRevertForm(data);
    closeModal();
}
function submitRevertForm(data) {
    showLoader();
    const formData = new FormData();

    // Append all data fields to FormData
    formData.append("Id", data.Id);
    formData.append("GrievanceId", data.GrievanceId);
    formData.append("HOReversionComment", data.HOReversionComment);
    formData.append("HOReversionDate", data.HOReversionDate);
    if (data.HOReversionDocument) {
        formData.append("HOReversionDocument", new Blob([data.HOReversionDocument], { type: "application/pdf" }));
    }

    // Send FormData via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceRevert',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            hideLoader();

            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error: ", error);
            alert("An error occurred while reverting the grievance.");
        }
    });
}

function forwardedGrievanceHomeBtnClicked() {
    window.location.href = '/Dashboards/GrievanceReporting';
}

function handlePDFAction(action, base64Data) {
    const byteCharacters = atob(base64Data);
    const byteNumbers = new Array(byteCharacters.length).fill().map((_, i) => byteCharacters.charCodeAt(i));
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);

    if (action === 'preview') {
        // Open the PDF in a new tab for preview
        window.open(url, '_blank');
    } else if (action === 'download') {
        // Trigger the download
        const a = document.createElement('a');
        a.href = url;
        a.download = 'document.pdf'; // Set default filename
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    }
}

function fdComplntZOAcceptBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Accept Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="acceptZOInput" class="form-label d-flex">Enter Details:</label>
        <input type="text" id="acceptZOInput" class="form-control" placeholder="Enter details">
        <span id="acceptZOInputError" class="text-danger"></span>
        <div></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitZOAcceptForm()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('acceptZOInput').addEventListener('input', function () {
            document.getElementById('acceptZOInputError').innerText = "";
        });

    }, 100);
}
function fdComplntZORejectBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Reject Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="rejectZOInput" class="form-label d-flex">Enter Reason:</label>
        <input type="text" id="rejectZOInput" class="form-control" placeholder="Enter reason">
        <span id="rejectZOInputError" class="text-danger"></span>

        <label for="rejectZOFile" class="form-label d-flex mt-4">Attach PDF:</label>
        <input type="file" id="rejectedZOpdfPicker" class="form-control" accept="application/pdf" onchange="rejectedZOFileUpload(event)">
        <span id="rejectedZOpdfPickerError" class="text-danger"></span>

        <div id="rejectedZOfileInfo" class="text-muted"></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitZORejectBtnClicked()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('rejectZOInput').addEventListener('input', function () {
            document.getElementById('rejectedZOpdfPickerError').innerText = "";
        });

        document.getElementById('rejectedZOpdfPicker').addEventListener('change', function () {
            document.getElementById('rejectedpdfPickerError').innerText = "";
        });
    }, 100);
}
function fdComplntZORevertBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Revert Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="revertZOInput" class="form-label d-flex">Enter Remarks:</label>
        <input type="text" id="revertZOInput" class="form-control" placeholder="Enter remarks">
        <span id="revertZOInputError" class="text-danger"></span>

        <label for="revertZOFile" class="form-label d-flex mt-4">Attach PDF:</label>
        <input type="file" id="revertedZOpdfPicker" class="form-control" accept="application/pdf" onchange="revertedZOFileUpload(event)">
        <span id="revertedZOpdfPickerError" class="text-danger"></span>

        <div id="revertedZOfileInfo" class="text-muted"></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitZORevertBtnClicked()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('revertZOInput').addEventListener('input', function () {
            document.getElementById('revertZOInputError').innerText = "";
        });

        document.getElementById('revertedZOpdfPicker').addEventListener('change', function () {
            document.getElementById('revertedZOpdfPickerError').innerText = "";
        });
    }, 100);
}
function fdComplntZOForwardBtnClicked() {
    const modal = document.getElementById('popupModal');
    const popupContent = document.getElementById('popupContent');

    popupContent.innerHTML = `
        <h3>Forward Complaint</h3>
        <button type="button" class="close" onclick="closeModal()">
            <span aria-hidden="true">&times;</span>
        </button>
        <label for="forwardZOInput" class="form-label d-flex">Enter Remarks:</label>
        <input type="text" id="forwardZOInput" class="form-control" placeholder="Enter remarks">
        <span id="forwardZOInputError" class="text-danger"></span>

        <label for="forwardZOFile" class="form-label d-flex mt-4">Attach PDF:</label>
        <input type="file" id="forwardedZOpdfPicker" class="form-control" accept="application/pdf" onchange="forwardedZOFileUpload(event)">
        <span id="forwardedZOpdfPickerError" class="text-danger"></span>

        <div id="forwardedZOfileInfo" class="text-muted"></div>
        <button type="button" class="btn btn-success mt-4" onclick="submitZOforwardBtnClicked()">Submit</button>
    `;
    modal.style.display = 'block';

    // Remove error text after write something in input field
    setTimeout(() => {
        document.getElementById('forwardZOInput').addEventListener('input', function () {
            document.getElementById('forwardZOInputError').innerText = "";
        });

        document.getElementById('forwardedZOpdfPicker').addEventListener('change', function () {
            document.getElementById('forwardedZOpdfPickerError').innerText = "";
        });
    }, 100);
}

function submitZOAcceptForm() {
    showLoader();

    // Retrieve form data
    var forwardedId = $('#hiddenForwardedId').val();
    var grievanceId = $('#hiddenGrievanceId').val();
    var acceptRemark = $('#acceptZOInput').val();
    var acceptanceDate = new Date();

    if (!acceptRemark) {
        $("#acceptZOInputError").text("Please write accept remark.");
        hideLoader();
        return;
    }

    // Prepare data
    const data = {
        Id: forwardedId,
        GrievanceId: grievanceId,
        ZOAcceptanceComment: acceptRemark,
        ZOAcceptanceDate: acceptanceDate
    };

    // Send data via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceAcceptByZO',
        type: 'POST',
        data: data,
        success: function (response) {
            hideLoader();
            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
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

    closeModal();
}

let revertedZOFileDocument = null;
function revertedZOFileUpload(event) {
    const file = event.target.files[0];
    const fileInfo = document.getElementById("revertedZOfileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            revertedZOFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            revertedZOFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", revertedZOFileDocument);
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        revertedZOFileDocument = null;
    }
}
function submitZORevertBtnClicked() {
    showLoader();
    var ForwardedId = $('#hiddenForwardedId').val();
    var GrievanceId = $('#hiddenGrievanceId').val();
    var RevertRemark = $('#revertZOInput').val();
    var RevertPdf = $('#revertedZOpdfPicker').val();
    var ReversionDate = new Date();

    if (!RevertRemark) {
        $("#revertZOInputError").text("Please write revert remark.");
        hideLoader();
        return;
    }
    if (!RevertPdf) {
        $("#revertedZOpdfPickerError").text("Please attach pdf.");
        hideLoader();
        return;
    }

    const data = {
        Id: ForwardedId,
        GrievanceId: GrievanceId,
        ZOReversionComment: RevertRemark,
        ZOReversionDate: ReversionDate,
        ZOReversionDocument: revertedZOFileDocument,
    };

    console.log("Submitting Reverted Form:", data);
    submitZORevertForm(data);
    closeModal();
}
function submitZORevertForm(data) {
    showLoader();
    const formData = new FormData();

    // Append all data fields to FormData
    formData.append("Id", data.Id);
    formData.append("GrievanceId", data.GrievanceId);
    formData.append("ZOReversionComment", data.ZOReversionComment);
    formData.append("ZOReversionDate", data.ZOReversionDate);
    if (data.ZOReversionDocument) {
        formData.append("ZOReversionDocument", new Blob([data.ZOReversionDocument], { type: "application/pdf" }));
    }

    // Send FormData via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceRevertedByZO',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            hideLoader();

            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error: ", error);
            alert("An error occurred while reverting the grievance.");
        }
    });
}

let rejectedZOFileDocument = null;
function rejectedZOFileUpload(event) {
    showLoader();
    const file = event.target.files[0];
    const fileInfo = document.getElementById("rejectedZOfileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            rejectedZOFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            rejectedZOFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", rejectedZOFileDocument);
            hideLoader();
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        rejectedZOFileDocument = null;
    }
    hideLoader();
}
function submitZORejectBtnClicked() {
    showLoader();
    var ForwardedId = $('#hiddenForwardedId').val();
    var GrievanceId = $('#hiddenGrievanceId').val();
    var ZORejectionComment = $('#rejectZOInput').val();
    var ZORejectionPdf = $('#rejectedZOpdfPicker').val();
    var ZORejectionDate = new Date();

    if (!ZORejectionComment) {
        $("#rejectZOInputError").text("Please write forwarding remark.");
        hideLoader();
        return;
    }

    //if (!ZORejectionPdf) {
    //    $("#rejectedZOpdfPickerError").text("Please attach pdf.");
    //    hideLoader();
    //    return;
    //}

    const data = {
        Id: ForwardedId,
        GrievanceId: GrievanceId,
        ZORejectionComment: ZORejectionComment,
        ZORejectionDate: ZORejectionDate,
        ZORejectionDocument: rejectedZOFileDocument,
    };

    console.log("Submitting Rejected Form:", data);
    submitZORejectForm(data)
    closeModal();
}
function submitZORejectForm(data) {
    showLoader();
    const formData = new FormData();

    // Append all data fields to FormData
    formData.append("Id", data.Id);
    formData.append("GrievanceId", data.GrievanceId);
    formData.append("ZORejectionComment", data.ZORejectionComment);
    formData.append("ZORejectionDate", data.ZORejectionDate);
    formData.append("ZORejectionDocument", new Blob([data.ZORejectionDocument], { type: "application/pdf" }));

    // Send FormData via AJAX
    $.ajax({
        url: '/ComplaintManagement/ForwardedGrievanceRejectedByZO',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            hideLoader();

            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error: ", error);
            alert("An error occurred while rejecting the grievance.");
        }
    });
}

let forwardingZOFileDocument = null;
function forwardedZOFileUpload(event) {
    const file = event.target.files[0];
    const fileInfo = document.getElementById("forwardedZOfileInfo");

    if (file) {
        if (file.type !== "application/pdf") {
            fileInfo.textContent = "Please select a valid PDF file.";
            forwardingZOFileDocument = null;
            return;
        }

        fileInfo.textContent = `Selected File: ${file.name}`;

        const reader = new FileReader();
        reader.onload = function (e) {
            const binaryString = e.target.result;
            forwardingZOFileDocument = binaryString;

            console.log("Uploaded File (Binary Data):", forwardingZOFileDocument);
        };
        reader.readAsArrayBuffer(file);
    } else {
        fileInfo.textContent = "";
        forwardingZOFileDocument = null;
    }
}
function submitZOforwardBtnClicked() {
    showLoader();
    var ForwardedId = $('#hiddenForwardedId').val();
    var GrievanceId = $('#hiddenGrievanceId').val();
    var zoForwardingRemark = $('#forwardZOInput').val();
    var zoForwardingPdf = $('#forwardedZOpdfPicker').val();
    var zoForwardingDate = new Date();

    if (!zoForwardingRemark) {
        $("#forwardZOInputError").text("Please write forwarding remark.");
        hideLoader();
        return;
    }
    if (!zoForwardingPdf) {
        $("#forwardedZOpdfPickerError").text("Please attach pdf.");
        hideLoader();
        return;
    }

    const data = {
        Id: ForwardedId,
        GrievanceId: GrievanceId,
        ZOForwardingComment: zoForwardingRemark,
        ZOForwardingDate: zoForwardingDate,
        ZOForwardingDocument: forwardingZOFileDocument,
    };

    console.log("Submitting Reverted Form:", data);
    submitZOForwardingForm(data);
    closeModal();
}
function submitZOForwardingForm(data) {
    showLoader();
    const formData = new FormData();

    // Append all data fields to FormData
    formData.append("Id", data.Id);
    formData.append("GrievanceId", data.GrievanceId);
    formData.append("ZOForwardingComment", data.ZOForwardingComment);
    formData.append("ZOForwardingDate", data.ZOForwardingDate);
    if (data.ZOForwardingDocument) {
        formData.append("ZOForwardingDocument", new Blob([data.ZOForwardingDocument], { type: "application/pdf" }));
    }

    // Send FormData via AJAX
    $.ajax({
        url: '/ComplaintManagement/GrievanceForwardedByZO',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            hideLoader();

            if (response.success) {
                // Show success message and reload the page
                alert(response.message);
                window.location.reload();
            } else {
                // Show error message
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            hideLoader();
            console.error("Error: ", error);
            alert("An error occurred while reverting the grievance.");
        }
    });
}


function grievanceForwardListDownloadClicked() {
    let siId = $("#SystemIntegrator").val();
    let distId = $("#District").val();
    let statusId = $("#statusFilter").val();

    window.location.href = `/ComplaintManagement/DownloadForwardGrievanceList?DistrictId=${distId}&SIId=${siId}&GrievanceStatus=${statusId}`;
}

function ClearAllDropDown() {
    $("#SystemIntegrator").val("0");
    $("#District").val("0");
    $("#statusFilter").val("0");
    getForwardedComplaintList();
}
