// === Globala variabler ===


// === Eventlisteners ===
document.getElementById('appleDropdown').addEventListener('change', toggleSubmitGuideBtn);
document.getElementById('packagingDropdown').addEventListener('change', toggleSubmitGuideBtn);
document.getElementById('inputWeight').addEventListener('input', toggleSubmitGuideBtn);

//document.getElementById('packagingBooking').addEventListener('change', toggleSubmitBookingBtn);
//document.getElementById('inputWeightBooking').addEventListener('input', toggleSubmitBookingBtn);


//Formulär för Guide
document.getElementById("guideForm").addEventListener("submit", function (event) {

    if (!isWeightValid()){
        event.preventDefault();
    }
});

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
function toggleSubmitGuideBtn() {
    const appleDropdown = document.getElementById('appleDropdown');
    const packagingDropdown = document.getElementById('packagingDropdown');
    const inputWeight = document.getElementById('inputWeight');
    const btnSubmitGuide = document.getElementById('btnSubmitGuide');

    const isAppleSelected = appleDropdown.value !== '';
    const isPackagingSelected = packagingDropdown.value !== '';
    const isWeightEntered = inputWeight.value.trim() !== '';

    btnSubmitGuide.disabled = !(isAppleSelected && isPackagingSelected && isWeightEntered);
}

//function toggleSubmitBookingBtn() {
//    const packagingDropdown = document.getElementById('packagingBooking');
//    const inputWeight = document.getElementById('inputWeightBooking');
//    const btnSubmitBooking = document.getElementById('btnSubmitBooking');

//    const isPackagingSelected = packagingDropdown.value !== '';
//    const isWeightEntered = inputWeight.value.trim() !== '';

//    btnSubmitBooking.disabled = !(isPackagingSelected && isWeightEntered);
//}

function isWeightValid() {
    const enteredWeight = document.getElementById('inputWeight'); 
    const inputWeight = enteredWeight.value.trim(); 

    if (inputWeight == null || inputWeight == "") {
        alert("Du måste ange en vikt");
        return false;
    }
    else if (inputWeight < 30) {
        alert("Minsta vikt är 30kg");
        return false;
    }
    return true;
}
