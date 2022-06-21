$(document).ready(function () {
    $('#ProjectDatatable').dataTable({
        scrollX: true,
    });
});

//$.ajax({
//    'url': "https://smuhammetulas.com/api/Project",
//    'method': "GET",
//    'contentType': 'application/json'
//}).done(function (data) {
//    $('#ProjectDatatable').dataTable({
//        "aaData": data,
//        "columns": [
//            { "data": "id" },
//            { "data": "bankName" },

//            {
//                "render": function (data, row) { return "<button class='btn btn-danger Delete' data-id=('" + row.id + "'); >Delete</button>"; }
//            },
//            {
//                "render": function (data, row) { return "<button  class='btn btn-info Update' > Update</button>"; }

//            },

//        ]
//    })
//})

//to delete
$(document).on('click', '.Delete', function () {

    var Confirm = confirm("Are you sure, do you want to delete it?");
    if (Confirm) {
        var id = $(this).attr('data-id');
        $.ajax({
            url: "https://smuhammetulas.com/api/Bank",
            type: "Delete",
            dataType: "json",
            data: {
                "id": id,
                "bankName": bankName
            },
            success: function () {

                alert("silindi");
                //reload jquery datatable
                $customerDatatable.api().ajax.reload();


            },
            error: function () {
                alert("Error please try again");
            }

        })

    }
    else {
        return false;
    }
});


