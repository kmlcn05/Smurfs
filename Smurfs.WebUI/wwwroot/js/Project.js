
var allData = null;
$.ajax({
    'url': "https://smuhammetulas.com/api/Project",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#bankDatatable').dataTable({
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "projectDate" },
            { "data": "bank" },
            { "data": "jiraProjectNo" },
            { "data": "jiraTaskNo" },
            { "data": "jiraProjectName" },
            { "data": "dZDStatus" },
            { "data": "status" },
            { "data": "department" },
            { "data": "team" },
            { "data": "developer" },
            { "data": "analyst" },
            { "data": "totalManDay" },
            { "data": "developerManDay" },
            { "data": "analystManDay" },
            { "data": "pmManDay" },

            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-danger Delete' data-id='" + row.id + "' >Delete</button>";
                }
            },
            {
                "render": function (data, row) {
                    return "<button onclick= 'newbankupdate()' class= 'btn btn-info Update' id= 'Update'>Update</button>";
                }

            },

        ]
    })
})


//$(document).ready(function () {
//    $('#ProjectDatatable').dataTable({
//        scrollX: true,
//    });

//    $.ajax({
//        'url': "https://smuhammetulas.com/api/Bank",
//        'method': "GET",
//        'contentType': 'application/json'
//    }).done(function (data) {
//        data.forEach(x => {
//            $('#bankDropdown').append(`<option value="1">${x.bankName}</option>`)
//        });       
//    })

//    //

//});

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


