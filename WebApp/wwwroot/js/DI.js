
function ABCList() {
    var aa = 0;
    showLoader();

    $.ajax({
        url: '/DIAction/TestAbc',
        dataType: 'html',
        success: function (response) {
            $('#ReportPartialView').html('');
            $('#ReportPartialView').html(response); 
            hideLoader();
        },
        error: function (xhr, status, error) {
        }
    });
}


