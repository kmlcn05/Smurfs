var allData = null;
var id = null;
var projectDate = null;
var bank = null;
var jiraProjectNo = null;
var jiraTaskNo = null;
var jiraProjectName = null;
var dZDStatus = null;
var status = null;
var department = null;
var team = null;
var developer = null;
var analyst = null;
var totalManDay = null;
var developerManDay = null;
var analystManDay = null;
var pmManDay = null;

function reloadPage() {
    document.getElementById('newproject').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/Project/GetProjects",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    for (var x of data) {
        x.projectDate = x.projectDate.replace("T00:00:00", "")
    }

    $('#ProjectDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
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
            { "data": "pmManDay" },

            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-danger Delete' data-id='" + row.id + "' >Delete</button>";
                }
            },
            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-info Update' data-id='" + row.id + "' >Update</button>";
                }
            },

        ]
    })
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Bank",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Bank').append(`<option value="${x.bankName}">${x.bankName}</option>`)
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/DZDStatus",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#DZDStatus').append(`<option value="${x.dzdStatusName}">${x.dzdStatusName}</option>`)
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Status",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Status').append(`<option value="${x.statusName}">${x.statusName}</option>`)
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Department",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Department').append(`<option value="${x.departmentName}">${x.departmentName}</option>`)
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/Team",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Team').append(`<option value="${x.teamName}">${x.teamName}</option>`)
    });
})


$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/Project/" + id,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {

                    //Yenile
                    alert("silindi");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                }
            })
        }
    }
});


$(document).on('click', '.Save', function () {

    projectDate = $('#ProjectDate').val();
    bank = $("#Bank option:selected").text();
    jiraProjectNo = $('#JiraProjectNo').val();
    jiraTaskNo = $('#JiraTaskNo').val();
    jiraProjectName = $('#JiraProjectName').val();
    dZDStatus = $("#DZDStatus option:selected").text();
    status = $("#Status option:selected").text();
    department = $("#Department option:selected").text();
    team = $("#Team option:selected").text();
    developer = $('#Developer').val();
    analyst = $('#Analyst').val();
    totalManDay = $('#TotalManDay').val();
    developerManDay = $('#DeveloperManDay').val();
    analystManDay = $('#AnalystManDay').val();
    pmManDay = $('#PmManDay').val();

    if (id == null) {
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Project/Save",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "projectDate": projectDate,
                    "bank": bank,
                    "jiraProjectNo": jiraProjectNo,
                    "jiraTaskNo": jiraTaskNo,
                    "jiraProjectName": jiraProjectName,
                    "dZDStatus": dZDStatus,
                    "status": status,
                    "department": department,
                    "team": team,
                    "developer": developer,
                    "analyst": analyst,
                    "totalManDay": totalManDay,
                    "developerManDay": developerManDay,
                    "analystManDay": analystManDay,
                    "pmManDay": pmManDay

                }),
                success: function () {

                    alert("Kayıt Başarılı");
                    window.location.reload()
                },
                error: function () {
                    alert("Error please try again");
                    window.location.reload();
                }

            })
        }
        else {
            return false;
        }
    }
    else {
        var Confirm = confirm("Are you sure, do you want to update it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Project/Update",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "projectDate": projectDate,
                    "bank": bank,
                    "jiraProjectNo": jiraProjectNo,
                    "jiraTaskNo": jiraTaskNo,
                    "jiraProjectName": jiraProjectName,
                    "dZDStatus": dZDStatus,
                    "status": status,
                    "department": department,
                    "team": team,
                    "developer": developer,
                    "analyst": analyst,
                    "totalManDay": totalManDay,
                    "developerManDay": developerManDay,
                    "analystManDay": analystManDay,
                    "pmManDay": pmManDay
                }),
                success: function () {

                    //Yenile
                    alert("The record is updated.");
                    window.location.reload();


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload();
                }

            })

        }
    }

});



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;

        projectDate = allData.find(x => x.id == parseInt(id)).projectDate;
        bank = allData.find(x => x.id == parseInt(id)).bank;
        jiraProjectNo = allData.find(x => x.id == parseInt(id)).jiraProjectNo;
        jiraTaskNo = allData.find(x => x.id == parseInt(id)).jiraTaskNo;
        jiraProjectName = allData.find(x => x.id == parseInt(id)).jiraProjectName;
        dZDStatus = allData.find(x => x.id == parseInt(id)).dZDStatus;
        status = allData.find(x => x.id == parseInt(id)).status;
        department = allData.find(x => x.id == parseInt(id)).department;
        team = allData.find(x => x.id == parseInt(id)).team;
        developer = allData.find(x => x.id == parseInt(id)).developer;
        analyst = allData.find(x => x.id == parseInt(id)).analyst;
        totalManDay = allData.find(x => x.id == parseInt(id)).totalManDay;
        developerManDay = allData.find(x => x.id == parseInt(id)).developerManDay;
        analystManDay = allData.find(x => x.id == parseInt(id)).analystManDay;
        pmManDay = allData.find(x => x.id == parseInt(id)).pmManDay;


        document.getElementById('newproject').style.display = 'block';

        $('#ProjectDate').val(projectDate);
        $("#Bank").val(bank);
        $('#JiraProjectNo').val(jiraProjectNo).html();
        $('#JiraTaskNo').val(jiraTaskNo).html();
        $('#JiraProjectName').val(jiraProjectName).html();
        $("#DZDStatus").val(dZDStatus);
        $("#Status").val(status);
        $("#Department").val(department);
        $("#Team").val(team);
        $('#Developer').val(developer).html();
        $('#Analyst').val(analyst).html();
        $('#TotalManDay').val(totalManDay).html();
        $('#DeveloperManDay').val(developerManDay).html();
        $('#AnalystManDay').val(analystManDay).html();
        $('#PmManDay').val(pmManDay).html();
    }
});
