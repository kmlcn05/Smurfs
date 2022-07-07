var hamburger = document.querySelector(".hamburger");
hamburger.addEventListener("click", function () {
    document.querySelector("body").classList.toggle("active")
})

var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Project/GetProjects").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.analyst == username || x.developer == username)
    var i = 0;
    var j = 0;

    document.getElementById('proje').innerHTML = Object.keys(alldata).length;
    document.getElementById('projeno').innerHTML = alldata[0].jiraProjectNo;
    document.getElementById('projead').innerHTML = alldata[0].jiraProjectName;
    document.getElementById('dzdstatu').innerHTML = alldata[0].dZDStatus;

    alldata.forEach(x => {
        if (x.dZDStatus == "14 - Salesforce Fatura Talebi"
            || x.dZDStatus == "15 - Salesforce Fatura Onay"
            || x.dZDStatus == "16 - DZD e-Fatura"
            || x.dZDStatus == "17 - DZD Finans OK") {
            i++;
        }

        if (x.dZDStatus == "XX - Banka Proje IPTAL") {
            j++;
        }

    });

    document.getElementById('ProjeTam').innerHTML = i;
    document.getElementById('ProjeIptal').innerHTML = j;
    document.getElementById('ProjeDevam').innerHTML = Object.keys(alldata).length - (i + j);
    /*<script>*/
    var tamamlandi = parseInt(document.getElementById("ProjeTam").innerHTML);
    var devamediyor = parseInt(document.getElementById("ProjeDevam").innerHTML);
    var iptal = parseInt(document.getElementById("ProjeIptal").innerHTML);
    var tamamlandi2 = (tamamlandi / (tamamlandi + devamediyor + iptal)) * 100;
    var tamamlandi3 = parseInt(tamamlandi2);
    var devamediyor2 = (devamediyor / (tamamlandi + devamediyor + iptal)) * 100;
    var devamediyor3 = parseInt(devamediyor2);
    var iptal2 = (iptal / (tamamlandi + devamediyor + iptal)) * 100;
    var iptal3 = parseInt(iptal2);

    var xValues = ["Tamamlandı", "Devam Ediyor", "İptal"];
    var yValues = [tamamlandi3, devamediyor3, iptal3];
    var barColors = ["green", "orange", "red"];

    new Chart("myChart", {
        type: "horizontalBar",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: barColors,
                data: yValues
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                //text: "World Wine Production 2018"
            },
            scales: {
                xAxes: [{ ticks: { min: 0, max: 200 } }]
            }
        }
    });
    /* </script>*/

})



var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Call/GetCall").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.appointee == username)
    var i = 0;
    var j = 0;

    document.getElementById('call').innerHTML = Object.keys(alldata).length;


    alldata.forEach(x => {
        if (x.callStatus == "Closed") {
            i++;
        }
        else if (x.callStatus == "Waiting For Customer") {
            j++;
        }

    });

    document.getElementById('calltam').innerHTML = i;
    document.getElementById('callbeklemede').innerHTML = j;
    document.getElementById('calldevam').innerHTML = Object.keys(alldata).length - (i + j);
    document.getElementById('taskType').innerHTML = alldata[0].taskType;
    document.getElementById('calldetay').innerHTML = alldata[0].callDetails;
    document.getElementById('oncelik').innerHTML = alldata[0].callPriority;


})

var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/User/GetUser").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.name + " " + x.surname == username)

    alldata.forEach(x => {

        document.getElementById('takim').innerHTML = x.team;
    });



})

var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Premium/GetPremium").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.name + " " + x.surname == username)
    if (Object.keys(alldata).length == 0) {
        document.getElementById('prim').innerHTML = 0 + " TL";
    }
    alldata.forEach(x => {
        if (parseInt(x.amount) > 0) {
            document.getElementById('renk').classList = "w3-container w3-green w3-padding-16";
            document.getElementById('prim').innerHTML = parseInt(x.amount) + " TL";
        }


    });

})




