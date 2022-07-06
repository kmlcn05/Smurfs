document.getElementById('fp-button').addEventListener('click',
    function () {
        document.querySelector('.bg-modal').style.display = 'flex';
    });

document.querySelector('.close').addEventListener('click',
    function () {
        document.querySelector('.bg-modal').style.display = 'none'
    });


var password = null;
var passwordhash = null;

var id = null;
var name = null;
var surname = null;
var mail = null;
var active = null;
var dateOfStart = null;
var usergroup = null;
var team = null;
var firstLogin = null;
var mail2 = null;


$(document).on('click', '.gonder', function () {
    mail = $('#girilenMail').val();

    fetch("https://smuhammetulas.com/api/User/GetUser").then(response => response.json()).then(data => {
        myfetchFunction(data);
    });
});

function myfetchFunction(data) {

    var allData = data.filter(x => x.mail == mail);
    for (var x of allData) {
        mail2 = x.mail;
        console.log(x.mail);
    }

    if (mail2 == null) {
        alert("Email not found.")
    }
    else {
        for (var x of allData) {
            id = x.id;
            name = x.name;
            surname = x.surname;
            mail = x.mail;
            active = x.active;
            dateOfStart = x.dateOfStart;
            usergroup = x.usergroup;
            team = x.team;
            firstLogin = x.firstLogin;
        }
        passwordhash = Math.random().toString(36).slice(2, 10);
        password = sha256(passwordhash);

        $.ajax({
            url: "https://smuhammetulas.com/api/User",
            type: "PUT",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({

                "id": id,
                "name": name,
                "surname": surname,
                "mail": mail,
                "password": password,
                "active": active,
                "dateOfStart": dateOfStart,
                "usergroup": usergroup,
                "team": team,
                "firstLogin": "1"

            }),
            success: function () {
                sendMail(name, surname, mail, passwordhash, active, dateOfStart, usergroup, team);
            },
            error: function (e) {
                alert("Error please try again" + JSON.stringify(e));
            }
        })
    }
}

function sendMail(name, surname, mail, passwordhash, active, dateOfStart, usergroup, team) {
    $.ajax({
        url: "https://smuhammetulas.com/api/Email",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            "name": name,
            "surname": surname,
            "mail": mail,
            "password": passwordhash,
            "active": active,
            "dateOfStart": dateOfStart,
            "usergroup": usergroup,
            "team": team,
            "firstLogin": "1"
        }),
        success: function () {
            alert("Success");
        },
        error: function (e) {
            alert("Error please try again" + JSON.stringify(e));
        }
    })
}


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
    for (j = 0; j < words[lengthProperty];) {
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