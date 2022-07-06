
var allData = null;
var id = null;
var parametersDate = null;
var callCarpani = null;


var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];



$.ajax({
    'url': "https://smuhammetulas.com/api/CallParameters/GetCallParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    for (var x of data) {
        x.parametersDate = x.parametersDate.replace("T00:00:00", "");       
    }

    $('#callparameter').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "scrollX": true,
        "columns": [
            { "data": "id" },
            { "data": "parametersDate" },
            { "data": "callCarpani" },

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
//    'url': "https://smuhammetulas.com/api/Call/GetCall",
//    'method': "GET",
//    'contentType': 'application/json'
//}).done(function (data) {
//    data.forEach(x => {
//        $('#Call').append(`<option value="${x.callName}">${x.callName}</option>`)
//    });
//})

$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {

        var id = e.target.dataset.id;
        call = allData.find(x => x.id == parseInt(id)).call;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/CallParameters/" + id,
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
        pagelog = call + " isimli ITSM için parametreler silindi";
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
    callCarpani = $('#CallCarpani').val();


    if (id == null) {
        if (parametersDate == "" || callCarpani == "") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {


            $.ajax({
                url: "https://smuhammetulas.com/api/CallParameters/CreateCallParameters",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "parametersDate": parametersDate,
                    "callCarpani": callCarpani,

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
        pagelog = call + " isimli ITSM için parametreler eklendi";
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
                url: "https://smuhammetulas.com/api/CallParameters/UpdateCallParameters",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "id": id,
                    "parametersDate": parametersDate,
                    "callCarpani": callCarpani,

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
        pagelog = call + " isimli ITSM için parametreler güncellendi";
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
        callCarpani = allData.find(x => x.id == parseInt(id)).callCarpani;

        document.getElementById('newcallparameter').style.display = 'block';

        $('#ParametersDate').val(parametersDate);
        $('#CallCarpani').val(callCarpani);

    }
});