// === Globala variabler ===


// === Eventlisteners ===
document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('guideForm');
    const submitBtn = document.getElementById('btnSubmitGuide');

    //TODO: Fundera på om jag vill jobba med modulär js struktur, om ja ta bort nedan och lägg till data-page
    if (form && submitBtn) {
        form.addEventListener('change', updateButtonState);
        form.addEventListener('input', updateButtonState);
    }
});


// === Anrop ===




// === Funktioner ==

function updateButtonState() {
    const appleSelected = document.querySelector('input[name="SelectedApple"]:checked') !== null;
    const packageSelected = document.querySelector('input[name="SelectedPackage"]:checked') !== null;

    document.getElementById('btnSubmitGuide').disabled = !(appleSelected && packageSelected);
}


function validateForm() {
    const weightInput = document.getElementById('weight');
    const weight = parseFloat(weightInput.value);

    if (weight < 30) {
        alert('Minsta godkända vikt är 30kg');
        return false;
    }

    return true;
}
