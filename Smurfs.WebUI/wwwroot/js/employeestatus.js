
var allData = null;
var id = null;
var date = null;
date = new Date().toJSON();
var name = null;
var surname = null;
var expected = null;
var happening = null;
var remainder = null;

function reloadPage() {
    document.getElementById('newpremium').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/Premium/GetPremium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    for (var x of data) {
        x.premiumDate = x.premiumDate.replace("T00:00:00", "");
    }
    for (var x of data) {
        x.amount = x.amount.replace(".00", "");
    }

    $('#employeeDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "date" },
            { "data": "name" },
            { "data": "surname" },
            { "data": "expected" },
            { "data": "happening" },
            { "data": "remainder" },

        ]
    })
})

$.ajax({
    'url': "https://smuhammetulas.com/api/User/GetUser",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Users').append(`<option value="${x.name + ' ' + x.surname}">${x.name} ${x.surname}</option>`);
    });
})

//$(document).on('click', '.Delete', function (e) {
//    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
//        var id = e.target.dataset.id;

//        var Confirm = confirm("Are you sure, do you want to delete it?");
//        if (Confirm) {

//            $.ajax({
//                url: "https://smuhammetulas.com/api/Premium/" + id,
//                type: "DELETE",
//                dataType: "json",
//                contentType: "application/json; charset=utf-8",
//                success: function () {

//                    //Yenile
//                    alert("silindi");
//                    window.location.reload()


//                },
//                error: function (e) {
//                    alert("Error please try again" + JSON.stringify(e));
//                    window.location.reload()
//                }

//            })

//        }
//    }
//});



//$(document).on('click', '.Save', function () {

//    amount = $('#Amount').val();
//    premiumDate = $('#PremiumDate').val();
//    var users = $("#Users option:selected").text();
//    var array = users.split(' ');
//    name = array[0];
//    surname = array[1];


//    if (id == null) {
//        if (amount == "" || premiumDate == "" || users == "Bir Değer Seçiniz") {

//            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
//            return false;
//        }
//        var Confirm = confirm("Kayıt yapılsın mı?");
//        if (Confirm) {

//            $.ajax({
//                url: "https://smuhammetulas.com/api/Premium",
//                type: "POST",
//                dataType: "json",
//                contentType: "application/json; charset=utf-8",
//                data: JSON.stringify({

//                    "amount": amount,
//                    "premiumDate": premiumDate,
//                    "name": name,
//                    "surname": surname
//                }),
//                success: function () {

//                    alert("Kayıt Başarılı");
//                    window.location.reload()
//                },
//                error: function () {
//                    alert("Error please try again");
//                    window.location.reload()
//                }

//            })

//        }
//        else {
//            return false;
//        }
//    }
//    else {
//        var Confirm = confirm("Are you sure, do you want to update it?");
//        if (Confirm) {

//            $.ajax({
//                url: "https://smuhammetulas.com/api/Premium",
//                type: "PUT",
//                dataType: "json",
//                contentType: "application/json; charset=utf-8",
//                data: JSON.stringify({

//                    "id": id,
//                    "amount": amount,
//                    "premiumDate": premiumDate,
//                    "name": name,
//                    "surname": surname
//                }),
//                success: function () {

//                    //Yenile
//                    alert("The record is updated");
//                    window.location.reload()


//                },
//                error: function (e) {
//                    alert("Error please try again" + JSON.stringify(e));
//                    window.location.reload()
//                }

//            })

//        }
//    }

//});



//$(document).on('click', '.Update', function (e) {
//    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
//        id = e.target.dataset.id;

//        amount = allData.find(x => x.id == parseInt(id)).amount;
//        premiumDate = allData.find(x => x.id == parseInt(id)).premiumDate;
//        name = allData.find(x => x.id == parseInt(id)).name;
//        surname = allData.find(x => x.id == parseInt(id)).surname;
//        users = name + " " + surname;

//        document.getElementById('newpremium').style.display = 'block';

//        $('#Amount').val(amount);
//        $('#PremiumDate').val(premiumDate);
//        $('#Users').val(users);

//    }
//});