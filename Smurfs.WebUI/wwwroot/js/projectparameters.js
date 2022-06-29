
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
        $('#Project').append(`<option value="${x.name}">${x.name}</option>`)
    });
})

$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

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
    }
});



$(document).on('click', '.Save', function () {
    if (id == null) {

        name = $('#Name').val();
        parametersDate = $('#ParametersDate').val();
        project = $("#Call option:selected").text();
        projeCarpani = $('#CallCarpani').val();
        projeKapasite = $('#CallKapasite').val();
        projeGerceklesen = $('#CallGerceklesen').val();
        projeVerimYuzdesi = $('#CallVerimYuzdesi').val();
        projeVerimDegeri = $('#CallVerimDegeri').val();
        projeVerimSonucu = $('#CallVerimSonucu').val();

        if (id == null) {
            if (name == "Bir Değer Seçiniz" || parametersDate == "" || project == "Bir Değer Seçiniz" || projeCarpani == ""
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
        else {
            return false;
        }
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

        name = allData.find(x => x.id == parseInt(id)).Name;
        parametersDate = allData.find(x => x.id == parseInt(id)).parametersDate;
        project = allData.find(x => x.id == parseInt(id)).project;
        projeCarpani = allData.find(x => x.id == parseInt(id)).projeCarpani;
        projeKapasite = allData.find(x => x.id == parseInt(id)).projeKapasite;
        projeGerceklesen = allData.find(x => x.id == parseInt(id)).projeGerceklesen;
        projeVerimYuzdesi = allData.find(x => x.id == parseInt(id)).projeVerimYuzdesi;
        projeVerimDegeri = allData.find(x => x.id == parseInt(id)).projeVerimDegeri;
        projeVerimSonucu = allData.find(x => x.id == parseInt(id)).projeVerimSonucu;

        document.getElementById('newprojectparameters').style.display = 'block';

        $('#Name').val(name).html();
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