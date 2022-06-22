
var allData = null;
$.ajax({
    'url': "https://smuhammetulas.com/api/Bank",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;
    $('#bankDatatable').dataTable({
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "bankName" },

            {
                "render": function (data, x, row) {
                    return "<button class='btn btn-danger Delete' data-id='" + row.id + "' >Delete</button>";
                }
            },
            {
                "render": function (data, row) {
                    return "<button onclick= 'newbankupdate()' class= 'btn btn-info Update' id= 'Update'>Update</button>";
                }
                
            },

        ]
    })
})



$(document).on('click', '.Delete', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        var id = e.target.dataset.id;
        var bank = allData.find(x => x.id == parseInt(id));

        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (bank && Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/Bank",
                type: "DELETE",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({bank}),
                success: function () {

                    alert("silindi");
                    //reload jquery datatable

                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                }

            })

        }
    }
});


$(document).on('click', '.Save', function () {
    var Confirm = confirm("Kayıt yapılsın mı?");
    if (Confirm) {
        var bankname = $('#BankName').val() 
        $.ajax({
            url: "https://smuhammetulas.com/api/Bank",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "bankName": bankname
            }),
            success: function () {

                alert("Kayıt Başarılı");
            },
            error: function () {
                alert("Error please try again");
            }

        })

    }
    else {
        return false;
    }
});

    $(document).on('click', '.Update', function () {
        $(document).getElementById('newbank').style.display = 'block'
    });

function newbankupdate() {
    document.getElementById('newbank').style.display = 'block';
};




