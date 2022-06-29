
var allData = null;
var id = null;
var processName = null;

$.ajax({
    'url': "https://smuhammetulas.com/api/Process",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#processDatatable').dataTable({
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "processName" },

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
                url: "https://smuhammetulas.com/api/Process/" + id,
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

        if (processname == "") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }

        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {
            var processname = $('#ProcessName').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/Process",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "processName": processname
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

            processname = $('#ProcessName').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/Process",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "ProcessName": processname
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
        processname = allData.find(x => x.id == parseInt(id)).processName;

        document.getElementById('newprocess').style.display = 'block';
        $('#ProcessName').val(processname).html();

    }
});