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

document.getElementById("findTimeSlot").addEventListener("click", function () {
    window.open("/Home/Popup", "Popup", "width=400,height=400");
});
