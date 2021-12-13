window.onload = function () {
    var el = document.getElementById("privacy-policy-ok");
    el.onclick = hidePrivacy;
}

function hidePrivacy() {
    document.getElementById("privacy-policy").classList.add("d-none");
}
