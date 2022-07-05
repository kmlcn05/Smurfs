
var allData = null;
var id = null;
var callStatusName = null;

var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];

function reloadPage() {
    document.getElementById('newcallStatus').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/CallStatus" ,
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#callStatusDatatable').dataTable({
        scrollX: true,
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
        callStatusName = allData.find(x => x.id == parseInt(id)).callStatusName;

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
        var datetime = new Date().toJSON();
        pagelog = callStatusName + " isimli ITSM statüsü silindi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Silme"
            }),

            success: function () {

            }
        })
    }
});



$(document).on('click', '.Save', function () {

    var callStatusName = $('#CallStatusName').val()


    if (id == null) {
        if (callStatusName == "") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {

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
        var datetime = new Date().toJSON();
        pagelog = callStatusName + " isimli ITSM statüsü eklendi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Ekleme"
            }),

            success: function () {

            }
        })
    }
    else {
        var Confirm = confirm("Are you sure, do you want to update it?");
        if (Confirm) {

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
                    alert("The record is updated");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload()
                }

            })

        }
        var datetime = new Date().toJSON();
        pagelog = callStatusName + " isimli ITSM statüsü güncellendi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Güncelleme"
            }),

            success: function () {

            }
        })
    }


});



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;
        callStatusName = allData.find(x => x.id == parseInt(id)).callStatusName;

        document.getElementById('newcallStatus').style.display = 'block';
        $('#CallStatusName').val(callStatusName).html();

    }
});