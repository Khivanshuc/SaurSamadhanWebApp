function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}
function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}

function makeAjaxCall(controller, action, serviceData = {}, qryString = '', method = '', callBack) {

    if (qryString && qryString[0] !== '?') {
        qryString = '?' + qryString;
    }

    if (!method) {
        method = Object.keys(serviceData).length === 0 ? 'GET' : 'POST';
    }

    $.ajax({
        url: `/${controller}/${action}${qryString}`,
        type: method.toUpperCase(),
        dataType: "json",
        data: serviceData,
        success: function (response) {
            if (typeof callBack === 'function') {
                callBack(response);
            } else {
                console.warn("Callback is not a function.");
            }
        },
        error: function (xhr, status, error) {
            console.error(`AJAX Error: ${status} - ${error}`);
            alert("An error occurred while fetching districts.");
        }
    });
}

function populateDistrictDropdown(data) {
    let districtDropdown = $('#District');
    districtDropdown.empty();
    districtDropdown.append(`<option selected disabled>जिला का चयन करे</option>`);
    data.forEach(item => {
        districtDropdown.append(`<option value="${item.value}">${item.text}</option>`);
    });
}
function populateBlocksDropdownByDistrict(data) {
    let districtDropdown = $('#Block');
    districtDropdown.empty();
    districtDropdown.append(`<option selected disabled>विकाशखण्ड का चयन करे</option>`);
    data.forEach(item => {
        districtDropdown.append(`<option value="${item.value}">${item.text}</option>`);
    });
}
function populateVillageDropdownByBlock(data) {
    let districtDropdown = $('#Village');
    districtDropdown.empty();
    districtDropdown.append(`<option selected disabled>ग्राम का चयन करे</option>`);
    data.forEach(item => {
        districtDropdown.append(`<option value="${item.value}">${item.text}</option>`);
    });
}

function populateProjectDropDown(data) {
    let projectDropdown = $('#Project');
    projectDropdown.empty();
    projectDropdown.append(`<option selected disabled>योजना का चयन करे</option>`);
    data.forEach(item => {
        projectDropdown.append(`<option value="${item.value}">${item.text}</option>`);
    });
}

function populateSiteDropDown(data) {
    let siteDropdown = $('#Site');
    siteDropdown.empty();
    siteDropdown.append(`<option selected disabled>स्थान चयन करे</option>`);
    data.forEach(item => {
        siteDropdown.append(`<option value="${item.value}">${item.text}</option>`);
    });
}
function populateRegionDropDown() {
    let region = $("#Region");
    region.empty();
    region.append(`<option selected disabled>क्षेत्र का चयन करे</option>`);
    region.append(`<option value="Rural">Rural</option>`);
    region.append(`<option value="Urban">Urban</option>`);
}

function populateSystemWorkingStatusDropDown() {
    let systemWorkingStatus = $("#SystemWorkingStatus");
    systemWorkingStatus.empty();
    systemWorkingStatus.append(`<option selected disabled>चयन करे</option>`);
    systemWorkingStatus.append(`<option value="1">कार्यशील</option>`);
    systemWorkingStatus.append(`<option value="0">अकार्यशील</option>`);
}

function initializeDropdowns() {
    makeAjaxCall('Admin', 'GetProjectName', {}, '', 'GET', populateProjectDropDown);
    makeAjaxCall('Admin', 'GetDistricts', {}, '', 'GET', populateDistrictDropdown);
    populateRegionDropDown();
    populateSystemWorkingStatusDropDown();
}

function bindDropdownChangeEvents() {
    $(document).on("change", "#District", handleDistrictChange);
    $(document).on("change", "#Block", handleBlockChange);
    $(document).on("change", "#Village", handleVillageChange);
    $(document).on("change", "#Project", handleProjectChange);
}

function handleDistrictChange() {
    let postData = { districtId: $(this).val() };
    makeAjaxCall('Admin', 'GetBlockByDistricts', postData, '', 'GET', populateBlocksDropdownByDistrict);
}

function handleBlockChange() {
    let postData = { blockId: $(this).val() };
    makeAjaxCall('Admin', 'GetVillageByBlocks', postData, '', 'GET', populateVillageDropdownByBlock);
}

function handleVillageChange() {
    let postData = { villageId: $(this).val() };
    makeAjaxCall('Admin', 'GetSitesByVillageId', postData, '', 'GET', populateSiteDropDown);
}

