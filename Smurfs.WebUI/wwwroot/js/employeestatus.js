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
    'url': "https://smuhammetulas.com/api/User/GetUser",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (dataprojects) {
    GetProjects(dataprojects);
})

function GetProjects(datauser) {

    fetch("https://smuhammetulas.com/api/Project/GetProjects").then(response => response.json()).then(data => {

        for (var y of datauser) {

            expected = (new Date().getMonth() - new Date(y.dateOfStart).getMonth()) * 20;

            for (project of data) {

                if (project.developer == y.name + " " + y.surname) {
                    happening += parseInt(project.developerManDay);
                }
                else if (project.analyst == y.name + " " + y.surname) {
                    happening += parseInt(project.analystManDay);
                }
            }

            remainder = (expected - happening) * -1;

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
        }
    })

    $('#employeeDatatable').dataTable({
        scrollX: true,
        "paging": true,
        binfo: false,
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "surname" },
            { "data": "expected" },
            { "data": "happening" },
            { "data": "remainder" },

        ]
    });

    document.getElementsByClassName('dataTables_empty')[0].style.display = 'none';
}