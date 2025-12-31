const { start } = require("@popperjs/core");

function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}

function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}


function ProjectReportList(District = 0, Project = 0, StartDate, EndDate) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/DownloadReport/ProjectReportList',
        dataType: 'html',
        data: { DistrictId: District, ProjectId: Project, StartDate: StartDate, EndDate: EndDate },
        success: function (response) {
            $('#ProjectReportPartialView').html('');
            $('#ProjectReportPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function searchUserList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var User = $('#User').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    var isChecked = $("#dateFilter").is(":checked");
    var filterStatus = isChecked ? 1 : 0;

    userReportList(District, Block, User, StartDate, EndDate, filterStatus);
}

function getUserList() {
    $.ajax({
        url: "/Admin/GetUserListByZonal",
        method: "GET",
        dataType: "json",
        success: function (data) {
            var userDropdown = $('#User');

            $.each(data, function (index, item) {
                userDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
}


function GetBlockByDistrictReport() {

    var districtId = $('#District').val();
    $.ajax({
        url: '/Admin/GetBlockByDistricts',
        type: 'GET',
        data: { districtId: districtId },
        success: function (data) {
            var blockDropdown = $('#Block');
            blockDropdown.empty();
            const allOption = $('<option>', {
                value: 0, // You can set this to a specific value if needed
                text: 'Select Block'
            });

            // Append the "All" option to the dropdown
            blockDropdown.append(allOption);
            $.each(data, function (index, item) {
                blockDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });


}

function fetchDist() {

    $.ajax({
        url: '/Admin/GetDistricts',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#District');
            districtDropdown.empty();
            const allDistOption = $('<option>', {
                value: 0,
                text: 'Select District'
            });
            districtDropdown.append(allDistOption);
            $.each(data, function (index, item) {
                districtDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
}

function GetBlockListByDistrict() {

    var districtId = $('#District').val();
    $.ajax({
        url: '/Admin/GetBlockByDistricts',
        type: 'GET',
        data: { districtId: districtId },
        success: function (data) {
            var blockDropdown = $('#Block');
            blockDropdown.empty();
            const allOption = $('<option>', {
                value: 0, 
                text: 'Select Block'
            });

            // Append the "All" option to the dropdown
            blockDropdown.append(allOption);
            $.each(data, function (index, item) {
                blockDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            searchUserList();
        }
    });

}

function onSearchClicked() {
    var districtId = $("#District").val();
    var projectId = $("#Project").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    ProjectReportList(districtId, projectId, startDate, endDate);

}

function ClearAllSearchJJM() {
    fetchDistforAdminPanel();
}

function downloadJJMReport() {
    alert("Download Button Clicked");
}

function getProjectName() {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Admin/GetProjectName',
            type: 'GET',
            success: function (data) {
                var ProjectDropDown = $('#Project');
                ProjectDropDown.empty();

                $.each(data, function (index, item) {
                    ProjectDropDown.append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));
                });
                ProjectDropDown.append($('<option>', {
                    value: 0,
                    text: "All Project"
                }));

                hideLoader();
                resolve();  // Resolve the promise when the AJAX call completes successfully
            },
            error: function (error) {
                reject(error);  // Reject the promise if there's an error
            }
        });
    });
}

function downloadReportClicked() {
    var districtId = $("#District").val();
    var projectId = $("#Project").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    downloadReport(districtId, projectId, startDate, endDate);
}

//function downloadReport(District, Project, StartDate, EndDate) {
//    var aa = 0;
//    showLoader();

//    $.ajax({
//        url: '/DownloadReport/DownloadProjectList',
//        dataType: 'html',
//        data: { DistrictId: District, ProjectId: Project, StartDate: StartDate, EndDate: EndDate },
//        success: function (response) {

//            hideLoader();
//        },
//        error: function (xhr, status, error) {
//        }
//    });
//}

function downloadReport(District, Project, StartDate, EndDate) {
    showLoader();



    // Create a URL with query parameters
    var url = `/DownloadReport/DownloadProjectList?DistrictId=${District}&ProjectId=${Project}&StartDate=${StartDate}&EndDate=${EndDate}`;

    // Redirect to the URL to trigger file download
    window.location.href = url;

    hideLoader();
}

function DownloadUserReportCountListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var User = $('#User').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    var isChecked = $("#dateFilter").is(":checked");
    var filterStatus = isChecked ? 1 : 0;

    DownloadUserReportCountList(District, Block, User, StartDate, EndDate, filterStatus);
}

function DownloadUserReportCountList(District, Block, User, StartDate, EndDate, filterStatus) {
    showLoader();

    // Create a URL with query parameters
    var url = `/DownloadReport/DownloadUserReportCountList?DistrictId=${District}&BlockId=${Block}&UserId=${User}&StartDate=${StartDate}&EndDate=${EndDate}&FilterStatus=${filterStatus}`;

    // Redirect to the URL to trigger file download
    window.location.href = url;

    hideLoader();
}


function fetchDistforAdminPanel() {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Admin/GetDistrictsForAdminPanel',
            type: 'GET',
            success: function (data) {
                var districtDropdown = $('#District');

                $.each(data, function (index, item) {
                    districtDropdown.append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));
                });
                districtDropdown.append($('<option>', {
                    value: 0,
                    text: "All District"
                }));

                resolve();  // Resolve the promise when the AJAX call completes successfully
            },
            error: function (error) {
                reject(error);  // Reject the promise if there's an error
            }
        });
    });
}


function loadOneMonthAgoDate() {
    // Get the current date
    var today = new Date();

    // Set the date to one month before today
    var oneMonthAgo = new Date(today.setMonth(today.getMonth() - 1));

    // Format the date to yyyy-mm-dd
    var formattedDate = oneMonthAgo.toISOString().split('T')[0];

    // Set the value of the date picker
    document.getElementById('StartDate').value = formattedDate;
}



function GetProjectCount(StartDate, EndDate, filterStatus, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/DownloadReport/ProjectReportCountList',
        dataType: 'html',
        data: { StartDate: StartDate, EndDate: EndDate, filterStatus: filterStatus, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#ProjectReportCountPartialView').html('');
            $('#ProjectReportCountPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function SearchProjectReportCount() {
    var WorkingStatus = $("#WorkingStatus").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    // Check if the checkbox is checked
    var isChecked = $("#dateFilter").is(":checked");

    // Set filterStatus based on the checkbox state
    var filterStatus = isChecked ? 1 : 0;

    GetProjectCount(startDate, endDate, filterStatus, WorkingStatus);
}
function downloadReportCountClicked() {
    var WorkingStatus = $("#WorkingStatus").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    // Check if the checkbox is checked
    var isChecked = $("#dateFilter").is(":checked");

    // Set filterStatus based on the checkbox state
    var filterStatus = isChecked ? 1 : 0;

    window.location.href = `/DownloadReport/DownloadProjectReportCountList?StartDate=${startDate}&EndDate=${endDate}&filterStatus=${filterStatus}&WorkingStatus=${WorkingStatus}`;

}


function dateFilterClicked(checkbox) {
    var isChecked = checkbox.checked;

    // Enable or disable date pickers based on checkbox state
    document.getElementById('StartDate').disabled = !isChecked;
    document.getElementById('EndDate').disabled = !isChecked;

    // Call the appropriate function based on the checkbox state
    if (isChecked) {
        SearchProjectReportCount();
    } else {
        SearchProjectReportCount();
    }
}

function userDateFilterClicked(checkbox) {
    var isChecked = checkbox.checked;

    // Enable or disable date pickers based on checkbox state
    document.getElementById('StartDate').disabled = !isChecked;
    document.getElementById('EndDate').disabled = !isChecked;

    // Call the appropriate function based on the checkbox state
    if (isChecked) {
        searchUserList();
    } else {
        searchUserList();
    }
}

function GlanceWorkingStatusClicked() {
    SearchProjectReportCount();
}

function GetProjectCountDetails(StartDate, EndDate, filterStatus, WorkingStatus, districtId , projectId) {
    var aa = 0;

    $.ajax({
        url: '/DownloadReport/ProjectReportCountListDetail',
        dataType: 'html',
        data: { StartDate: StartDate, EndDate: EndDate, filterStatus: filterStatus, WorkingStatus: WorkingStatus, ProjectId: projectId, DistrictId: districtId },
        success: function (response) {
            $('#ProjectReportCountListDetailPartialView').html('');
            $('#ProjectReportCountListDetailPartialView').html(response);

            document.getElementById('ProjectReportCountListDetailPartialView').scrollIntoView({
                behavior: 'smooth'
            });
        },
        error: function (xhr, status, error) {
        }
    });
}

function GetProjectCountDetailsClicked(districtId, districtName, linkElement) {
    var tdId = linkElement.getAttribute('data-td-id');
    var projectId = tdId;
    var WorkingStatus = $("#WorkingStatus").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    // Check if the checkbox is checked
    var isChecked = $("#dateFilter").is(":checked");

    // Set filterStatus based on the checkbox state
    var filterStatus = isChecked ? 1 : 0;

    console.log("District Id : " + districtId + " & DistrictName = " + districtName + " Project Id : " + projectId + " filter Status = " + filterStatus);

    GetProjectCountDetails(startDate, endDate, filterStatus, WorkingStatus,districtId , projectId);
}

function GetUserCountDetails(userId, filterStatus, projectId, startDate, endDate) {
    $.ajax({
        url: '/DownloadReport/UserReportCountListDetail',
        dataType: 'html',
        data: {
            UserId: userId,
            ProjectId: projectId,
            FilterStatus: filterStatus,
            StartDate: startDate,
            EndDate: endDate
        },
        success: function (response) {
            $('#userReportDetailPartialView').html('');
            $('#userReportDetailPartialView').html(response);

            document.getElementById('userReportDetailPartialView').scrollIntoView({
                behavior: 'smooth'
            });
        },
        error: function (xhr, status, error) {
        }
    });
}

function GetUserCountDetailsClicked(userId, filterStatus, linkElement) {
    var projectId = linkElement.getAttribute('data-td-id');

    var WorkingStatus = $("#WorkingStatus").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();

    // Check if the checkbox is checked
    var isChecked = $("#dateFilter").is(":checked");

     //Set filterStatus based on the checkbox state
    var filterStatus = isChecked ? 1 : 0;

    GetUserCountDetails(userId, filterStatus, projectId, startDate, endDate);
} 



// Triggered when a date is selected from the date picker
function startDatePickerChanged(input) {
    if (!input.disabled) {
        SearchProjectReportCount();
    }
}

function userStartDatePickerChanged(input) {
    if (!input.disabled) {
        searchUserList();
    }
}

function endDatePickerChanged(input) {
    if (!input.disabled) {
        SearchProjectReportCount();
    }
}

function userEndDatePickerChanged(input) {
    if (!input.disabled) {
        searchUserList();
    }
}

function DownlodToReports() {
    window.location.href = '/DownloadReport/Index';
}

function BackToDashboard() {
    window.location.href = '/Dashboards/LandingPage';
}

function userReportList(District, Block, User, StartDate, EndDate, filterStatus) {
    showLoader();
    $.ajax({
        url: '/DownloadReport/UserReportCountList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, UserId: User, StartDate: StartDate, EndDate: EndDate, FilterStatus: filterStatus },
        success: function (response) {
            $('#userReportPartialView').html('');
            $('#userReportPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}
function districtOptionClick() {
    GetBlockListByDistrict(this);
    clearUserList();
}
function userOptionClicked() {
    searchUserList();
    clearDistrictList();
    clearBlockList();
}
function clearButtonClicked() {
    clearDistrictList();
    clearBlockList();
    clearUserList();
    searchUserList();
}
function clearDistrictList() {
    $('#District').empty();
    $('#District').append($('<option>', {
        value: '',
        text: 'Select District'
    }));
    fetchDist();
}
function clearBlockList() {
    $('#Block').empty();
    $('#Block').append($('<option>', {
        value: '',
        text: 'Select Block'
    }));
}

function clearUserList() {
    $('#User').empty();
    $('#User').append($('<option>', {
        value: '',
        text: 'Select User'
    }));
    getUserList();
}

function userDetailBtnClicked(InspectionId, ProjectId) {
    var url = "";

    if (ProjectId == 5) {
        url = "/Reports/BiogasACDetails";
    } else if (ProjectId == 7) {
        url = "/Reports/JJMACDetails";
    } else if (ProjectId == 8) {
        url = "/Reports/OTJJMACDetails";
    } else if (ProjectId == 10) {
        url = "/Reports/SSYDetails";
    } else if (ProjectId == 12) {
        url = "/Reports/CMGGYACDetails";
    } else if (ProjectId == 13) {
        url = "/Reports/CIACDetails";
    } else if (ProjectId == 14) {
        url = "/Reports/RVEDDGACDetails";
    } else if (ProjectId == 15) {
        url = "/Reports/OTRVEDDGDetails";
    } else if (ProjectId == 16) {
        url = "/Reports/OGPPACDetails";
    } else if (ProjectId == 17) {
        url = "/Reports/HMACDetails";
    } else if (ProjectId == 18) {
        url = "/Reports/MMACDetails";
    }

    $.ajax({
        url: url,
        dataType: 'html',
        data: { Id: InspectionId },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.setItem('cmnReportData', response);
                console.log(response);
            } else {
                alert("No Data Found");
            }

        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
        }
    });
}