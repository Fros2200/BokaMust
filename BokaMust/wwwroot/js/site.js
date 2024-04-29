﻿// === Globala variabler ===


// === Eventlisteners ===


/**
 * Lyssnar på valen i guideformuläret och anropar toggleSubmitBtn
 */
document.getElementById('guideForm').addEventListener('change', function (event) {
    if (event.target.id === 'appleDropdown' || event.target.type === 'radio' || event.target.id === 'inputWeight') {
        toggleSubmitGuideBtn();
    }

});


/**
 * Lyssnar på submit av guideformuläret och anropar isWeightValid, 
 * om false så hindras formuläret från att skickas
 */
document.getElementById("guideForm").addEventListener("submit", function (event) {

    if (!isWeightValid()) {
        event.preventDefault();
    }
});


//document.getElementById('packagingBooking').addEventListener('change', toggleSubmitBookingBtn);
//document.getElementById('inputWeightBooking').addEventListener('input', toggleSubmitBookingBtn);



//Formulär för Bokning
//document.getElementById("bookingForm").addEventListener("submit", function (event) {

//    if (!isWeightValid()) {
//        event.preventDefault();
//    }
//});

// === Anrop ===
toggleSubmitGuideBtn(); 
/*toggleSubmitBookingBtn(); */



// === Funktioner ==
/**
 * Aktiverar Beräkna-knappen när samtliga val är gjorda
 */
function toggleSubmitGuideBtn() {
    const btnSubmitGuide = document.getElementById('btnSubmitGuide');
    const isAppleSelected = document.getElementById('appleDropdown').value !== '';
    const isPackagingSelected = document.querySelector('input[name="packagingOption"]:checked') !== null;
    const isWeightEntered = document.getElementById('inputWeight').value.trim() !== '';

    console.log(isAppleSelected, isPackagingSelected, isWeightEntered)

    btnSubmitGuide.disabled = !(isAppleSelected && isPackagingSelected && isWeightEntered);
}

/**
 * Kontrollerar om inmatad vikt är godkänd
 */
function isWeightValid() {
    const enteredWeight = document.getElementById('inputWeight').value.trim(); 

    if (enteredWeight == null || enteredWeight == "") {
        alert("Du måste ange en vikt");
        return false;
    }
    else if (enteredWeight < 30) {
        alert("Minsta vikt är 30kg");
        return false;
    }
    return true;
}
