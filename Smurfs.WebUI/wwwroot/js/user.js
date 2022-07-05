
var allData = null;
var id = null;
var username = null;
var surname = null;
var active = null;
var mail = null;
var dateOfStart = null;
var usergroup = null; 
var team = null; 
var password = null;
var passwordhash = null;

var pagelog = null;

var userlog = $('#userlog').text();
var userlog2 = userlog.split(' ');
var namelog = userlog2[0];
var surnamelog = userlog2[1];

function reloadPage() {
    document.getElementById('newuser').style.display = 'none';
    window.location.reload()
}

$.ajax({
    'url': "https://smuhammetulas.com/api/User/GetUser",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    allData = data;

    for (var x of data) {
        x.dateOfStart = x.dateOfStart.replace("T00:00:00", "");

        x.active = x.active.replace("0", "No");
        x.active = x.active.replace("1", "Yes");
    };

    $('#userDatatable').dataTable({
        scrollX: true,
        "paging": true,
        "aaData": data,
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "surname" },
            { "data": "active" },
            { "data": "mail" },
            { "data": "dateOfStart" },
            { "data": "usergroup" },
            { "data": "team" },

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
    'url': "https://smuhammetulas.com/api/Usergroup",
    'method': "GET",
    'contentType': 'application/json'
}).done(function (data) {
    data.forEach(x => {
        $('#Usergroup').append(`<option value="${x.groupName}">${x.groupName}</option>`)
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
        username = allData.find(x => x.id == parseInt(id)).name;
        surname = allData.find(x => x.id == parseInt(id)).surname;
        var Confirm = confirm("Are you sure, do you want to delete it?");
        if (Confirm) {

            $.ajax({
                url: "https://smuhammetulas.com/api/User/" + id,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {

                    //Yenile
                    alert("silindi");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Bu kullanıcı projelerde görev aldığı için silinemez");
                    window.location.reload()
                }

            })

        }
        var datetime = new Date().toJSON();
        pagelog = username + surname + " isimli kullanıcı silindi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Silme"
            }),

            success: function () {

            }
        })
    }
});


$(document).on('click', '.Save', function () {

    username = $('#UserName').val();
    surname = $('#Surname').val();

    active = $('#Active').val();
    active = active.replace("No", "0");
    active = active.replace("Yes", "1");

    mail = $('#Mail').val();
    dateOfStart = $('#DateOfStart').val();
    usergroup = $('#Usergroup option:selected').text();
    team = $('#Team option:selected').text();

    if (id == null) {
        if (username == "" || surname == "" || active == "Bir Değer Seçiniz" || mail == ""
            || dateOfStart == "" || usergroup == "Bir Değer Seçiniz" || team == "Bir Değer Seçiniz") {

            document.getElementById("hata").innerHTML = "*Boş Alanları Doldurunuz!";
            return false;
        }

        for (var x of allData) {
            if (x.mail == mail) {
                alert("Bu mail adresi zaten kayıtlıdır.");
                alert("Lütfen farklı bir mail adresi giriniz.");
                return false;
            }
        };

        var Confirm = confirm("Kayıt yapılsın mı?");
        if (Confirm) {

            passwordhash = Math.random().toString(36).slice(2, 10);
            password = sha256(passwordhash);
          
            $.ajax({
                url: "https://smuhammetulas.com/api/User",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({

                    "name": username,
                    "surname": surname,
                    "mail": mail,
                    "password": password,
                    "active": active,
                    "dateOfStart": dateOfStart,
                    "usergroup": usergroup,
                    "team": team

                }),
                success: function () {

                    alert("Kayıt Başarılı");
                    window.location.reload()

                },
                error: function () {
                    alert("Error please try again");
                    window.location.reload()
                }

            })

        }
        $.ajax({
            url: "https://smuhammetulas.com/api/Email",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "name": username,
                "surname": surname,
                "mail": mail,
                "password": passwordhash,
                "active": active,
                "dateOfStart": dateOfStart,
                "usergroup": usergroup,
                "team": team
            }),
        });

        var datetime = new Date().toJSON();
        pagelog = username + surname + " isimli kullanıcı eklendi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Ekleme"
            }),
        })
    }
    else {
        var Confirm = confirm("Are you sure, do you want to update it?");
        if (Confirm) {

            password = allData.find(x => x.id == parseInt(id)).password;

            $.ajax({
                url: "https://smuhammetulas.com/api/User",
                type: "PUT",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    "id": id,
                    "name": username,
                    "surname": surname,
                    "mail": mail,
                    "password" : password,
                    "active": active,
                    "dateOfStart": dateOfStart,
                    "usergroup": usergroup,
                    "team": team
                }),
                success: function () {

                    //Yenile
                    alert("The record is updated");
                    window.location.reload()


                },
                error: function (e) {
                    alert("Error please try again" + JSON.stringify(e));
                    window.location.reload()
                }

            })

        }
        var datetime = new Date().toJSON();
        pagelog = username + surname + " isimli kullanıcı güncellendi";
        $.ajax({
            url: "https://smuhammetulas.com/api/Log",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                "logDate": datetime,
                "name": namelog,
                "surname": surnamelog,
                "page": pagelog,
                "process": "Güncelleme"
            })
        })
    }

});



