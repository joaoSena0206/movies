$(function () {
    const menu = $("#mobileMenu");
    const searchBar = $("#searchBar");
    const blackBg = $("#blackBg");

    // Adiciona animação ao menu quando clicar ou fechar e mostra o fundo preto
    $("#menuSpan").on("click", function () {
        menu.animate({ width: "toggle" }, 250);

        blackBg.show();
    });

    $("#menuSpanClose").on("click", function () {
        menu.animate({ width: "toggle" }, 250);

        blackBg.hide();
    });

    // Esconde o ícone de pesquisa ao focar na barra de pesquisa
    searchBar.on("focus", function () {
        $("#searchIcon").fadeOut(200);
    });

    searchBar.on("focusout", function () {
        $("#searchIcon").fadeIn(200);
    });
});
