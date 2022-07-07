
var projeCarpani = null;
var callCarpani = null;

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

    $('#premiumDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "premiumDate" },
            { "data": "name" },
            { "data": "surname" },
            { "data": "amount" },
            { "data": "projectamount" },
            { "data": "callamount" },
        ]
    })
})


$.ajax({
    'url': "https://smuhammetulas.com/api/ProjectParameters/GetProjectParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        projeCarpani = x.projeCarpani;
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/CallParameters/GetCallParameters",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        callCarpani = x.callCarpani;
    });
})


//function ConfirmPremiums() {

//    $.ajax({
//        'url': "https://smuhammetulas.com/api/Premium/GetPremium",
//        'method': "GET",
//        'contentType': 'application/json'
//    }).done(function (data) {
//        data.forEach(x => {

//            $.ajax({
//                'url': "https://smuhammetulas.com/api/ProjectParameters/Calculate",
//                type: "POST",
//                dataType: "json",
//                contentType: "application/json; charset=utf-8",
//                data: JSON.stringify({
//                    x
//                }),
//                success: function () {

//                    alert("Kayıt Başarılı");
//                    window.location.reload()
//                },
//                error: function () {
//                    alert("Error please try again");
//                    window.location.reload()
//                }

//            });
//        })
//    })
   
//}


function Calculate() {

    CalculateProject(projeCarpani);

    CalculateCall(callCarpani);
}

function CalculateProject(projeCarpani) {
    $.ajax({
        'url': "https://smuhammetulas.com/api/ProjectParameters/Calculate",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            projeCarpani
        }),
        success: function () {

            alert("Kayıt Başarılı");
        },
        error: function () {
            alert("Error please try again");
            window.location.reload()
        }

    });
}

function CalculateCall(callCarpani) {
    $.ajax({
        'url': "https://smuhammetulas.com/api/CallParameters/CalculateCall",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            callCarpani
        }),
        success: function () {

            alert("Kayıt Başarılı");
        },
        error: function () {
            alert("Error please try again");
            window.location.reload()
        }

    });
}

