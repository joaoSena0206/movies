$(function () {
    let menu = $("#mobileMenu");

    $("#menuSpan").on("click", function () {
        menu.animate({ width: "toggle" }, 300);
    });

    $("#menuSpanClose").on("click", function () {
        menu.animate({ width: "toggle" }, 300);
    });
});
