
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/BibliotekaHub").build();



connection.on("posaljiZahtev", function (imeIPrezime, knjigaIme, knjigaId, usernameKorisnik) {
   
 
   
   


    $("tbody").append(


        "<tr style='background-color:azure'>" +
         "<form action='Prihvati method='post'>"+
            "<input type='hidden' name='z.knjigaId' value='"+knjigaId+"' />"+
            "<input type='hidden' name='z.usernameKorisnik' value='"+usernameKorisnik+"' />"+
        
        "<td>" + imeIPrezime + "</td>" +
        "<td>" + knjigaIme + "</td>" +
        "<td><input type='date' name='datumDo' /></td>" +
        "<td>" +
        "<button class='btn btn-success' onclick='Prihvati()'>Prihvati</button>" +

        "</td>" +
        "</form>" +
        "</tr>" 
           )
    
    

});







connection.start().then(function () {


    console.log("Start..Zahtevi");
    
}).catch(function (err) {
    return console.error(err.toString());
});





