function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}

function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}

function fetchDistforAdminPanel() {
    $.ajax({
        url: '/Admin/GetDistrictsForAdminPanel',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#txtJila');

            districtDropdown.empty();

            districtDropdown.append($('<option>', {
                value: '',
                text: 'Select District'
            }));

            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
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


function fetchDist() {

    $.ajax({
        url: '/Admin/GetDistrictsForAdminPanel',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#DistrictId');

            districtDropdown.empty();

            districtDropdown.append($('<option>', {
                value: '',
                text: 'Select District'
            }));

            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
}


function GetRoles() {
    $.ajax({
        url: '/Admin/GetRoles',
        type: 'GET',
        success: function (data) {
            var roleDropdown = $('#RoleId');
            roleDropdown.empty();
            $.each(data, function (index, item) {
                roleDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });

        }
    });
}

function fetchOfficeLevel() {
    $.ajax({
        url: '/Admin/GetOfficeLevel',
        type: 'GET',
        success: function (data) {
            var officeLevelDropdown = $('#OfficeLevelId');
            officeLevelDropdown.empty();
            $.each(data, function (index, item) {
                officeLevelDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            GetZonal();
        }
    });
}
function GetZonal() {
    var officeLevelId = $('#OfficeLevelId').val();
    if (officeLevelId == 2) {
        document.getElementById('ZonalId').disabled = false;
        $.ajax({
            url: '/Admin/GetZonal',
            type: 'GET',
            success: function (data) {
                var zonalDropdown = $('#ZonalId');
                zonalDropdown.empty();
                $.each(data, function (index, item) {
                    zonalDropdown.append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));
                });
            }
        });
    }
    else {
        document.getElementById('ZonalId').disabled = true;
        var zonalDropdown = $('#ZonalId');
        zonalDropdown.empty();
        zonalDropdown.append($('<option>', {
            value: "",
            text: "Select Zonal"
        }));

    }

}
function fetchDistrictsforSite() {
    $.ajax({
        url: '/Admin/GetDistricts',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#DistrictId');
            districtDropdown.empty();
            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
}

function DistrictClicked() {
    clearBlock();
    GetBlocksByDistrict();
    clearVillage();
}
function GetBlocksByDistrict() {
    console.log("Test Id");
    var districtId = $('#DistrictId').val();
    $.ajax({
        url: '/Admin/GetBlockByDistricts',
        type: 'GET',
        data: { districtId: districtId },
        success: function (data) {
            var blockDropdown = $('#BlockId'); 
            blockDropdown.empty();  
            blockDropdown.append($('<option>', {
                value: '',
                text: 'Select Block'
            }));

            $.each(data, function (index, item) {
                blockDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
}


function BlockClicked() {
    clearVillage();
    GetVillageByBlocks();
}
function GetVillageByBlocks() {
    var blockId = $('#BlockId').val();
    $.ajax({
        url: '/Admin/GetVillageByBlocks',
        type: 'GET',
        data: { blockId: blockId },
        success: function (data) {
            var villageDropdown = $('#VillageId');
            $.each(data, function (index, item) {
                villageDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });

        }
    });
}

function AddUser() {

    $("#userNameError").text("");
    $("#emailError").text("");
    $("#mobileError").text("");
    $("#roleError").text("");

    var username = $("#userName").val();
    var email = $("#emailId").val();
    var mobile = $("#mobileNumber").val();
    var role = $("#RoleId").val();
    var district = $("#DistrictId").val();
    var block = $("#BlockId").val();
    var officeLevel = $("#OfficeLevelId").val();
    if (officeLevel == 1) {
        officeLevel = -1;
    }
    if (officeLevel == 3) {
        officeLevel = 0;
    }
    if (officeLevel == 2) {
        officeLevel = $("#ZonalId").val();
    }
    // Check the checkbox status
    var isDistrictIncharge = $("#districtInchargeCheckBox").is(":checked");
    var districtInchargeValue = isDistrictIncharge ? district : 0;
    var obj = {};
    var isValid = true;

    if (!username) {
        $("#userNameError").text("Username is required.");
        isValid = false;
    }

    // Email validation
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email) {
        $("#emailError").text("Email is required.");
        isValid = false;
    } else if (!emailPattern.test(email)) {
        $("#emailError").text("Please enter a valid email address.");
        isValid = false;
    }

    // Mobile number validation
    var mobilePattern = /^\d{10}$/;
    if (!mobile) {
        $("#mobileError").text("Mobile Number is required.");
        isValid = false;
    } else if (!mobilePattern.test(mobile)) {
        $("#mobileError").text("Please enter a valid 10-digit mobile number.");
        isValid = false;
    }

    if (!role) {
        $("#roleError").text("Role is required.");
        isValid = false;
    }

    if (isValid) {
        obj = {
            Id: 0,
            UserId: 0,
            UserName: username,
            Email: email,
            MobileNumber: mobile,
            RoleId: role,
            DistrictId: district,
            BlockId: block,
            ZonalId: officeLevel,
            isDistrictIncharge: districtInchargeValue,
            CreatedBy: 'System',
            CreatedOn: Date.now,
            UpdatedBy: 'System',
            UpdatedOn: Date.now,
        }

        $.ajax({
            url: '/Admin/AddUser',
            type: 'POST',
            data: obj,
            dataType: 'json',
            success: function (data) {
                if (data.isSuccess) {
                    alert('User successfully created.');
                    $("#userName").val("");
                    $("#emailId").val("");
                    $("#mobileNumber").val("");
                    alert('User created successfully!');
                    UserlistShow();
                } else if (data.isUserExist) {
                    alert('User already exists with the given mobile number.');
                }
            },
            error: function (error) {
                // Handle error
                console.error('Error:', error);
            }
        });
    }
}
function AddSite() {
    var siteId = $("#siteId").val();
    var siteName = $("#siteName").val();
    var districtId = $("#DistrictId").val();
    var blockId = $("#BlockId").val();
    var villageId = $("#VillageId").val();
    var projectId = $("#projectName").val();
    var SIId = $("#SIName").val();
    var commissioningDate = $("#commissioningDate").val();
    if (siteId == "") {
        siteId = 0;
    }
    var obj = {};
    obj = {
        Id: 0,
        SiteId: siteId,
        SiteName: siteName,
        DistrictId: districtId,
        BlockId: blockId,
        VillageId: villageId,
        ProjectId: projectId,
        SIId: SIId,
        CommissioningDate: commissioningDate,
        CreatedBy: "System",
        CreatedOn: Date.now,
        UpdatedBy: "System",
        UpdatedOn: Date.now
    }


    $.ajax({
        url: '/Admin/AddSite',
        type: 'POST',
        data: obj,
        dataType: 'json',
        success: function (data) {
            // Handle success
            alert('Successfully Created');
            $("#siteId").text("");
            $("#siteName").text("");

            UserlistShow();
        },
        error: function (error) {
            // Handle error
            console.error('Error:', error);
        }
    });

}
function ApplicantPartialViewShow() {

    var aa = 0;
    $.ajax({
        url: '/Admin/ApplicantPartialView',
        dataType: 'html',
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);

        },
        error: function (xhr, status, error) {
        }
    });
}
function SitePartialViewShow() {
    var aa = 0;
    $.ajax({
        url: '/Admin/SitePartialView',
        dataType: 'html',
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);
        },
        error: function (xhr, status, error) {
        }
    });
}
function SIPartialViewShow() {
    var aa = 0;
    $.ajax({
        url: '/Admin/SIUserPartialView',
        dataType: 'html',
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);
        },
        error: function (xhr, status, error) {
        }
    });
}
function ProjectPartialViewShow() {
    var aa = 0;
    $.ajax({
        url: '/Admin/ApplicantPartialView',
        dataType: 'html',
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);

        },
        error: function (xhr, status, error) {
        }
    });
}
function ApplicationPartialViewShow() {
    var aa = 0;
    $.ajax({
        url: '/Admin/ApplicantPartialView',
        dataType: 'html',
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);

        },
        error: function (xhr, status, error) {
        }
    });
}
function UserlistShow(Username = ' ', District = 0) {
    showLoader();
    var aa = 0;
    $.ajax({
        url: '/Admin/GetUserList',
        dataType: 'html',
        data: { UserName: Username, DistrictId: District },
        success: function (response) {
            $('#RegistrationPartialView').html('');
            $('#SiteListPartialViewContainer').hide();
            $('#RegistrationPartialView').html(response);

            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function SearchUserlist() {
    var Username = $('#Username').val();
    var District = $('#DistrictId').val();

    UserlistShow(Username, District);
}

function ClearAllUserlist() {
    $('#Username').empty();
    SearchUserlist();
}

function clearDistrict() {
    $('#DistrictId').empty();
    $('#DistrictId').append($('<option>', {
        value: '',
        text: 'Select District'
    }));
    fetchDistforAdminPanel();
}
function clearBlock() {
    $('#BlockId').empty();
    $('#BlockId').append($('<option>', {
        value: '',
        text: 'Select Block'
    }));
}

function clearVillage() {
    $('#VillageId').empty();
    $('#VillageId').append($('<option>', {
        value: '',
        text: 'Select Village'
    }));
}
function SitelistShow(District = 0, Block = 0, VillageId = 0) {
    $('#RegistrationPartialView').html('');
    document.getElementById('universalLoader').style.display = 'flex';
    var distId = $('#DistrictId').val(); // Get the value
    //var blockId = $('#BlockId').val(); // Get the value
    //var villageId = $('#VillageId').val(); // Get the value
    if (!distId) {
        distId = 1; // Set default value if empty
    }
    $.ajax({
        url: '/Admin/GetSiteList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village },
        success: function (response) {
            $('#SiteListPartialViewContainer').show();
            $('#SiteListPartialView').html(response); // Directly set the response

            hideLoader();

        },
        error: function (xhr, status, error) {
            // Handle error
            console.error('Error fetching site list:', error);
        }
    });
}

function SearchSitelist() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var villageId = 0;

    if (Block == 0) {
        Block = 0;
    }
    else if (Block != 0) {
        District = 0;
    }
    SitelistShow(District, Block, villageId);
}

function ClearAllSitelist() {
    fetchDist();

    SitelistShow();
}

function EditUser(Id) {
    showLoader();
    var aa = 0;
    $.ajax({
        url: '/Admin/EditUser',
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            $('#FiltersPartialView').html('');
            $('#RegistrationPartialView').html('');
            $('#RegistrationPartialView').html(response);

            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });

}
function DeleteUser(Id) {
    showLoader();
    var aa = 0;
    $.ajax({
        url: '/Admin/DeleteUser',
        data: { Id: Id },
        success: function (response) {
            alert('Successfully Deleted');
            UserlistShow();
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });

}

function getAdminUserList() {
    showLoader();
    $.ajax({
        url: '/Admin/AdminPanelUserListPartialView',
        dataType: 'html',
        success: function (response) {
            $('#AdminPanelUserPartialView').html('');
            $('#AdminPanelUserPartialView').html(response);
            //hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}
function getSIName() {
    showLoader();
    $.ajax({
        url: '/Admin/GetSystemIntegrator',
        type: 'GET',
        success: function (data) {
            var siDropdown = $('#SIName');
            siDropdown.empty();

            siDropdown.append($('<option>', {
                value: '',
                text: 'Please Select SI'
            }));

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
function AddSIUser() {

    $("#SIContactPersonError").text("");
    $("#SINameError").text("");
    $("#mobileError").text("");
    $("#emailError").text("");

    var SIContactPerson = $("#SIContactPerson").val();
    var SIId = $("#SIName").val();
    var SIName = $("#SIName option:selected").text();
    var mobile = $("#mobileNumber").val();
    var email = $("#emailId").val();


    // Check the checkbox status
    var obj = {};
    var isValid = true;

    if (!SIContactPerson) {
        $("#SIContactPersonError").text("Username is required.");
        isValid = false;
    }
    if (!SIName) {
        $("#SINameError").text("SI Name is required.");
        isValid = false;
    }
    if (!SIId) {
        $("#SINameError").text("SI Name is required.");
        isValid = false;
    }

    // Email validation
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email) {
        $("#emailError").text("Email is required.");
        isValid = false;
    } else if (!emailPattern.test(email)) {
        $("#emailError").text("Please enter a valid email address.");
        isValid = false;
    }

    // Mobile number validation
    var mobilePattern = /^\d{10}$/;
    if (!mobile) {
        $("#mobileError").text("Mobile Number is required.");
        isValid = false;
    } else if (!mobilePattern.test(mobile)) {
        $("#mobileError").text("Please enter a valid 10-digit mobile number.");
        isValid = false;
    }


    if (isValid) {
        obj = {
            SIId: SIId,
            SIName: SIName,
            SIContactPerson: SIContactPerson,
            Email: email,
            MobileNumber: mobile,
            CreatedBy: 'System',
            CreatedOn: Date.now,
            UpdatedBy: 'System',
            UpdatedOn: Date.now
        }

        $.ajax({
            url: '/Admin/AddSIUser',
            type: 'POST',
            data: obj,
            dataType: 'json',
            success: function (data) {
                if (data.isSuccess) {
                    alert('User successfully created.');
                    $("#userName").val("");
                    $("#emailId").val("");
                    $("#mobileNumber").val("");
                    $("#SIName").val("");
                    //$("#SIId").text("");
                    SIPartialViewShow();
                } else if (data.isUserExist) {
                    alert('User already exists with the given mobile number.');
                }
            },
            error: function (error) {
                // Handle error
                console.error('Error:', error);
            }
        });
    }  

}
function getProjectName() {
    showLoader();
    //return new Promise((resolve, reject) => {
    $.ajax({
        url: '/Admin/GetProjectName',
        type: 'GET',
        success: function (data) {
            var ProjectDropDown = $('#projectName');
            ProjectDropDown.empty();

            ProjectDropDown.append($('<option>', {
                value: '',
                text: 'Please Select Project'
            }));

            $.each(data, function (index, item) {
                ProjectDropDown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            hideLoader();
            //resolve();  // Resolve the promise when the AJAX call completes successfully
        },
        error: function (error) {
            reject(error);  // Reject the promise if there's an error
        }
    });
    //});
}