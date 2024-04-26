// === Globala variabler ===


// === Eventlisteners ===

//Beräkna knappen i mitt Guideformulär
/*document.getElementById("btnSubmitGuide").addEventListener("click", validateGuideForm); */

//Mitt formulär
document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('guideForm');

    form.addEventListener('submit', (event) => {
        if (!isGuideFormValid()) {
            event.preventDefault();
            alert('Vänligen fyll i alla fält.');
        }
    });
}); 


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

//function isGuideFormValid() {

//    var selectedZone = document.getElementById('zoneDropdown').value;
//    var selectedApple = document.getElementById('appleDropdown').value;
//    let selectedPackaging = document.querySelector('input[name="choice"]:checked').value;
//    let weightInput = document.getElementById("weightField").value;

//    //console.log(selectedZone);
//    //console.log(selectedApple);
//    //console.log(selectedPackaging);
//    //console.log(weightInput);

//    isWeightApproved(weightInput);
///*    console.log("Vi kom hit")*/

//    //if (!selectedZone || !selectedApple || !radioBtnValue) {
//    //    alert("Du måste fylla i samtliga fält");
//    //}
//    return selectedZone && selectedApple && selectedPackaging;
//}

    function isGuideFormValid() {
        const dropdown1Value = document.getElementById('dropdown1').value;
        const dropdown2Value = document.getElementById('dropdown2').value;
        const selectedPackaging = document.querySelector('input[name="radioButton"]:checked');
        const inputWeight = document.getElementById('textInput').value;

        return dropdown1Value && dropdown2Value && selectedPackaging && inputWeight;
    }