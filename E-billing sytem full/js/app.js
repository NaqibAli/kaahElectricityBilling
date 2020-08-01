const bwat = document.querySelector(".bwatt");
const nwat = document.querySelector(".nwatt");
const bbalance = document.querySelector(".bbalance");
const total = document.querySelector(".total");
const clear = document.querySelector(".cleartxt");
const datetxt = document.querySelector("#txtdate");

//datetxt.value=Date.now







nwat.addEventListener("blur", calculate);

clear.addEventListener("click", () => {
    bwat.value = ""
    nwat.value = ""
    bbalance.value = ""
    total.value = ""
    total.value = ""
})

function calculate() {

    var totalBalance;
    if (nwat.value < bwat.value) {
        nwat.classList.add("is-invalid");
    }
    else {
        nwat.classList.remove("is-invalid");
        totalBalance = (nwat.value - bwat.value) * 0.5 + bbalance.value;
        total.value = totalBalance;
    }
}