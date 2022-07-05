﻿
var allData = null;
var id = null;
var name = null;
var parametersDate = null;
var project = null;
var projeCarpani = null;
var projeKapasite = null;
var projeGerceklesen = null;
var projeVerimYuzdesi = null;
var projeVerimDegeri = null;
var projeVerimSonucu = null;

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

    for (var x of data) {
        x.parametersDate = x.parametersDate.replace("T00:00:00", "");
    }

    $('#projectparametersDatatable').dataTable({
        scrollX : true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "parametersDate" },
            { "data": "project" },
            { "data": "projeCarpani" },
            { "data": "projeKapasite" },
            { "data": "projeGerceklesen" },
            { "data": "projeVerimYuzdesi" },
            { "data": "projeVerimDegeri" },
            { "data": "projeVerimSonucu" },

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

$.ajax({
    'url': "https://smuhammetulas.com/api/Project/GetProjects",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => { 
        $('#Project').append(`<option value="${x.jiraProjectName}">${x.jiraProjectName}</option>`)
    });
})


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


        name = $('#Name').val();
        parametersDate = $('#ParametersDate').val();
        project = $("#Project option:selected").text();
        projeCarpani = $('#ProjeCarpani').val();
        projeKapasite = $('#ProjeKapasite').val();
        projeGerceklesen = $('#ProjeGerceklesen').val();
        projeVerimYuzdesi = $('#ProjeVerimYuzdesi').val();
        projeVerimDegeri = $('#ProjeVerimDegeri').val();
        projeVerimSonucu = $('#ProjeVerimSonucu').val();

        if (id == null) {
            if (name == "" || parametersDate == "" || project == "Bir Değer Seçiniz" || projeCarpani == ""
                || projeKapasite == "" || projeGerceklesen == "" || projeVerimYuzdesi == "" || projeVerimDegeri == ""
                || projeVerimSonucu == "") {

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

                    "name": name,
                    "parametersDate": parametersDate,
                    "project": project,
                    "projeCarpani": projeCarpani,
                    "projeKapasite": projeKapasite,
                    "projeGerceklesen": projeGerceklesen,
                    "projeVerimYuzdesi": projeVerimYuzdesi,
                    "projeVerimDegeri": projeVerimDegeri,
                    "projeVerimSonucu": projeVerimSonucu,

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
                    "name": name,
                    "parametersDate": parametersDate,
                    "project": project,
                    "projeCarpani": projeCarpani,
                    "projeKapasite": projeKapasite,
                    "projeGerceklesen": projeGerceklesen,
                    "projeVerimYuzdesi": projeVerimYuzdesi,
                    "projeVerimDegeri": projeVerimDegeri,
                    "projeVerimSonucu": projeVerimSonucu,

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

        name = allData.find(x => x.id == parseInt(id)).name;
        parametersDate = allData.find(x => x.id == parseInt(id)).parametersDate;
        project = allData.find(x => x.id == parseInt(id)).project;
        projeCarpani = allData.find(x => x.id == parseInt(id)).projeCarpani;
        projeKapasite = allData.find(x => x.id == parseInt(id)).projeKapasite;
        projeGerceklesen = allData.find(x => x.id == parseInt(id)).projeGerceklesen;
        projeVerimYuzdesi = allData.find(x => x.id == parseInt(id)).projeVerimYuzdesi;
        projeVerimDegeri = allData.find(x => x.id == parseInt(id)).projeVerimDegeri;
        projeVerimSonucu = allData.find(x => x.id == parseInt(id)).projeVerimSonucu;

        document.getElementById('newprojectparameter').style.display = 'block';

        $('#Name').val(name);
        $('#ParametersDate').val(parametersDate);
        $('#Project').val(project);
        $('#ProjeCarpani').val(projeCarpani);
        $('#ProjeKapasite').val(projeKapasite);
        $('#ProjeGerceklesen').val(projeGerceklesen);
        $('#ProjeVerimYuzdesi').val(projeVerimYuzdesi);
        $('#ProjeVerimDegeri').val(projeVerimDegeri);
        $('#ProjeVerimSonucu').val(projeVerimSonucu);
    }
});