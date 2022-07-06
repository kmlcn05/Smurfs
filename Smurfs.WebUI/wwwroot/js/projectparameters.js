
var allData = null;
var id = null;
var projeCarpani = null;

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

        projeCarpani = $('#ProjeCarpani').val();

        if (id == null) {
            if (projeCarpani == "") {

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
    }

});



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;

        projeCarpani = allData.find(x => x.id == parseInt(id)).projeCarpani;

        document.getElementById('newprojectparameter').style.display = 'block';

        $('#ProjeCarpani').val(projeCarpani);

    }
});