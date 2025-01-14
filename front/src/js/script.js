$(function () {
    const menu = $("#mobileMenu");
    const searchBar = $("#searchBar");
    const bookmark = $("#bookmark");

    // Adiciona animação ao menu quando clicar ou fechar
    $("#menuSpan").on("click", function () {
        menu.animate({ width: "toggle" }, 250);
    });

    $("#menuSpanClose").on("click", function () {
        menu.animate({ width: "toggle" }, 250);
    });

    // Esconde o ícone de pesquisa ao focar na barra de pesquisa
    searchBar.on("focus", function () {
        $("#searchIcon").fadeOut(350);
    });

    searchBar.on("focus", function () {
        $("#searchIcon").fadeOut(350);
    });
});
