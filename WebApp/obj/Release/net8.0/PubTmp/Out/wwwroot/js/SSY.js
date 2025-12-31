
// Clear error messages when typing in the field
$("input, select").on("input change", function () {
    $(this).next(".error").text("");
});

function validateForm() {
    // Clear previous errors
    $(".error").text("");

    let isValid = true;

    // Define validation rules as an array of objects
    const fields = [
        { id: "txtappname", errorId: "appnameError", message: "आवेदक का नाम आवश्यक है।" },
        { id: "sex1", errorId: "sexError", message: "कृपया लिंग का चयन करें।", checkValue: "0" },
        { id: "txtfathername", errorId: "fathernameError", message: "पिता/पति का नाम आवश्यक है।" },
        { id: "txtinstall", errorId: "installError", message: "स्थापना स्थल का नाम आवश्यक है।" },
        { id: "txtbfnaddr", errorId: "beneficallyNameError", message: "हितग्राही का नाम आवश्यक है।" },
        { id: "txtvidhansabha", errorId: "vidhansabhaError", message: "विधानसभा क्षेत्र का नाम आवश्यक है।" },
        { id: "txtjila", errorId: "distNameError", message: "जिला का नाम आवश्यक है।" },
        { id: "txtvikaskhand", errorId: "blockNameError", message: "विकासखंड का नाम आवश्यक है।" },
        { id: "txtdemandno", errorId: "demandNoError", message: "विद्युत कनेक्शन हेतु डिमाण्ड नोट क्रमांक आवश्यक है।" },
        { id: "txtkhasra", errorId: "khasraNoError", message: "प्रस्तावित भूमि का खसरा नम्बर आवश्यक है।" },
        { id: "txtrakba", errorId: "rakbaNoError", message: "रकबा (हेक्टेयर मे) आवश्यक है।" },
        { id: "txtwatersrc", errorId: "watersrcError", message: "जल स्त्रोत आवश्यक है।" },
        { id: "txtcast", errorId: "castNameError", message: "आवेदक के वर्ग का आवश्यक है।" },
        { id: "txtpumpcapacity", errorId: "pumpCapacityError", message: "पंप की क्षमता का चयन आवश्यक है।" },
        { id: "uni_ddl1", errorId: "uni_ddl1Error", message: "पंप के प्रकार का चयन आवश्यक है।" },
        { id: "uni_ddl", errorId: "uni_ddlError", message: "पंप का चयन आवश्यक है।" },
        { id: "txtaccount", errorId: "accountNoError", message: "खाता नम्बर आवश्यक है।", regex: /^\d+$/, regexMessage: "खाता नम्बर केवल अंकों में होना चाहिए।" },
        { id: "txtbank", errorId: "bankNameError", message: "बैंक का नाम आवश्यक है।" },
        { id: "txtifsc", errorId: "ifscError", message: "IFSC नम्बर आवश्यक है।" },
        { id: "txtddnumber", errorId: "ddNumberError", message: "मान्य DD नम्बर दर्ज करें।", regex: /^\d+$/, regexMessage: "मान्य DD नम्बर दर्ज करें।" },
        { id: "txtdddate", errorId: "ddDateError", message: "ड्राफ्ट दिनांक आवश्यक है।" },
        { id: "txtddbank", errorId: "ddBankNameError", message: "ड्राफ्ट बैंक का नाम आवश्यक है।" }
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

    // Validate Mobile No separately
    let mobile = $("#txtphoneno").val();
    if (mobile === "" || !/^\d{10}$/.test(mobile)) {
        $("#mobileError").text("मान्य मोबाइल नंबर दर्ज करें।");
        isValid = false;
    }

    // Validate Aadhar No
    let aadharNo = $("#txtadhar").val();
    if (aadharNo === "" || !/^\d{12}$/.test(aadharNo)) {
        $("#aadharNoError").text("आधार कार्ड क्रमांक केवल 12 अंकों का होना चाहिए।");
        isValid = false;
    }

    // Validate Voter No
    let voterNo = $("#txtvoter").val();
    if (voterNo === "" || !/^[A-Za-z0-9]+$/.test(voterNo)) {
        $("#voterNoError").text("मान्य वोटर कार्ड क्रमांक दर्ज करें।");
        isValid = false;
    }

    // Submit the form if valid
    if (isValid) {
        return true;
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var today = new Date().toISOString().split('T')[0];
});

function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}

