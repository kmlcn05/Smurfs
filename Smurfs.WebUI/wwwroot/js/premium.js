
var allData = null;
var id = null;
var amount = null;
var premiumDate = null;
var users = null;

$.ajax({
    'url': "https://smuhammetulas.com/api/Premium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    for (var x of data) {
        x.premiumDate = x.premiumDate.replace("T00:00:00", "");
    }

    $('#premiumDatatable').dataTable({
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "amount" },
            { "data": "premiumDate" },
            { "data": "users" },
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
    'url': "https://smuhammetulas.com/api/User/GetUser",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Users').append(`<option value="${x.name}">${x.name}</option>`)
    });
})

$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Premium/" + id,
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

    amount = $('#Amount').val();
    premiumDate = $('#PremiumDate').val();
    users = $("#Users option:selected").text();

    if (id == null) {
        if (amount == "Bir Değer Seçiniz" || premiumDate == "" || users == "Bir Değer Seçiniz") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {
            
            $.ajax({
                url: "https://smuhammetulas.com/api/Premium",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "amount": amount,
                    "premiumDate": premiumDate,
                    "users": users
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

            
            amount = $('#Amount').val();
            premiumDate = $('#PremiumDate').val();
            users = $("#Users option:selected").text();

            $.ajax({
                url: "https://smuhammetulas.com/api/Premium",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "id": id,
                    "amount": amount,
                    "premiumDate": premiumDate,
                    "users": users
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
    }

});



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;

        amount = allData.find(x => x.id == parseInt(id)).amount;
        premiumDate = allData.find(x => x.id == parseInt(id)).premiumDate;
        users = allData.find(x => x.id == parseInt(id)).users;

        document.getElementById('newpremium').style.display = 'block';

        $('#Amount').val(amount).html();
        $('#PremiumDate').val(premiumdate).html();
        $('#Users').val(users).html();

    }
});