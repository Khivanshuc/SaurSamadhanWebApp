
function ClearAllGrievances() {
    clearSystemIntegratorList();
    clearBlockList();
    clearVillageList();
    fetchDist();
    GrievancesList();
}

function BacktoHome() {
    window.location.href = 'Grievances';
}
function GrievancesList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus = 0, StartDate, EndDate, filterStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/GrievancesList',
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
            $('#GrievancesPartialView').html('');
            $('#GrievancesPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function EditGrievances(Id) {
    showLoader();
    var aa = 0;
    $.ajax({
        url: '/Reports/EditGrievances',
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            $('#FaultFiltersView').html('');
            $('#GrievancesPartialView').html('');
            $('#GrievancesPartialView').html(response);
            hideLoader();

            $("#siNameSelect").select2();
            $("#assignToSelect").select2();
        },
        error: function (xhr, status, error) {
        }
    });
}

function GrievancesDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/GrievancesDetails',
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            showLoader();
            $('#FaultFiltersView').html('');
            $('#GrievancesPartialView').html('');
            $('#GrievancesPartialView').html(response);
            hideLoader();
            //window.open('/Home/CmnReportView', '_blank');

            //if (response && $.trim(response).length > 0) {
            //    localStorage.setItem('cmnReportData', response);
            //    console.log(response);
            //} else {
            //    alert("No Data Found");
            //}
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
        }
    });
}

function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}
function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}
function showReportDownloadLoader() {
    document.getElementById("ReportLoader").style.setProperty("display", "flex", "important");
}
function hideReportDownloadLoader() {
    document.getElementById("ReportLoader").style.setProperty("display", "none", "important");
}

