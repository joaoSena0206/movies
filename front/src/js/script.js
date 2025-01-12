$(function () {
    let menu = $("#mobileMenu");

    $("#menuSpan").on("click", function () {
        menu.animate({ width: "toggle" }, 250);
    });

    $("#menuSpanClose").on("click", function () {
        menu.animate({ width: "toggle" }, 250);
    });
});
