$(function () {
    const menu = $("#mobileMenu");
    const searchBar = $("#searchBar");
    const blackBg = $("#blackBg");
    const bookmark = $(".bookmark");
    const banner = $(".banner");

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

    // Adiciona efeito hover no ícone de bookmark
    bookmark.on("mouseenter", function () {
        const path = this.getSVGDocument().children[0].children[0];

        path.style.transition = "fill 0.2s ease-in-out";
        path.style.cursor = "pointer";
        path.setAttribute("fill", "#434342");
    });

    bookmark.on("mouseleave", function () {
        this.getSVGDocument().children[0].children[0].setAttribute("fill", "#1A1A1A");
    });

    // Adiciona efeito hover no banner do carrosel
    banner.on("mouseenter", function () {
        this.style.transition = "opacity 0.2s ease-in-out";
        this.style.opacity = "90%";
    });

    banner.on("mouseleave", function () {
        this.style.opacity = "100%";
    });

    $(document).on("dragstart", function (e) {
        if (e.target.nodeName.toLowerCase() == "img" || e.target.nodeName.toLowerCase() == "a") {
            return false;
        }
    });
});
