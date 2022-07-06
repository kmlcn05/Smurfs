
var allData = null;
var id = null;
var parametersDate = null;
var projeCarpani = null;


var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];

function reloadPage() {
    document.getElementById('newprojectparameter').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/ProjectParameters/GetProjectParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    $('#projectparametersDatatable').dataTable({
        scrollX : true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "parametersDate" },
            { "data": "projeCarpani" },


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

//$.ajax({
//    'url': "https://smuhammetulas.com/api/Project/GetProjects",
//    'method': "GET",
//    'contentType': 'application/json'
//}).done(function (data) {
//    data.forEach(x => { 
//        $('#Project').append(`<option value="${x.jiraProjectName}">${x.jiraProjectName}</option>`)
//    });
//})


$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;
        project = allData.find(x => x.id == parseInt(id)).project;
        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/" + id,
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
        pagelog = project + " isimli projenin parametreleri silindi";
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

        parametersDate = $('#ParametersDate').val();
        projeCarpani = $('#ProjeCarpani').val();


        if (id == null) {
            if (parametersDate == "" || projeCarpani == "") {

                document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
                return false;
            }
            var Confirm = confirm("Kayıt yapılsın mı?");
            if (Confirm) {


            $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/CreateProjectParameters",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "parametersDate": parametersDate,
                    "projeCarpani": projeCarpani,

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
            pagelog = project + " isimli projenin parametreleri eklendi";
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

                name = $('#Name').val()

                $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/UpdateProjectParameters",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "id": id,
                    "projeCarpani": projeCarpani,


                }),
                success: function () {

                    //Yenile
                    alert("The record is updated.");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload()
                }

            })

            }
            var datetime = new Date().toJSON();
            pagelog = project + " isimli projenin parametreleri güncellendi";
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

        parametersDate = allData.find(x => x.id == parseInt(id)).parametersDate;
        projeCarpani = allData.find(x => x.id == parseInt(id)).projeCarpani;

        document.getElementById('newprojectparameter').style.display = 'block';

        $('#ParametersDate').val(parametersDate);
        $('#ProjeCarpani').val(projeCarpani);

    }
});