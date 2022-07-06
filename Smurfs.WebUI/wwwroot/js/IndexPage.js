
    var hamburger=document.querySelector(".hamburger");
    hamburger.addEventListener("click",function(){
        document.querySelector("body").classList.toggle("active")
    })

var username = null;
username = $('#username').text();
fetch("https://smuhammetulas.com/api/Project/GetProjects").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.developer == username || x.analyst == username)
    var i = 0;
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
        
    });
    document.getElementById('projetam').innerHTML = i;

})



var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Call/GetCall").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.appointee == username)
    var i = 0;
    document.getElementById('call').innerHTML = Object.keys(alldata).length;
    document.getElementById('taskType').innerHTML = alldata[0].taskType;
    document.getElementById('calldetay').innerHTML = alldata[0].callDetails;
    document.getElementById('oncelik').innerHTML = alldata[0].callPriority;
    
    alldata.forEach(x => {
        if (x.callStatus == "Closed") {
            i++;
        }
        
       
    });

    document.getElementById('calltam').innerHTML = i;

})

var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/User/GetUser").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.name+" "+x.surname == username)

    alldata.forEach(x => {
       
        document.getElementById('takim').innerHTML = x.team;
    });



})

var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Premium/GetPremium").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.name + " " + x.surname == username)
    if (Object.keys(alldata).length==0) {
        document.getElementById('prim').innerHTML = 0 + " TL";
    }
    alldata.forEach(x => {
        if (parseInt(x.amount) > 0) {
            document.getElementById('renk').classList = "w3-container w3-green w3-padding-16";
            document.getElementById('prim').innerHTML = parseInt(x.amount) + " TL";
        }
        
            
    });

})




