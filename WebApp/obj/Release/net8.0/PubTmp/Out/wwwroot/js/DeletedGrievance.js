
function getDeletedGrievanceList() {
    console.log("Deleted Grievance Called");
    $.ajax({
        url: "/Administrator/DeletedGrievanceList",
        method:"GET",
        dataType: "html",
        success: function (response) {
            $('#deletedGrievancePartialView').html(response);
            $('#deletedGrievanceTable').DataTable({
                "pageLength": 10,
                "lengthMenu": [5, 10, 25, 50, 100],
                "ordering": true,
                "searching": true,
                "info": true,
                "autoWidth": false
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching grievances:", error);
        }

    })
}