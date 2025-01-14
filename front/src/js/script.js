$(function () {
    const menu = $("#mobileMenu");
    const searchBar = $("#searchBar");
    const bookmark = $(".bookmark");
    const thumbFigure = $(".thumbFigure");
    const banner = $(".banner");

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

    // Adiciona efeito hover na thumb do carrosel
    thumbFigure.on("mouseenter", function () {
        const thumbImg = this.querySelector("img");
        const playSpan = this.querySelector(".playSpan");

        thumbImg.style.transition = "opacity 0.2s ease-in-out";
        thumbImg.style.opacity = "90%";

        playSpan.style.transition = "color 0.2s ease-in-out";
        playSpan.style.color = "#F6C700";
    });

    thumbFigure.on("mouseleave", function () {
        const thumbImg = this.querySelector("img");
        const playSpan = this.querySelector(".playSpan");

        thumbImg.style.opacity = "100%";
        playSpan.style.color = "white";
    });

    // Adiciona efeito hover no banner do carrosel
    banner.on("mouseenter", function () {
        this.style.transition = "opacity 0.2s ease-in-out";
        this.style.opacity = "90%";
    });

    banner.on("mouseleave", function () {
        this.style.opacity = "100%";
    });

    // Inicializa o Swiper
    const swiper = new Swiper(".swiper", {
        direction: "horizontal",
        loop: true,
        slidesPerView: 1,
        // autoplay: {
        //     delay: 5000,
        //     disableOnInteraction: false,
        // },
    });
});
