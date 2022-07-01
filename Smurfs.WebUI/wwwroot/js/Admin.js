$.ajax({
    'url': "https://smuhammetulas.com/api/Premium/GetPremium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    var i = 0;
    document.getElementById('prim').innerHTML = Object.keys(data).length;

    data.forEach(x => {
        i++;            
        document.getElementById('primTam').innerHTML = i;
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Premium/GetPremium",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    var toplamamount = 0;
    document.getElementById('prim').innerHTML = Object.keys(data).length;

    data.forEach(x => {

        toplamamount += parseInt(x.amount);

        document.getElementById('topPrimTam').innerHTML = toplamamount + " TL";
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Project/GetProjects",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    var i = 0;
    document.getElementById('proje').innerHTML = Object.keys(data).length;

    data.forEach(x => {
        if (x.dZDStatus == "03-Done") {
            i++;
        }
        document.getElementById('ProjeTam').innerHTML = i;
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Call/GetCall",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    var i = 0;
    document.getElementById('itsm').innerHTML = Object.keys(data).length;

    data.forEach(x => {
        if (x.callStatus == "Closed") {
            i++;
        }
        document.getElementById('itsmTam').innerHTML = i;
    });
})