

$.ajax({
    'url': "https://smuhammetulas.com/api/GeneralPremium/GetPremium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {

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
            { "data": "projectAmount" },
            { "data": "callAmount" },

        ]
    })
})
