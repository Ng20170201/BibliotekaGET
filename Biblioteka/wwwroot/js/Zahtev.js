
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/BibliotekaHub").build();



connection.on("posaljiZahtev", function (z) {

    var tr = document.createElement("tr");
      var msg= $("tbody").append(
        "<tr style='background-color:azure'>" +
        "<td>" + z.Korisnik.ImeIPrezime + "</td>" +
        "<td>" + z.Knjiga.Ime + "</td>" +
        "<td><input type='date' name='datumDo' /></td>" +
        "<td>" +
        "<button class='btn btn-success' onclick='Prihvati(" + z + ",datumDo)'>Prihvati</button>" +

        "</td>" +

        "</tr>"

    );
    document.getElementById("zahtev").appendChild(tr);
    tr.textContent = msg;
});







connection.start().then(function () {


    console.log("Start..Zahtevi");
    
}).catch(function (err) {
    return console.error(err.toString());
});






connection.on("prihvatiZahtev", function (z, datumDo) {


    izbrisi(z);


});