function InProgressList(District = 0, Block = 0, Village, Scheme, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/InProgressInspectionList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, ProjectId: Scheme, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#IPIPartialView').html('');
            $('#IPIPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function IPIDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/IPIDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}
function SSYIPIList(District = 0, Block = 0, Village = 0, SystemIntegrator = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/SSYInProgressInspectionList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SystemIntegrator, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#SSYIPIPartialView').html('');
            $('#SSYIPIPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

//function SSYIPIDetails(Id) {
//    showLoader();
//    $.ajax({
//        url: '/Reports/SSYIPIDetails', // Ensure this is the correct URL
//        dataType: 'html',
//        data: { Id: Id },
//        success: function (response) {

//            if (response && $.trim(response).length > 0) {
//                $('#FaultFiltersView').html('');
//                $('#SSYIPIPartialView').html(response);
//            } else {
//                alert("No Data Found");
//            }
//            hideLoader();

//            //$('#FaultFiltersView').html('');
//            //$('#SSYIPIPartialView').html(response);
//            //hideLoader();
//        },
//        error: function (xhr, status, error) {
//            console.error("Error: ", error);
//        }
//    });
//}
function SSYIPIDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/SSYIPIDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}
function OTRVEDDGList(District = 0, Block = 0, Village = 0, SystemIntegrator = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/OTRVEDDMList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SystemIntegrator, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#OTRVEDDGPartialView').html('');
            $('#OTRVEDDGPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function OTRVEDDGDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/OTRVEDDGDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function SSYACList(District = 0, Block = 0, Village = 0, SystemIntegrator = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/SSYACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SystemIntegrator, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#SSYACPartialView').html('');
            $('#SSYACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function SSYDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/SSYDetails',
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {

            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function JJMACList(District = 0, Block = 0, Village = 0, SystemIntegrator = 0, WorkingStatus = 0) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/JJMACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SystemIntegrator, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#JJMACPartialView').html('');
            $('#JJMACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function JJMDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/JJMACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function OTJJMACList(District = 0, Block = 0, Village = 0, SystemIntegrator = 0, WorkingStatus = 0) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/OTJJMACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SystemIntegrator, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#OTJJMACPartialView').html('');
            $('#OTJJMACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function OTJJMDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/OTJJMACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function RVEDDGACList(District = 0, Block = 0, VillageId = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/RVEDDGACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, Village: VillageId, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#RVEDDGACPartialView').html('');
            $('#RVEDDGACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function RVEDDGDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/RVEDDGACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}


function HMACList(District = 0, Block = 0, VillageId = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/HMACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, Village: VillageId, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#HMACPartialView').html('');
            $('#HMACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}


function HMACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/HMACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}



function CMGGYACList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/CMGGYACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#CMGGYACPartialView').html('');
            $('#CMGGYACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function CMGGYACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/CMGGYACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}
function OGPPACList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/OGPPACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#OGPPACPartialView').html('');
            $('#OGPPACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function OGPPACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/OGPPACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}


function MMACList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/MMACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#MMACPartialView').html('');
            $('#MMACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function MMACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/MMACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function CIACList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/CIACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#CIACPartialView').html('');
            $('#CIACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {

        }
    });
}

function CIACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/CIACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {

            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}

function BiogasACList(District = 0, Block = 0, Village = 0, SIId = 0, WorkingStatus) {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/Reports/BiogasACList',
        dataType: 'html',
        data: { DistrictId: District, BlockId: Block, VillageId: Village, SIId: SIId, WorkingStatus: WorkingStatus },
        success: function (response) {
            $('#BiogasACPartialView').html('');
            $('#BiogasACPartialView').html(response);
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}

function BiogasACDetails(Id) {
    showLoader();
    $.ajax({
        url: '/Reports/BiogasACDetails', // Ensure this is the correct URL
        dataType: 'html',
        data: { Id: Id },
        success: function (response) {
            window.open('/Home/CmnReportView', '_blank');

            if (response && $.trim(response).length > 0) {
                localStorage.clear();
                console.log(new Blob([JSON.stringify(response)]).size + " bytes");
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
    hideLoader();
}
function IPDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchInProgressList();

}

function SSYIPDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchSSYInProgressList();

}
function JJMDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchJJMACList();

}

function OTJJMDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchOTJJMACList();

}

function CMGGYDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchCMGGYACList();

}

function CIDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchCIACList();

}

function HighMastDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchHighMastList();

}
function MiniMastDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchMiniMastACList();
}

function BiogasDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchBiogasACList();
}

function GrievancesDistrictClicked() {
    clearBlockList();
    clearVillageList();
    //clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchGrievancesList();
}

function RVEDDGDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchRVEDDGACList();
}

function OTRVEDDGDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchOTRVEDDGList();
}

function OGPPDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchOGPPList();
}

function SSYDistrictClicked() {
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();
    GetBlockListByDistrict();
    SearchSSYACList();
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

function IPBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchInProgressList();
}

function SSYIPBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchSSYInProgressList();
}
function JJMBlockClicked() {
    clearSystemIntegratorList();
    SearchJJMACList();
    GetVillageByBlock();
}

function OTJJMBlockClicked() {
    clearSystemIntegratorList();
    SearchOTJJMACList();
    GetVillageByBlock();
}

function CMGGYBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchCMGGYACList();
}

function CIBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchCIACList();
}

function HighMastBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchHighMastList();
}

function MiniMastBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchMiniMastACList();
}

function BiogasBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchBiogasACList();
}

function GrievancesBlockClicked() {
    //clearSystemIntegratorList();
    GetVillageByBlock();
    SearchGrievancesList();
}

function RVEDDGBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchRVEDDGACList();
}

function OTRVEDDGBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchOTRVEDDGList();
}

function OGPPBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchOGPPList();
}

function SSYBlockClicked() {
    clearSystemIntegratorList();
    GetVillageByBlock();
    SearchSSYACList();
}

function GetVillageByBlock() {
    var blockId = $('#Block').val();

    var villageDropdown = $('#Village');

    if (blockId === "0") {
        villageDropdown.empty();
        const villageOption = $('<option>', {
            value: 0, // You can set this to a specific value if needed
            text: 'Select Village'
        });
        villageDropdown.append(villageOption);

    } else {

        $.ajax({
            url: '/Admin/GetVillageByBlocks',
            type: 'GET',
            data: { blockId: blockId },
            success: function (data) {
                villageDropdown.empty();
                const allOption = $('<option>', {
                    value: 0, // You can set this to a specific value if needed
                    text: 'Select Village'
                });

                // Append the "All" option to the dropdown
                villageDropdown.append(allOption);
                $.each(data, function (index, item) {
                    villageDropdown.append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));
                });
            }
        });

    }

}

