

$.ajax({
    'url': "https://smuhammetulas.com/api/Log/GetLog",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    //for (var x of data) {
    //    x.logDate = x.logDate.replace("T00:00:00", "");
    //}

    $('#logDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "logDate" },
            { "data": "name" },
            { "data": "surname" },
            { "data": "page" },
            { "data": "process" },

            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-danger Delete' data-id='" + row.id + "' >Delete</button>";
                }
            },
            
        ]
    })
})

$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Log/" + id,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {

                    //Yenile
                    alert("silindi");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload()
                }

            })

        }
    }
});
