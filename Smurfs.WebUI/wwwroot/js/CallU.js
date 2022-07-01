
var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Call/GetCall").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.appointee == username)

    $('#CallDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": alldata,
        "scrollX": true,
        "columns": [
            { "data": "id" },
            { "data": "bank" },
            { "data": "taskType" },
            { "data": "jiraTaskNo" },
            { "data": "callName" },
            { "data": "cagriCozumSuresi" },
            { "data": "callDetails" },
            { "data": "callPriority" },
            { "data": "callDateCreated" },
            { "data": "callDateResolved" },
            { "data": "callStatus" },
            { "data": "appointee" },
            { "data": "reporter" }
        ]
    })

})