function handleProjectChange() {
    let selectedProjectId = parseInt($(this).val());
    if (selectedProjectId === 10) {
        $("#DropDownSite").hide();
        $("#InputSite").show();
    } else {
        $("#InputSite").hide();
        $("#DropDownSite").show();
    }
}

function initializeFormValidation() {

    $("#ManualGrievanceForm").validate({
        rules: {
            district: "required",
            block: "required",
            village: "required",
            region: "required",
            applicantName: "required",
            area: "required",
            project: "required",
            site: "required",
            systemWorkingStatus: "required",
            contactNumber: {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            remark: "required"
        },
        messages: {
            district: "कृपया जिला चयन करें",
            block: "कृपया विकाशखण्ड का चयन करे",
            village: "कृपया ग्राम का चयन करे",
            region: "कृपया क्षेत्र का चयन करे",
            applicantName: "कृपया आवेदक का नाम दर्ज करें",
            area: "कृपया स्थान दर्ज करें",
            project: "कृपया योजना का चयन करें",
            site: "कृपया स्थान दर्ज करें",
            systemWorkingStatus: "कृपया संयंत्र की स्थिति दर्ज करें",
            contactNumber: {
                required: "कृपया फ़ोन नंबर दर्ज करें",
                digits: "केवल अंकों की अनुमति है",
                minlength: "फ़ोन नंबर 10 अंकों का होना चाहिए",
                maxlength: "फ़ोन नंबर 10 अंकों का होना चाहिए"
            },
            remark: "कृपया समस्या का विवरण दर्ज करें"
        },
        errorClass: "text-danger", // Optional styling
        errorElement: "div",      // Optional: show errors in <div> instead of <label>
        highlight: function (element) {
            $(element).addClass("is-invalid");
        },
        unhighlight: function (element) {
            $(element).removeClass("is-invalid");
        }
    });
}

function bindImagePreview() {
    $('#ImageInput').on('change', function () {
        const file = this.files[0];
        const preview = $('#imagePreview');

        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                preview.attr('src', e.target.result).show();
            };
            reader.readAsDataURL(file);
        } else {
            preview.hide().attr('src', '');
        }
    });

}

function bindFormSubmit() {
    $("#ManualGrievanceForm").on("submit", function (e) {
        e.preventDefault();

        if (!$(this).valid()) {
            return;
        } else {
            showLoader();
        }

        const formData = new FormData();
        
        //const siteValue = projectId === 10 ? $("#SiteText").val() : $("#Site").val();

        const isWorkingBool = $("#SystemWorkingStatus").val() === "1";
        formData.append("DistrictId", $("#District").val());
        formData.append("BlockId", $("#Block").val());
        formData.append("VillageId", $("#Village").val());
        formData.append("Region", $("#Region").val());
        formData.append("ApplicantName", $("#ApplicantName").val());
        formData.append("Area", $("#Area").val());
        formData.append("ProjectId", $("#Project").val());
        //formData.append("SiteId", siteValue);
        formData.append("IsSystemWorking", isWorkingBool);
        formData.append("MobileNumber", $("#ContactNumber").val());
        formData.append("FaultRemark", $("#Remark").val());
        
        const projectId = parseInt($("#Project").val());
        if (projectId === 10) {
            siteId = 0;
            formData.append("SSYSite", $("#SiteText").val());
            formData.append("SiteId", siteId);

            console.log(`SiteText: ${$("#SiteText").val()}`)
        } else {
            formData.append("SiteId", $("#Site").val());
        }

        const imageFile = $("#ImageInput")[0]?.files[0];
        if (imageFile) {
            formData.append("FaultImage", imageFile);
        }

        //for (let [key, value] of formData.entries()) {
        //    console.log(`${key}:`, value);
        //}


        $.ajax({
            url: '/ManualGrievance/InsertManualGrievance',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            enctype: 'multipart/form-data',
            success: function (response) {
                hideLoader();
                if (response.success) {
                    alert(response.message);
                    // Reset the form
                    $("#ManualGrievanceForm")[0].reset();
                    $("#ImageInput").val("");
                    $("#imagePreview").attr("src", "#").hide();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error: ", error);
                alert("An error occurred while forwarding the grievance.");
            }
        });
    });
}


$(document).ready(function () {
    hideLoader();
    initializeDropdowns();
    bindDropdownChangeEvents();
    bindImagePreview();
    initializeFormValidation();
    bindFormSubmit();
});



