function saveProjects() {
    var fileInput = document.getElementById('DBImportProject');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportProject',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}
function saveSites() {
    var fileInput = document.getElementById('DBImportSite');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportSite',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}
function saveSitesAndProjects() {
    var fileInput = document.getElementById('DBImportSitesAndProjects');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportSiteAndProject',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}
function saveDistrict() {
    var fileInput = document.getElementById('DBImportDistrict');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportDistrict',
            type: 'POST',
            data: formData,
            processData: false, 
            contentType: false, 
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}
function saveBlock() {
    var fileInput = document.getElementById('DBImportBlock');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportBlock',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}
function saveVillage() {
    var fileInput = document.getElementById('DBImportVillage');
    if (fileInput.files.length > 0) {
        var formData = new FormData();
        formData.append('file', fileInput.files[0]);
        $.ajax({
            url: '/Imports/ImportVillage',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                alert("Inserted");
            },
            error: function (xhr, status, error) {
                console.error('Request failed with status:', status);
            }
        });
    } else {
        alert('Please select a file.');
    }
}