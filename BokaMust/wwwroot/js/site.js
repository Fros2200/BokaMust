// === Globala variabler ===


// === Eventlisteners ===

document.getElementById("zoneDropdown").addEventListener("click", function () {
    zoneDropdownContent.style.display = zoneDropdownContent.style.display === "block" ? "none" : "block";
});

document.getElementById("zoneDropdownContent").addEventListener("click", function (event) {
    if (event.target.tagName === "A") {
        zoneDropdown.innerText = event.target.innerText;
        zoneDropdownContent.style.display = "none";
    }
});

document.getElementById("appleDropdown").addEventListener("click", function () {
    appleDropdownContent.style.display = appleDropdownContent.style.display === "block" ? "none" : "block";
});

document.getElementById("appleDropdownContent").addEventListener("click", function (event) {
    if (event.target.tagName === "A") {
        appleDropdown.innerText = event.target.innerText;
        appleDropdownContent.style.display = "none";
    }
});

document.getElementById("btnSubmitGuide").addEventListener("click", validateGuideForm); 


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


function isWeightApproved(weightInput) {

    if (weightInput == null || weightInput == "") {
        alert("Du måste ange en vikt");
        return false;
    }
    else if (weightInput < 30) {
        alert("Minsta vikt är 30kg"); 
        return false;
    }
    return true; 
  
}

function validateGuideForm() {

    let selectedZone = document.querySelector('#zoneDropdownContent a,active').getAttribute("value");
    let selectedApple = document.querySelector('#appleDropdownContent a,active').getAttribute("value");
    let radioBtnValue = document.querySelector('input[name="choice"]:checked').value;
    let weightInput = document.getElementById("weightField").value;

    console.log(selectedZone);
    console.log(selectedApple); 
    console.log(radioBtnValue);
    console.log(weightInput); 

    isWeightApproved(weightInput); 
    console.log("Vi kom hit")

    //if (isWeightApproved(weightInput) && zoneDropdown && appleDropdown && radioBtnValue && weightInput) {
    //    console.log("Alla fält är ifyllda korrekt"); 
    //    return true; 
    //}
    //alert("Du måste fylla i samtliga fält"); 
    //return false; 

}