function IPVillageClicked() {
    clearSystemIntegratorList();
    SearchInProgressList();
}

function SSYIPVillageClicked() {
    clearSystemIntegratorList();
    SearchSSYInProgressList();
}
function JJMVillageClicked() {
    clearSystemIntegratorList();
    SearchJJMACList();

}

function OTJJMVillageClicked() {
    clearSystemIntegratorList();
    SearchOTJJMACList();

}

function CMGGYVillageClicked() {
    clearSystemIntegratorList();
    SearchCMGGYACList();
}

function CIVillageClicked() {
    clearSystemIntegratorList();
    SearchCIACList();
}

function HighMastVillageClicked() {
    clearSystemIntegratorList();
    SearchHighMastList();
}

function MiniMastVillageClicked() {
    clearSystemIntegratorList();
    SearchMiniMastACList();
}

function BiogasVillageClicked() {
    clearSystemIntegratorList();
    SearchBiogasACList();
}

function GrievancesVillageClicked() {
    //clearSystemIntegratorList();
    SearchGrievancesList();
}

function RVEDDGVillageClicked() {
    clearSystemIntegratorList();
    SearchRVEDDGACList();
}

function OTRVEDDGVillageClicked() {
    clearSystemIntegratorList();
    SearchOTRVEDDGList();
}

function OGPPVillageClicked() {
    clearSystemIntegratorList();
    SearchOGPPList();
}

function SSYVillageClicked() {
    clearSystemIntegratorList();
    SearchSSYACList();
}

function fetchDist() {

    $.ajax({
        url: '/Admin/GetDistricts',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#District');
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
            GetBlockByDistrictReport();
        }
    });
}

function fetchDistforAdminPanel1() {

    $.ajax({
        url: '/Admin/GetDistrictsForAdminPanel',
        type: 'GET',
        success: function (data) {
            var districtDropdown = $('#District');
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
function fetchDistforAdminPanel() {

    return new Promise((resolve, reject) => {
        $.ajax({
            url: '/Admin/GetDistrictsForAdminPanel',
            type: 'GET',
            success: function (data) {
                var districtDropdown = $('#District');
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
                resolve();  // Resolve the promise when the AJAX call completes successfully
            },
            error: function (error) {
                reject(error);  // Reject the promise if there's an error
            }
        });
    });
}


function SearchInProgressList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var Scheme = $('#SchemeName').val();
    var WorkingStatus = $('#WorkingStatus').val();

    InProgressList(District, Block, Village, Scheme, WorkingStatus);
}

function SearchSSYInProgressList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    SSYIPIList(District, Block, Village, SystemIntegrator, WorkingStatus);
}
function SearchJJMACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    JJMACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchOTJJMACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    OTJJMACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchCMGGYACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    CMGGYACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchCIACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    CIACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchHighMastList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    HMACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchMiniMastACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    MMACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchRVEDDGACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    RVEDDGACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchOTRVEDDGList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    OTRVEDDGList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchOGPPList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    OGPPACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchBiogasACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    BiogasACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}

function SearchSSYACList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    SSYACList(District, Block, Village, SystemIntegrator, WorkingStatus);
}


function ClearAllSearchJJM() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchJJMACList();
}

function ClearAllSearchOTJJM() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchOTJJMACList();
}
function SearchGrievancesList() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    var isChecked = $("#dateFilter").is(":checked");
    var filterStatus = isChecked ? 1 : 0;

    GrievancesList(District, Block, Village, SystemIntegrator, WorkingStatus, StartDate, EndDate, filterStatus);
}

function ClearAllSearchIPI() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchInProgressList();
}



function ClearAllSearchSSY() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchSSYACList();
}



