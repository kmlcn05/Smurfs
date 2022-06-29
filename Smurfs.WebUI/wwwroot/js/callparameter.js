
var allData = null;
var id = null;
var name = null;
var parametersDate = null;
var call = null;
var callCarpani = null;
var callKapasite = null;
var callGerceklesen = null;
var callVerimYuzdesi = null;
var callVerimDegeri = null;
var callVerimSonucu = null;


$.ajax({
    'url': "https://smuhammetulas.com/api/CallParameters/GetAllCallParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#callparameter').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "scrollX": true,
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "parametersDate" },
            { "data": "call" },
            { "data": "callCarpani" },
            { "data": "callKapasite" },
            { "data": "callGerceklesen" },
            { "data": "callVerimYuzdesi" },
            { "data": "callVerimDegeri" },
            { "data": "callVerimSonucu" },

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
                url: "https://smuhammetulas.com/api/CallParameters/GetAllCallParameters" + id,
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
            var name = $('#name').val()
            $.ajax({
                url: "https://smuhammetulas.com/api/CallParameters/GetAllCallParameters",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "name": name
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

            name = $('#name').val()

            $.ajax({
                url: "https://smuhammetulas.com/api/CallParameters/GetAllCallParameters",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "name": name
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
        name = allData.find(x => x.id == parseInt(id)).name;

        document.getElementById('newcallparamater').style.display = 'block';
        $('#name').val(name).html();

    }
});