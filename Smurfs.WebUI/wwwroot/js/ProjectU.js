
var username = null;
username = $('#username').text();

fetch("https://smuhammetulas.com/api/Project/GetProjects").then(response => response.json()).then(data => {
    var alldata = data.filter(x => x.developer == username || x.analyst == username)

    $('#ProjectUDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": alldata,
        "scrollX": true,
        "columns": [
            { "data": "id" },
            { "data": "projectDate" },
            { "data": "bank" },
            { "data": "jiraProjectNo" },
            { "data": "jiraTaskNo" },
            { "data": "jiraProjectName" },
            { "data": "dZDStatus" },
            { "data": "status" },
            { "data": "department" },
            { "data": "team" },
            { "data": "developer" },
            { "data": "analyst" },
            { "data": "totalManDay" },
            { "data": "developerManDay" },
            { "data": "analystManDay" },
            { "data": "pmManDay" }
        ]
    })

})




