
var allData = null;
var id = null;
var date = null;
date = new Date().toJSON();
var name = null;
var surname = null;
var expected = 0;
var happening = 0;
var remainder = 0;


function reloadPage() {
    document.getElementById('newpremium').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/Premium/GetPremium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {

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
}).done(function (dataprojects) {
    GetProjects(dataprojects);
})

function GetProjects(datauser) {

    for (var y of datauser) {

        expected = (new Date().getMonth() - new Date(y.dateOfStart).getMonth()) * 20;

        fetch("https://smuhammetulas.com/api/Project/GetProjects").then(response => response.json()).then(data => {

            if (data.developer == y.name + " " + y.surname) {
                var alldata = data.filter(x => x.developer == y.name + " " + y.surname)
                alldata.forEach(x => {
                    happening += parseInt(x.developerhappening);
                });
            }
            else if (data.analyst == y.name + " " + y.surname) {
                var dataall = data.filter(x => x.analyst == y.name + " " + y.surname)
                dataall.forEach(x => {
                    happening += parseInt(x.analysthappening);
                });
            }
            remainder = expected - happening;

            $('#employeeDatatable').append(`<tr>
                                            <td>${y.id}</td>    
                                            <td>${y.name}</td>     
                                            <td>${y.surname}</td>    
                                            <td>${expected}</td>     
                                            <td>${happening}</td>     
                                            <td>${remainder}</td>
                                            </tr>`);     
            
            happening = 0;
            remainder = 0;
            expected = 0;
        })
    }
}


