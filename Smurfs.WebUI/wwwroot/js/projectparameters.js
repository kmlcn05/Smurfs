
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
    'url': "https://smuhammetulas.com/api/ProjectParameters/GetAllProjectParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
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



$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/GetAllProjectParameters/" + id,
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
            var projectparametersname = $('#ProjectParametersName').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/GetAllProjectParameters",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "projectparametersName": projectparametersname
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

            projectparametersname = $('#ProjectParametersName').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/ProjectParameters/GetAllProjectParameters",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "projectparametersName": projectparametersname
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
        projectparametersname = allData.find(x => x.id == parseInt(id)).projectparametersName;

        document.getElementById('newprojectparameters').style.display = 'block';
        $('#ProjectparametersName').val(projectparametersname).html();

    }
});