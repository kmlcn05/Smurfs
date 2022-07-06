
var allData = null;
var id = null;
var bankname = null;

var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];

function reloadPage() {
    document.getElementById('newbank').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/Bank",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#bankDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "bankName" },

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
        bankname = allData.find(x => x.id == parseInt(id)).bankName;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Bank/" + id,
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
        pagelog = bankname + " isimli banka silindi";
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
    if (id == null) {
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {
            var bankname = $('#BankName').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/Bank",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "bankName": bankname
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
        pagelog = bankname + " isimli banka eklendi";
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

            bankname = $('#BankName').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/Bank",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "bankName": bankname
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
        pagelog = bankname + " isimli banka güncellendi";
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
        bankname = allData.find(x => x.id == parseInt(id)).bankName;

        document.getElementById('newbank').style.display = 'block';
        $('#BankName').val(bankname).html();

    }
});