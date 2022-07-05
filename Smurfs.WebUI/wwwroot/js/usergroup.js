
var allData = null;
var id = null;
var groupName = null;

var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];

function reloadPage() {
    document.getElementById('newusergroup').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/UserGroup",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#usergroupDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "groupName" },

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
        groupName = allData.find(x => x.id == parseInt(id)).groupName;
        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/UserGroup/" + id,
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
        pagelog = groupName + " isimli grup silindi";
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

        if (groupname == "") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }

        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {
            var groupname = $('#GroupName').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/UserGroup",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "groupName": groupname
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
        pagelog = groupName + " isimli grup eklendi";
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

            groupname = $('#GroupName').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/UserGroup",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "groupName": groupname
                }),
                success: function () {

                    //Yenile
                    alert("This record is updated");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload()
                }

            })

        }
        var datetime = new Date().toJSON();
        pagelog = groupName + " isimli grup güncellendi";
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
        groupname = allData.find(x => x.id == parseInt(id)).groupName;

        document.getElementById('newusergroup').style.display = 'block';
        $('#GroupName').val(groupname).html();

    }
});