$(function () {
    const menu = $("#mobileMenu");
    const searchBar = $("#searchBar");
    const blackBg = $("#blackBg");
    const bookmark = $(".bookmark");
    const banner = $(".banner");
    const header = $("header");
    const wrapperHeader = $("#wrapperHeader");
    const bg = $("#searchBg");
    bg.css("top", header.height() + "px");
    bg.css("width", wrapperHeader.outerWidth() + "px");
    bg.css("align-self", "center");


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

    // Pesquisa os filmes digitados pelo usuário
    searchBar.on("input", (e) => {
        let vl = e.target.value;    

        if (vl != "") {
            header.css("position", "fixed");
            bg.removeClass("hidden");

            $.ajax({
                url: "/Obra/Pesquisar",
                type: "GET",
                data: { valor: vl },
                success: (data) => {
                    bg.empty();

                    data.forEach((filme) => {
                        const div = document.createElement("div");
                        const figure = document.createElement("figure");
                        const img = document.createElement("img");
                        const divInfo = document.createElement("div");

                        div.classList = "flex space-x-4";
                        
                        img.classList = "rounded-lg w-[80px] h-[120px] object-cover";
                        img.src = `/imgs/banner/${filme.codigo}.jpg`;
                        img.alt = filme.nome;

                        divInfo.innerHTML = `
                        <h1 class="text-white font-bold">${filme.nome}</h1>
                        <h2 class="text-zinc-300">${filme.anoLancamento}</h2>
                        <h2 class="text-zinc-300">${filme.diretor.nome}</h2>`;

                        figure.append(img);
                        div.append(figure);
                        div.append(divInfo);
                        bg.append(div);
                    });
                }
            });
        }
        else {
            header.css("position", "static");
            bg.addClass("hidden");
        }
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

    $(window).on("resize", () => {
        bg.css("top", header.height() + "px");
        bg.css("width", wrapperHeader.outerWidth() + "px");
        bg.css("align-self", "center");
    });
});
