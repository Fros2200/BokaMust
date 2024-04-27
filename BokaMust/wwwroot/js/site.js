// === Globala variabler ===


// === Eventlisteners ===

//Beräkna knappen i mitt Guideformulär
document.getElementById("btnSubmitGuide").addEventListener("click", isGuideFormValid); 

//Mitt formulär
//document.addEventListener('DOMContentLoaded', () => {
//    const form = document.getElementById('guideForm');

//    form.addEventListener('submit', (event) => {
//        if (!isGuideFormValid()) {
//            event.preventDefault();
//            alert('Vänligen fyll i alla fält.');
//        }
//    });
//});


// === Anrop ===
//disableSubmitBtn();
//enableSubmitBtn();



// === Funktioner ==

//function disableSubmitBtn() {

//    document.addEventListener("DOMContentLoaded", function () {
//        const btnSubmitGuide = document.getElementById("btnSubmitGuide");
//        btnSubmitGuide.disabled = true;
//    });
//}

//function enableSubmitBtn() {

//    const btnSubmitGuide = document.getElementById("btnSubmitGuide");
//    btnSubmitGuide.disabled = false;
//}

function isZoneSelected() {
    const selectedzone = document.querySelector('#zoneDropdown');
    if (selectedzone.value == null || selectedzone.value == "") {
        alert("Du måste ange zon");
        return false;
    }
    return true;

}
function isAppleSelected() {
    const selectedApple = document.querySelector('#appleDropdown');
    if (selectedApple.value == null || selectedApple.value == "") {
        alert("Du måste ange äppelsort");
        return false;
    }
    return true;
}

function isRadioBtnChecked() {
    const selectedRadioBtn = document.querySelector('input[name="choice"]:checked');

    if (!selectedRadioBtn) {
        alert("Du måste välja förpackningsalternativ");
        return false;
    }
    return true;
}

function isWeightApproved(inputWeight) {

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


//Ska jag ha fyra separata funktioner för att kontrollera varje del i formuläret?
    function isGuideFormValid() {
        const zoneDropdown = document.getElementById('zoneDropdown').value;
        const appleDropdown = document.getElementById('appleDropdown').value;
        const inputWeight = document.getElementById("weightField").value;

        const selectedZone = isZoneSelected(zoneDropdown); 
        const selectedApple = isAppleSelected(appleDropdown); 
        const selectedPackaging = isRadioBtnChecked();
        const approvedWeight = isWeightApproved(inputWeight);

        console.log(approvedWeight, selectedZone, selectedApple, selectedPackaging)

        return;
    }