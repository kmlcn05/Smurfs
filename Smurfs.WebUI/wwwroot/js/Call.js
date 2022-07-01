var allData = null;
var id = null;
var bank = null;
var taskType = null;
var jiraTaskNo = null;
var callName = null;
var cagriCozumSuresi = null;
var callDetails = null;
var callPriority = null;
var callDateCreated = null;
var callDateResolved = null;
var callStatus = null;
var appointee = null;
var reporter = null;


function reloadPage() {
    document.getElementById('newcall').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/Call/GetCall",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    $('#CallDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
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
            { "data": "reporter" },

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
    'url': "https://smuhammetulas.com/api/CallStatus",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#CallStatus').append(`<option value="${x.callStatusName}">${x.callStatusName}</option>`)
    });
})

$.ajax({
    'url': "https://smuhammetulas.com/api/User/GetUser",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Appointee').append(`<option value="${x.name+' '+x.surname}">${x.name} ${x.surname}</option >`)
    });
})

$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Call/" + id,
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

    bank = $("#Bank option:selected").text();
    taskType = $('#TaskType').val();
    jiraTaskNo = $('#JiraTaskNo').val();
    callName = $('#CallName').val();
    cagriCozumSuresi = $("#CagriCozumSuresi").val();
    callDetails = $("#CallDetails").val();
    callPriority = $("#CallPriority").val();
    callDateCreated = $('#CallDateCreated').val();
    callDateResolved = $('#CallDateResolved').val();
    callStatus = $("#CallStatus option:selected").text();
    appointee = $('#Appointee option:selected').text();
    reporter = $('#Reporter').val();

    //boş kontrolü yapılacak

    if (id == null) {
        if (bank == "Bir Değer Seçiniz" || taskType == "" || jiraTaskNo == "" || callName == ""
            || cagriCozumSuresi == "" || callDetails == "" || callPriority == ""
            || callDateCreated == " " || callDateResolved == " " || callStatus == "Bir Değer Seçiniz"
            || appointee == "" || reporter == "") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }
        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Call/CreateCall",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "bank": bank,
                    "taskType": taskType,
                    "jiraTaskNo": jiraTaskNo,
                    "callName": callName,
                    "cagriCozumSuresi": cagriCozumSuresi,
                    "callDetails": callDetails,
                    "callPriority": callPriority,
                    "callDateCreated": callDateCreated,
                    "callDateResolved": callDateResolved,
                    "callStatus": callStatus,
                    "appointee": appointee,
                    "reporter": reporter

                }),
                success: function () {

                    alert("Kayıt Başarılı");
                    window.location.reload()
                },
                error: function () {
                    alert("Error please try again" + JSON.stringify(e));
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
                url: "https://smuhammetulas.com/api/Call/UpdateCall",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "bank": bank,
                    "taskType": taskType,
                    "jiraTaskNo": jiraTaskNo,
                    "callName": callName,
                    "cagriCozumSuresi": cagriCozumSuresi,
                    "callDetails": callDetails,
                    "callPriority": callPriority,
                    "callDateCreated": callDateCreated,
                    "callDateResolved": callDateResolved,
                    "callStatus": callStatus,
                    "appointee": appointee,
                    "reporter": reporter
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

        bank = allData.find(x => x.id == parseInt(id)).bank;
        taskType = allData.find(x => x.id == parseInt(id)).taskType;
        jiraTaskNo = allData.find(x => x.id == parseInt(id)).jiraTaskNo;
        callName = allData.find(x => x.id == parseInt(id)).callName;
        cagriCozumSuresi = allData.find(x => x.id == parseInt(id)).cagriCozumSuresi; 
        callDetails = allData.find(x => x.id == parseInt(id)).callDetails;
        callPriority = allData.find(x => x.id == parseInt(id)).callPriority;
        callDateCreated = allData.find(x => x.id == parseInt(id)).callDateCreated;
        callDateResolved = allData.find(x => x.id == parseInt(id)).callDateResolved;
        callStatus = allData.find(x => x.id == parseInt(id)).callStatus;
        appointee = allData.find(x => x.id == parseInt(id)).appointee;
        reporter = allData.find(x => x.id == parseInt(id)).reporter;

        document.getElementById('newcall').style.display = 'block';

        $("#Bank").val(bank);
        $('#TaskType').val(taskType).html();
        $('#JiraTaskNo').val(jiraTaskNo).html();
        $('#CallName').val(callName).html();
        $("#CagriCozumSuresi").val(cagriCozumSuresi);
        $("#CallDetails").val(callDetails);
        $("#CallPriority").val(callPriority);
        $("#CallDateCreated").val(callDateCreated);
        $('#CallDateResolved').val(callDateResolved).html();
        $('#CallStatus').val(callStatus).html();
        $('#Appointee').val(appointee);
        $('#Reporter').val(reporter).html();
    }
});