$(document).on('click', '.Update', function (e) {
    if (allData && e.target && e.target.dataset && e.target.dataset.id) {
        id = e.target.dataset.id;

        username = allData.find(x => x.id == parseInt(id)).name;
        surname = allData.find(x => x.id == parseInt(id)).surname;
        mail = allData.find(x => x.id == parseInt(id)).mail;
        active = allData.find(x => x.id == parseInt(id)).active;
        dateOfStart = allData.find(x => x.id == parseInt(id)).dateOfStart;
        usergroup = allData.find(x => x.id == parseInt(id)).usergroup;
        team = allData.find(x => x.id == parseInt(id)).team;

        document.getElementById('newuser').style.display = 'block';

        $('#UserName').val(username).html();
        $('#Surname').val(surname).html();
        $('#Mail').val(mail).html();
        $('#Active').val(active).html();
        $('#DateOfStart').val(dateOfStart).html();
        $('#Usergroup').val(usergroup).html();
        $('#Team').val(team).html();

    }
});


//Sifre kriptolama
function sha256(ascii) {
    function rightRotate(value, amount) {
        return (value >>> amount) | (value << (32 - amount));
    }
    ;

    var mathPow = Math.pow;
    var maxWord = mathPow(2, 32);
    var lengthProperty = 'length';
    var i, j; // Used as a counter across the whole file
    var result = '';

    var words = [];
    var asciiBitLength = ascii[lengthProperty] * 8;

    //* caching results is optional - remove/add slash from front of this line to toggle
    // Initial hash value: first 32 bits of the fractional parts of the square roots of the first 8 primes
    // (we actually calculate the first 64, but extra values are just ignored)
    var hash = sha256.h = sha256.h || [];
    // Round constants: first 32 bits of the fractional parts of the cube roots of the first 64 primes
    var k = sha256.k = sha256.k || [];
    var primeCounter = k[lengthProperty];
    /*/
     var hash = [], k = [];
     var primeCounter = 0;
     //*/

    var isComposite = {};
    for (var candidate = 2; primeCounter < 64; candidate++) {
        if (!isComposite[candidate]) {
            for (i = 0; i < 313; i += candidate) {
                isComposite[i] = candidate;
            }
            hash[primeCounter] = (mathPow(candidate, .5) * maxWord) | 0;
            k[primeCounter++] = (mathPow(candidate, 1 / 3) * maxWord) | 0;
        }
    }

    ascii += '\x80'; // Append Ƈ' bit (plus zero padding)
    while (ascii[lengthProperty] % 64 - 56)
        ascii += '\x00'; // More zero padding

    for (i = 0; i < ascii[lengthProperty]; i++) {
        j = ascii.charCodeAt(i);
        if (j >> 8)
            return; // ASCII check: only accept characters in range 0-255
        words[i >> 2] |= j << ((3 - i) % 4) * 8;
    }
    words[words[lengthProperty]] = ((asciiBitLength / maxWord) | 0);
    words[words[lengthProperty]] = (asciiBitLength);

    // process each chunk
    for (j = 0; j < words[lengthProperty]; ) {
        var w = words.slice(j, j += 16); // The message is expanded into 64 words as part of the iteration
        var oldHash = hash;
        // This is now the undefinedworking hash", often labelled as variables a...g
        // (we have to truncate as well, otherwise extra entries at the end accumulate
        hash = hash.slice(0, 8);

        for (i = 0; i < 64; i++) {
            var i2 = i + j;
            // Expand the message into 64 words
            // Used below if 
            var w15 = w[i - 15], w2 = w[i - 2];

            // Iterate
            var a = hash[0], e = hash[4];
            var temp1 = hash[7]
                    + (rightRotate(e, 6) ^ rightRotate(e, 11) ^ rightRotate(e, 25)) // S1
                    + ((e & hash[5]) ^ ((~e) & hash[6])) // ch
                    + k[i]
                    // Expand the message schedule if needed
                    + (w[i] = (i < 16) ? w[i] : (
                            w[i - 16]
                            + (rightRotate(w15, 7) ^ rightRotate(w15, 18) ^ (w15 >>> 3)) // s0
                            + w[i - 7]
                            + (rightRotate(w2, 17) ^ rightRotate(w2, 19) ^ (w2 >>> 10)) // s1
                            ) | 0
                            );
            // This is only used once, so *could* be moved below, but it only saves 4 bytes and makes things unreadble
            var temp2 = (rightRotate(a, 2) ^ rightRotate(a, 13) ^ rightRotate(a, 22)) // S0
                    + ((a & hash[1]) ^ (a & hash[2]) ^ (hash[1] & hash[2])); // maj

            hash = [(temp1 + temp2) | 0].concat(hash); // We don't bother trimming off the extra ones, they're harmless as long as we're truncating when we do the slice()
            hash[4] = (hash[4] + temp1) | 0;
        }

        for (i = 0; i < 8; i++) {
            hash[i] = (hash[i] + oldHash[i]) | 0;
        }
    }

    for (i = 0; i < 8; i++) {
        for (j = 3; j + 1; j--) {
            var b = (hash[i] >> (j * 8)) & 255;
            result += ((b < 16) ? 0 : '') + b.toString(16);
        }
    }
    return result;
};