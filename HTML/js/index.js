window.onload = function () {
  var el = document.getElementById("privacy-policy-ok");
  el.onclick = hidePrivacy;
}

function hidePrivacy() {
  document.getElementById("privacy-policy").classList.add("d-none");
}

$(document).ready(function () {
  $(window).breakpoints({
    triggerOnInit: true,
  });
  $(window).bind("breakpoint-change", function (e) {
    var $outputListening = $("#output-listening");
    $outputListening.find("#output-listening--current").html(e.to);
    $outputListening.find("#output-listening--previous").html(e.from);
  });
  $(window).on("lessThan-lg", function () {
    $(".sec-part").removeClass("container");
    $(".sec-part").addClass("container-fluid");
    $("tr").addClass("card custom-card shadow");
  });
  $(window).on("greaterThan-lg", function () {
    $(".sec-part").addClass("container");
    $(".sec-part").removeClass("container-fluid");
    $("tr").removeClass("card custom-card shadow");
  });
});

$(".menu").click(function () {
  $(".sidebar").addClass("menu-show");
});
$(".closebtn").click(function () {
  $(".sidebar").removeClass("menu-show");
});