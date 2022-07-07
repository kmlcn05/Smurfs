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
    var j = 0;
    document.getElementById('proje').innerHTML = Object.keys(data).length;
    document.getElementById('projeno').innerHTML = data[0].jiraProjectNo;
    document.getElementById('projead').innerHTML = data[0].jiraProjectName;
    document.getElementById('dzdstatu').innerHTML = data[0].dZDStatus;

    data.forEach(x => {
        if (x.dZDStatus == "14 - Salesforce Fatura Talebi"
            || x.dZDStatus == "15 - Salesforce Fatura Onay"
            || x.dZDStatus == "16 - DZD e-Fatura"
            || x.dZDStatus == "17 - DZD Finans OK") {
            i++;
        }
        data.forEach(x => {
            if (x.dZDStatus == "XX - Banka Proje IPTAL") {
                j++;
            }
            document.getElementById('ProjeTam').innerHTML = i;
            document.getElementById('ProjeIptal').innerHTML = j;
            document.getElementById('ProjeDevam').innerHTML = Object.keys(data).length - (i + j);
        });
    })
}),

    $.ajax({
        'url': "https://smuhammetulas.com/api/Call/GetCall",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (data) {
        var i = 0;
        var j = 0;
        document.getElementById('call').innerHTML = Object.keys(data).length;

        data.forEach(x => {
            if (x.callStatus == "Closed") {
                i++;
            }
            else if (x.callStatus == "Waiting For Customer") {
                j++;
            }
        });
        document.getElementById('callTam').innerHTML = i;
        document.getElementById('callbeklemede').innerHTML = j;
        document.getElementById('calldevam').innerHTML = Object.keys(data).length - (i + j);
        document.getElementById('taskType').innerHTML = data[0].taskType;
        document.getElementById('calldetay').innerHTML = data[0].callDetails;
        document.getElementById('oncelik').innerHTML = data[0].callPriority;
    })
