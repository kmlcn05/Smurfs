
var allData = null;
var id = null;
var callStatusName = null;


$.ajax({
    'url': "https://smuhammetulas.com/api/CallStatus",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#callStatusDatatable').dataTable({
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "callStatusName" },

            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-danger Delete' data-id='" + row.id + "' >Delete</button>";
                }
            },
            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-info Update' data-id='" + row.id + "' >Update</button>";
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
                url: "https://smuhammetulas.com/api/CallStatus/" + id,
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



$(document).on('click', '.Save', function () {
    if (id == null) {
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {
            var callStatusName = $('#callStatusName').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/CallStatus",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "callStatusName": callStatusName
                }),
                success: function () {

                    alert("Kayıt Başarılı");
                    window.location.reload()
                },
                error: function () {
                    alert("Error please try again");
                    window.location.reload()
                }

            })

        }
        else {
            return false;
        }
    }
    else {
        var Confirm = confirm("Are you sure, do you want to update it?");
        if (Confirm) {

            callStatusName = $('#callStatusName').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/CallStatus",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "callStatusName": callStatusName
                }),
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



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;
        callStatusName = allData.find(x => x.id == parseInt(id)).callStatusName;

        document.getElementById('newcallStatusName').style.display = 'block';
        $('#callStatusName').val(callStatusName).html();

    }
});