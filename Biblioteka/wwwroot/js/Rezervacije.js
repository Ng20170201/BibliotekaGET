
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/BibliotekaHub").build();




connection.on("prihvatiZahtev", function (knjigaId, usernameKorisnik, ImeKnjige, ImeIprezime, datumIzdavanja, DatumVracanja, rezervacijaID, datumDo, br) {
    if (br == 0) {
        $("tbody").append(
            "<tr style='background-color:azure'>" +
            "<form action='VratiKnjigu' method='post'>" +
            "<input type='hidden' name='id' value='" + rezervacijaID + "' />" +
            "<input type='hidden' name='idKnjige' value='" + knjigaId + "' />" +
            "<input type='hidden' name='username' value='" + usernameKorisnik + "' />" +

            "<td>" + ImeKnjige + "</td >" +
            "<td>" + ImeIprezime + "</td >" +
            "<td>" + datumIzdavanja + "  </td>" +
            "<td>" + DatumVracanja+" </td>" +
            "<td> <button type='submit' value='Vrati' class='btn btn-outline-danger'>Vrati</button></td>" +
            "</form>" +
            "</tr>"
        )
    }
    if (br == 1) {
        $("tbody").append(
            "<tr style='background-color:azure' >" +
            "<td>" + ImeIprezime + "</td>" +
            "<td>" + datumIzdavanja + "</td >" +
            "<td>" + DatumVracanja + "</td >" +


            "</tr>"
        )
    }



});


connection.start().then(function () {


    console.log("Start..Rezervacije");

}).catch(function (err) {
    return console.error(err.toString());
});