function ClearAllSearchRVEDDM() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchOTRVEDDGList();
}



function ClearAllSearchSSYInprogress() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchSSYInProgressList();
}
function ClearAllRVEDDGList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchRVEDDGACList();
}



function ClearAllHMACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();


    SearchHighMastList();
}



function ClearAllBiogasACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();


    SearchBiogasACList();
}


function ClearAllMMACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchMiniMastACList();
}

function ClearAllOGPPACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchOGPPList();
}

function ClearAllCMGGYACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchCMGGYACList();
}



function ClearAllCIACList() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
    clearSystemIntegratorList();

    SearchCIACList();
}

function OpenProjectList(ProjectId) {
    var ActionName = '';
    if (ProjectId == 5) {
        ActionName = 'BiogasAC';
    } else if (ProjectId == 7) {
        ActionName = 'JJMAC';
    } else if (ProjectId == 8) {
        ActionName = 'OTJJMAC';
    }
    else if (ProjectId == 9) {
        return;
    }
    else if (ProjectId == 10) {
        ActionName = 'SSYAC';
    }
    else if (ProjectId == 11) {
        return;
    }
    else if (ProjectId == 12) {
        ActionName = 'CMGGYAC';
    }
    else if (ProjectId == 13) {
        ActionName = 'CIAC';
    } else if (ProjectId == 14) {
        ActionName = 'RVEDDGAC';
    }
    else if (ProjectId == 15) {
        ActionName = 'OTRVEDDMReport';
    }
    else if (ProjectId == 16) {
        ActionName = 'OGPPAC';
    }
    else if (ProjectId == 17) {
        ActionName = 'HMAC';
    }
    else if (ProjectId == 18) {
        ActionName = 'MMAC';
    }
    else if (ProjectId == 19) {
        return;
    }
    window.location.href = '/Reports/' + ActionName;
}

function downloadJJMReport() {
    alert("Download Button Clicked");
}

function getSIName() {
    $.ajax({
        url: '/Admin/GetSystemIntegrator',
        type: 'GET',
        success: function (data) {
            var SIDropdown = $('#SystemIntegrator');
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
        }
    });
    hideLoader();
}

function getProjectName() {
    $.ajax({
        url: '/Admin/GetProjectName',
        type: 'GET',
        success: function (data) {
            var SchemeDropdown = $('#SchemeName');
            SchemeDropdown.empty();

            SchemeDropdown.append($('<option>', {
                value: '',
                text: 'Select Scheme'
            }));

            $.each(data, function (index, item) {
                SchemeDropdown.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        }
    });
    hideLoader();
}
function IPProjectClicked() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();

    SearchInProgressList();
}

function SSYIPSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchSSYInProgressList();
}
function JJMSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchJJMACList();
}
function OTJJMSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchOTJJMACList();
}
function CMGGYSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchCMGGYACList();
}

function CISystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchCIACList();
}

function HighMastSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchHighMastList()
}
function MiniMastSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchMiniMastACList();
}
function BiogasSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchBiogasACList();
}

function GrievancesSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchGrievancesList();
}

function RVEDDGSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchRVEDDGACList();
}

function OTRVEDDGSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchOTRVEDDGList();
}

function OGPPSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchOGPPList();
}

function SSYSystemIntegratorClicked() {
    clearDistBlockVillage();
    SearchSSYACList();
}
function clearDistBlockVillage() {
    clearDistrictList();
    clearBlockList();
    clearVillageList();
}

function clearDistrictList() {
    $('#District').empty();
    $('#District').append($('<option>', {
        value: '',
        text: 'Select District'
    }));
    fetchDistforAdminPanel();
}
function clearBlockList() {
    $('#Block').empty();
    $('#Block').append($('<option>', {
        value: '',
        text: 'Select Block'
    }));
}

function clearVillageList() {
    $('#Village').empty();
    $('#Village').append($('<option>', {
        value: '',
        text: 'Select Village'
    }));
}

