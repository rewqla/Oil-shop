document.getElementById("btnEdit").addEventListener('click', EnableInputs);
function EnableInputs() {
    let maind = document.getElementById("dwui");
    maind.querySelectorAll("input").forEach(number => {
        number.disabled = false;
    });
    maind.querySelector("select").disabled = false;
    document.getElementById("dwb").querySelectorAll("button").forEach(number => {
        number.hidden = false;
    });
}