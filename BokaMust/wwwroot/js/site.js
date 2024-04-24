function toggleCheckmark(extra) {
    // Toogle the icon
    extra.querySelector(".add-icon").classList.toggle("hidden")
    extra.querySelector(".checkmark-icon").classList.toggle("visible")
    // Toogle the background
    extra.classList.toggle("selected")
}

var app = new Vue({
    el: '#app',
    data: {
        price: 10.99,
        peanutButter: false,
        yogurt: false,
        mixedBerries: false,
        appleCinnamon: false
    },
    methods: {
        updatePrice: function (extra, extraString) {
            if (extra === false) {
                this.price += 2.99
            } else {
                this.price -= 2.99
            }
            this[extraString] = !extra
        }
    }
})