function clearSystemIntegratorList() {
    $('#SystemIntegrator').empty();
    $('#SystemIntegrator').append($('<option>', {
        value: '',
        text: 'Select System Integrator'
    }));
    getSIName();
}
function IPWorkingStatusClicked() {
    SearchInProgressList();
}
function JJMWorkingStatusClicked() {
    SearchJJMACList();
}

function OTJJMWorkingStatusClicked() {
    SearchOTJJMACList();
}

function CMGGYWorkingStatusClicked() {
    SearchCMGGYACList();
}
function CIWorkingStatusClicked() {
    SearchCIACList();
}
function RVEDDGWorkingStatusClicked() {
    SearchRVEDDGACList();
}
function OTRVEDDGWorkingStatusClicked() {
    SearchOTRVEDDGList();
}
function OGPPWorkingStatusClicked() {
    SearchOGPPList();
}
function HMWorkingStatusClicked() {
    SearchHighMastList();
}
function MMWorkingStatusClicked() {
    SearchMiniMastACList();
}

function BioGasWorkingStatusClicked() {
    SearchBiogasACList();
}

function SSYIPWorkingStatusClicked() {
    SearchSSYInProgressList();
}

function SSYWorkingStatusClicked() {
    SearchSSYACList();
}

function GrievanceWorkingStatusClicked() {
    SearchGrievancesList();
}

function JJMDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadJJMReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function OTJJMDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadOTJJMReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}


function SSYDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadSSYReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function CMGGYDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadCMGGYReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function CIDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadCIReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function RVEDDGDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadRVEDDGReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function OTRVEDDGDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadOTRVEDDGReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function OGPPDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadOGPPReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function MMDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadMMReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}
function HMDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadHMReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function BiogasDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadBiogasReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;
}

function IPDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var Scheme = $('#SchemeName').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadInspectionIPReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&ProjectId=${Scheme}&WorkingStatus=${WorkingStatus}`;
}

function SSYIPDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();

    window.location.href = `/Reports/DownloadSSYInspectionIPReport?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}`;

}

function grievanceDownloadReportListClicked() {
    var District = $('#District').val();
    var Block = $('#Block').val();
    var Village = $('#Village').val();
    var SystemIntegrator = $('#SystemIntegrator').val();
    var WorkingStatus = $('#WorkingStatus').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    var isChecked = $("#dateFilter").is(":checked");
    var filterStatus = isChecked ? 1 : 0;

    window.location.href = `/Reports/DownloadGrievanceReportList?DistrictId=${District}&BlockId=${Block}&VillageId=${Village}&SIId=${SystemIntegrator}&WorkingStatus=${WorkingStatus}&StartDate=${StartDate}&EndDate=${EndDate}&filterStatus=${filterStatus}`;
}
function JJMSearchClicked() {
    var inspectionId = $('#JJMInspectionId').val();
    JJMDetails(inspectionId);
}

function OTJJMSearchClicked() {
    var inspectionId = $('#OTJJMInspectionId').val();
    OTJJMDetails(inspectionId);
}

function SSYSearchClicked() {
    var inspectionId = $('#SSYInspectionId').val();
    SSYDetails(inspectionId);
}

function CMGGYSearchClicked() {
    var inspectionId = $('#CMGGYInspectionId').val();
    CMGGYACDetails(inspectionId);
}

function CISearchClicked() {
    var inspectionId = $('#CIInspectionId').val();
    CIACDetails(inspectionId);
}

function RVEDDGSearchClicked() {
    var inspectionId = $('#RVEDDGInspectionId').val();
    RVEDDGDetails(inspectionId);
}

function OTRVEDDGSearchClicked() {
    var inspectionId = $('#OTRVEDDGInspectionId').val();
    OTRVEDDGDetails(inspectionId);
}

function OGPPSearchClicked() {
    var inspectionId = $('#OGPPInspectionId').val();
    OGPPACDetails(inspectionId);
}

function HMSearchClicked() {
    var inspectionId = $('#HMInspectionId').val();
    HMACDetails(inspectionId);
}

function MMSearchClicked() {
    var inspectionId = $('#MMInspectionId').val();
    MMACDetails(inspectionId);
}

function BiogasSearchClicked() {
    var inspectionId = $('#BiogasInspectionId').val();
    BiogasACDetails(inspectionId);
}

function SearchGrievanceData() {
    var complaintId = $('#GrievanceComplaintId').val();
    GrievancesDetails(complaintId);
}

function BackToDashboard() {
    window.location.href = '/Dashboards/LandingPage';
}
function SolarDrinkingWaterToReports() {
    window.location.href = '/Reports/SolarDrinkingWater';
}
function SolarIrrigationToReports() {
    window.location.href = '/Reports/SolarIrrigation';
}
function SolarPowerPlantToReports() {
    window.location.href = '/Reports/SolarPowerPlant';
}
function LightingSystemToReports() {
    window.location.href = '/Reports/LightingSystem';
}
function BiogasToReports() {
    window.location.href = '/Reports/Biogas';
}
function DownlodToReports() {
    window.location.href = '/DownloadReport/Index';
}

function downloadJJMPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadJJMPdf?id=${id}`;
    pdfDownloadBase(url);

}

