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

/*Eventlistner som lyssnar efter när formuläret submittas*/
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('guideForm');
 
    if (form) {
        form.addEventListener('submit', handleSubmit);
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

/**
 * Funktion som visar min loading vy och sedan använder en timer för att skicka mitt formlär efter vald tidsfördröjning
 */
function handleSubmit(event) {
    event.preventDefault(); 
    document.getElementById('loadingScreen').style.display = 'block';

    setTimeout(function () {
        event.target.submit();  
    }, 3000); 
}

// ==Testar äppelbilder i popup modul ==

document.addEventListener('DOMContentLoaded', function () {
    var appleModal = document.getElementById('appleModal');
    if (appleModal) { // Kontrollera att elementet finns
        appleModal.addEventListener('show.bs.modal', function (event) {
            var button = event.relatedTarget;
            var appleName = button.getAttribute('data-apple-name');
            var appleDescription = button.getAttribute('data-apple-description');
            var appleImageUrl = button.getAttribute('data-apple-image-url');

            var modalTitle = appleModal.querySelector('.modal-title');
            var modalImage = appleModal.querySelector('#appleImage');
            var modalName = appleModal.querySelector('#appleName');
            var modalDescription = appleModal.querySelector('#appleDescription');

            modalTitle.textContent = appleName;
            modalImage.src = appleImageUrl;
            modalName.textContent = appleName;
            modalDescription.textContent = appleDescription;
        });
    }
});