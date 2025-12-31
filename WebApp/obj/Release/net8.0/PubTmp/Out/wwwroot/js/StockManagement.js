
function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}

function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}

function BackToDashboard() {
    window.location.href = '/Dashboards/LandingPage';
}
function BacktoHome() {
    window.location.href = 'Index';
}


function GetViewItemList() {
    showLoader();
    $.ajax({
        url: "/StockManagement/ViewItemList",
        type: "html",
        success: function (response) {
            $('#ViewItemListPartialView').html('');
            $('#ViewItemListPartialView').html(response);
            hideLoader();
        }
    });
}

document.getElementById('backToDashButton').addEventListener('click', function () {
    BackToDashboard();
});

document.addEventListener("DOMContentLoaded", function () {
    // Get today's date
    var today = new Date();

    // Format the date to yyyy-MM-dd
    var day = ("0" + today.getDate()).slice(-2);
    var month = ("0" + (today.getMonth() + 1)).slice(-2);
    var formattedDate = today.getFullYear() + '-' + month + '-' + day;

    // Set the date picker's value to today
    document.getElementById('StartDate').value = formattedDate;
    // document.getElementById('EndDate').value = formattedDate;
});


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

function getViewItemListDetails() {
    $.ajax({
        url: "/StockManagement/ViewItemListDetail",
        dataType: "html",
        success: function (response) {
            console.log(response);
            $('#ViewItemListDetailsPartialView').html('');
            $('#ViewItemListDetailsPartialView').html(response);

            document.getElementById('ViewItemListDetailsPartialView').scrollIntoView({
                behavior: 'smooth'
            });

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
            var siDropdown = $('#txtSIname');
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
            getBlockByDistrict();
            hideLoader();
        }
    });
}
function getDistrict() {
    showLoader();
    $.ajax({
        url: '/Admin/GetDistricts',
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
                value: 0, // You can set this to a specific value if needed
                text: 'ग्राम'
            });

            // Append the "All" option to the dropdown
            villageDropdown.append(allOption);
            $.each(data, function (index, item) {
                villageDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
            hideLoader();
        }
    });
}
function villageOptionClicked() {
    getSiteByVillage();
}
function getSiteByVillage() {
    showLoader();
    var siteId = $('#txtVillage').val();
    $.ajax({
        url: '/Admin/GetSitesByVillage',
        type: 'GET',
        data: { siteId: siteId },
        success: function (data) {
            var siteDropdown = $('#txtSite');
            siteDropdown.empty();
            const allOption = $('<option>', {
                value: 0, 
                text: 'साइट'
            });

            // Append the "All" option to the dropdown
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
function showContainer() {
    document.querySelectorAll('.unique-container').forEach(container => {
        container.classList.add('hidden');
    });

    const selectedOption = document.getElementById("options").value;
    const challanOptions = document.getElementById("challanOptions").value;

    console.log(selectedOption);
    if (selectedOption) {
        document.getElementById("commonFields").classList.remove('hidden');
        document.getElementById(selectedOption).classList.remove('hidden');
    } else {
        document.getElementById("commonFields").classList.add('hidden');
    }

    console.log(challanOptions);
    if (challanOptions === 'Incoming') {
        document.getElementById("Incoming").classList.remove('hidden');
    } else {
        document.getElementById("Incoming").classList.add('hidden');
    }
}

function calculateSum() {
    const workingItem = parseFloat(document.getElementById('workingItem').value) || 0;
    const notWorkingItem = parseFloat(document.getElementById('notWorkingItem').value) || 0;

    document.getElementById('totalItem').value = workingItem + notWorkingItem;
}

function userReportList() {
   /* showLoader();*/

    $.ajax({
        url: '/StockManagement/AtGlancePartialView',
        dataType: 'html',
        data: '',
        success: function (response) {
            $('#AtGlancePartialView').html('');
            $('#AtGlancePartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
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