function downloadGrievancesPdfclicked(id) {
    event.preventDefault();
    showReportDownloadLoader();
    let url = `/Reports/DownloadGrievancesPdf?id=${id}`;
    pdfDownloadBase(url);

}

function pdfDownloadBase(url) {
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok.');
            }
            const fileName = response.headers.get('File-Name') || 'download.pdf';
            return response.blob().then(blob => ({ blob, fileName }));
        })
        .then(({ blob, fileName }) => {
            var link = document.createElement('a');
            link.href = URL.createObjectURL(blob);
            link.download = fileName;
            document.body.appendChild(link);
            link.click();

            link.remove();
            hideReportDownloadLoader();
        })
        .catch(error => {
            console.error('Error fetching the PDF:', error);
            hideReportDownloadLoader();
        });
}

function downloadOTJJMPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadOTJJMPdf?id=${id}`;
    pdfDownloadBase(url);
}



function downloadOTJJMPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadOTJJMPdf?id=${id}`;
    pdfDownloadBase(url);

}

function downloadHMPdfclicked(id) {
    showReportDownloadLoader();
    let url = window.location.href = `/Reports/DownloadHMPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadMMPdfclicked(id) {
    showReportDownloadLoader();
    let url = window.location.href = `/Reports/DownloadMMPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadIPPdfclicked(id) {
    showReportDownloadLoader();
    let url = window.location.href = `/Reports/DownloadIPPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadCIPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadCIPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadCMGGYPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadCMGGYPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadRVEDDGPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadRVEDDGPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadOTRVEDDGPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadOTRVEDDGPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadOGPPPdfclicked(id) {
    showReportDownloadLoader();
    let url = `/Reports/DownloadOGPPPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadBioGasclicked(id) {
    showReportDownloadLoader();
    let url = window.location.href = `/Reports/DownloadBGPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadSSYclicked(id) {
    showReportDownloadLoader();
    let url = window.location.href = `/Reports/DownloadSSYPdf?id=${id}`;
    pdfDownloadBase(url);
}

function downloadSSYIPclicked(id) {
    window.location.href = `/Reports/DownloadSSYIPPdf?id=${id}`;
    //showReportDownloadLoader();
    //let url = `/Reports/DownloadSSYIPPdf?id=${id}`;
    //pdfDownloadBase(url);
}

// Triggered when a date is selected from the date picker
function startDatePickerChanged(input) {
    if (!input.disabled) {
        SearchGrievancesList();
    }
}
function endDatePickerChanged(input) {
    if (!input.disabled) {
        SearchGrievancesList();
    }
}
function dateFilterClicked(checkbox) {
    var isChecked = checkbox.checked;

    // Enable or disable date pickers based on checkbox state
    document.getElementById('StartDate').disabled = !isChecked;
    document.getElementById('EndDate').disabled = !isChecked;

    // Call the appropriate function based on the checkbox state
    if (isChecked) {
        SearchGrievancesList();
    } else {
        SearchGrievancesList();
    }
}