function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}
function getDistrict() {
    showLoader();
    $.ajax({
        url: '/SSY/GetDistricts',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#txtjila');
            districtDropdown.empty();

            districtDropdown.append($('<option>', {
                value: '',
                text: 'जिला का चयन करें'
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

function getBlockByDistrict() {
    showLoader();
    var districtId = $('#txtjila').val();
    $.ajax({
        url: '/SSY/GetBlockByDistricts',
        type: 'GET',
        data: { districtId: districtId },
        success: function (data) {
            var blockDropdown = $('#txtvikaskhand');
            blockDropdown.empty();
            const allOption = $('<option>', {
                value: 0, // You can set this to a specific value if needed
                text: 'विकासखंड का चयन करें'
            });

            // Append the "All" option to the dropdown
            blockDropdown.append(allOption);
            $.each(data, function (index, item) {
                blockDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            hideLoader();
        }
    });
}
function RegisterSSY() {
    event.preventDefault();
    if (validateForm()) {
        showLoader();
        // Get all form field values
        var applicantName = document.getElementById('txtappname').value;
        var sex1 = document.getElementById('sex1').value;
        var fatherName = document.getElementById('txtfathername').value;
        var installationSite = document.getElementById('txtinstall').value;
        var beneficallyName = document.getElementById('txtbfnaddr').value;
        var vidhansabha = document.getElementById('txtvidhansabha').value;
        var district = document.getElementById('txtjila').value;
        var block = document.getElementById('txtvikaskhand').value;
        var phoneNo = document.getElementById('txtphoneno').value;
        var adharNo = document.getElementById('txtadhar').value;
        var voterNo = document.getElementById('txtvoter').value;
        var demandNo = document.getElementById('txtdemandno').value;
        var khasraNo = document.getElementById('txtkhasra').value;
        var totalArea = document.getElementById('txtrakba').value;
        var waterSource = document.getElementById('txtwatersrc').value;
        var category = document.getElementById('txtcast').value;
        var pumpCapacity = document.getElementById('txtpumpcapacity').value;
        var solarPumpType = document.getElementById('uni_ddl1').value;
        var pumpType = document.getElementById('uni_ddl').value;

        // Create a registration object to send to the server
        var ssyRegistrationData = {
            ApplicantName: applicantName,
            Gender: sex1,
            FatherName: fatherName,
            InstallationSite: installationSite,
            ApplicantAddress: beneficallyName,
            VidhansabhaRegion: vidhansabha,
            DistrictId: district, // Convert to BigInt
            BlockId: block,       // Convert to BigInt
            ApplicantMobileNum: phoneNo,
            AadharNumber: adharNo,
            VoterIdNumber: voterNo,
            ElectricConnectionSerialNumber: demandNo,
            KhasraNumber: khasraNo,
            TotalArea: totalArea,
            WaterSource: waterSource,
            CasteId: category,    // Convert to BigInt
            PumpCapacityId: pumpCapacity, // Convert to BigInt
            SolarPumpTypeId: solarPumpType, // Convert to BigInt
            PumpChoiceId: pumpType, // Convert to BigInt
            CreatedBy: "Admin",
            CreatedOn: new Date().toISOString(),
            UpdatedBy: "Admin",
            UpdatedOn: new Date().toISOString()

        };

        $.ajax({
            url: '/SSY/SaveSSYRegistrationData', // Ensure this matches your routing setup
            type: 'POST',
            data: ssyRegistrationData,
            dataType: 'json',
            success: function (response) {
                console.log("Registration successful:", response);
                saveBankDetails();
            },
            error: function (xhr, status, error) {
                console.error("Error: ", error);
                alert("Failed to save data.");
            }
        });
    }
}

function saveBankDetails() {
    // Get all form field values for bank details
    var AccountNo = document.getElementById('txtaccount').value;
    var BankName = document.getElementById('txtbank').value;
    var IFSCCode = document.getElementById('txtifsc').value;
    var DD_ReceiptNo = document.getElementById('txtddnumber').value;
    var DD_Date = document.getElementById('txtdddate').value;
    var DD_Bank = document.getElementById('txtddbank').value;

    // Create a bank details object
    var bankData = {
        ProjectId: 10,
        RegistrationId: 0, // Use the RegistrationId passed from the first request
        AccountNumber: AccountNo,
        BankName: BankName,
        IFSCCode: IFSCCode,
        DDReceiptNumber: DD_ReceiptNo,
        Date: DD_Date,
        DDBankName: DD_Bank,
        CreatedBy: "Admin",
        CreatedOn: new Date().toISOString(),
        UpdatedBy: "Admin",
        UpdatedOn: new Date().toISOString()
    };

    // Second AJAX call to save bank details
    $.ajax({
        url: '/SSY/SaveBankDetail',
        type: 'POST',
        data: bankData,
        dataType: 'json',
        success: function (response) {
            console.log("Bank Details saved successfully:", response);
            alert("Data saved successfully!");
            hideLoader();
            pageReload();
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("Failed to save bank data.");
            hideLoader();

        }
    });
}
function pageReload() {
    location.reload();
}
function getPaymentData() {
    var categoryId = document.getElementById('txtcast').value;
    var pumpCapacityId = document.getElementById('txtpumpcapacity').value;
    var solarPumpTypeId = document.getElementById('uni_ddl1').value;
    var pumpTypeId = document.getElementById('uni_ddl').value;

    var data = {
        Category: categoryId,
        PumpCapacity: pumpCapacityId,
        SolarPumpType: solarPumpTypeId,
        PumpType: pumpTypeId
    }

    $.ajax({
        url: '/SSY/GetPaymentData',
        type: 'GET',
        data: { Category: categoryId, PumpCapacity: pumpCapacityId, SolarPumpType: solarPumpTypeId, PumpType: pumpTypeId },
        success: function (data) {
            fillPaymentData(data);
        }
    });
}

function fillPaymentData(data) {
    console.log(data);
    // Set the total cost in the input field
    $('#txtttlcost').val(data[0].systemCost);
    $('#txtrate').val(data[0].amountWithGST);
    $('#txtstate1').val(data[0].stateGrant);
    $('#txtcentralfund').val(data[0].centralGrant);
    $('#txtmyfund').val(data[0].applicantCostToBePaidByUser);
    $('#txtprofee').val(data[0].applicationCost);

}
function onCategoryChanged() {
    getPaymentData();
}

function onPumpCapChanged() {
    getPaymentData();
}

function onSolarPumpTypeChanged() {
    getPaymentData();
}

function onPumpChoiceChanged() {
    getPaymentData();
}

function getGrievanceGlanceCountList() {
    showLoader();
    $.ajax({
        url: '/SSY/GrievanceGlanceList',
        dataType: 'html',
        success: function (response) {
            $('#GrievanceGlancePartialView').html('');
            $('#GrievanceGlancePartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function GetGrievanceGlanceDetailsClicked(districtId, totalComplaint, resolvedComplaint,
    complaintLess30Days, pendingDOLessThan30Days, pendingZOLessThan30Days, pendingHOLessThan30Days,
    complaintMore30Days, pendingDOMoreThan30Days, pendingZOMoreThan30Days, pendingHOMoreThan30Days, totalPendingComplaint) {
    $.ajax({
        url: "/SSY/GrievanceGlanceListDetail",
        dataType: "html",
        data: {
            DistrictId: districtId,//1
            TotalComplaint: totalComplaint,//2
            ResolvedComplaint: resolvedComplaint,//3
            ComplaintLess30Days: complaintLess30Days,//4
            PendingDOLessThan30Days: pendingDOLessThan30Days,//5
            PendingZOLessThan30Days: pendingZOLessThan30Days,//6
            PendingHOLessThan30Days: pendingHOLessThan30Days,//7
            ComplaintMore30Days: complaintMore30Days,//8
            PendingDOMoreThan30Days: pendingDOMoreThan30Days,//9
            PendingZOMoreThan30Days: pendingZOMoreThan30Days,//10
            PendingHOMoreThan30Days: pendingHOMoreThan30Days,//11
            TotalPendingComplaint: totalPendingComplaint//12
        },
        success: function (response) {
            $('#GrievanceGlanceDetailsView').html('');
            $('#GrievanceGlanceDetailsPartialView').html('');
            $('#GrievanceGlanceDetailsPartialView').html(response);
            document.getElementById('GrievanceGlanceDetailsPartialView').scrollIntoView({
                behavior: 'smooth'
            });
        },
        error: function (xhr, status, error) {
        }
    });
}
function searchSSYDetail() {

    if (validateAndSearchSSYDetail()) {

        var AdharNo = document.getElementById('aadharno').value;
        var MobileNo = document.getElementById('mobileno').value;

        getSSYDetail(AdharNo, MobileNo)
    }

}
function getSSYDetail(AdharNo, MobileNo) {
    //showLoader();
    $.ajax({
        url: '/SSY/SSY_Check_Status_PartialView',
        dataType: 'html',
        data: { AdharNo: AdharNo, MobileNo: MobileNo },
        success: function (response) {
            $('#SSYDetailParitalView').html('');
            $('#SSYDetailParitalView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function validateAndSearchSSYDetail() {
    let isValid = true;

    // Aadhar Number validation (should be numeric and 12 digits)
    let aadharNo = $("#aadharno").val();
    if (aadharNo === "" || !/^\d{12}$/.test(aadharNo)) {
        $("#aadharError").text("कृपया 12 अंकों का वैध आधार नंबर दर्ज करें।");
        isValid = false;
    } else {
        $("#aadharError").text("");  // Clear error if valid 
    }

    // Mobile Number validation (should be numeric and 10 digits)
    let mobileNo = $("#mobileno").val();
    if (mobileNo === "" || !/^\d{10}$/.test(mobileNo)) {
        $("#mobileError").text("कृपया 10 अंकों का वैध मोबाइल नंबर दर्ज करें।");
        isValid = false;
    } else {
        $("#mobileError").text("");  // Clear error if valid
    }

    // Proceed with search if validation passes
    if (isValid) {
        return true;
    }
}


function GrievanceGlanceDetailClicked(Id) {
    //showLoader();
    $.ajax({
        url: '/SSY/GrievancesDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {

            if (response && $.trim(response).length > 0) {
                $('#GrievanceGlanceDetailsView').html('');
                $('#GrievanceGlanceDetailsView').html(response);
                document.getElementById('GrievanceGlanceDetailsView').scrollIntoView({
                    behavior: 'smooth'
                });

            } else {
                alert("No Data Found");
            }
            //hideLoader();

            //$('#FaultFiltersView').html('');
            //$('#GrievancesPartialView').html(response);
            //hideLoader();
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
        }
    });
}


