function makeImgSameHeight(elms) {
    let largestHeight = 0;

    elms.each((i, img) => {
        if (img.offsetHeight > largestHeight) {
            largestHeight = img.offsetHeight;
        }
    });

    elms.each((i, img) => {
        if (img.offsetHeight != largestHeight) {
            img.style.height = largestHeight + "px";
        }
    });
}

$(function () {
    const bookmark = $(".bookmark");
    const thumbFigure = $(".thumbFigure");
    const banner = $(".banner");
    const swiper = new Swiper(".swiper-hero", {
        direction: "horizontal",
        loop: true,
        slidesPerView: 1,
        allowTouchMove: false,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false,
        },
    });
    const swiperFilmes = new Swiper(".swiper-filmes", {
        direction: "horizontal",
        slidesPerView: 4,
        allowTouchMove: true,
        spaceBetween: 30
    });
    const slideBanner = $(".slideBanner");

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

    makeImgSameHeight(slideBanner);

    $(window).on("resize", () => {
        slideBanner.css("height", "auto");
        makeImgSameHeight(slideBanner);
    });
});