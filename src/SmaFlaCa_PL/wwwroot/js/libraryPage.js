// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// document.addEventListener("DOMContentLoaded", function () {
//     const addDeckButton = document.getElementById("addDeckButton");
//     addDeckButton.addEventListener('click', function () {
//         const addDeckModal = document.getElementById("addDeckModal");
//         addDeckModal.showModal();
//         setTimeout(() => { addDeckModal.close(); }, 6000);
//     })
// })


(() => {
    const pageSize = 6;
    const deckItems = Array.from(document.querySelectorAll(".deck-page-item"));
    const pagination = document.getElementById("deckPagination");
    const addDeckColumn = document.querySelector(".add-deck-column");

    if (!pagination || deckItems.length === 0) {
        return;
    }

    const pageCount = Math.ceil(deckItems.length / pageSize);
    let currentPage = 1;

    function renderPage(page) {
        currentPage = Math.max(1, Math.min(page, pageCount));

        deckItems.forEach((item, index) => {
            const itemPage = Math.floor(index / pageSize) + 1;
            item.classList.toggle("d-none", itemPage !== currentPage);
        });

        // Show the add-deck tile on the last page.
        if (addDeckColumn) {
            addDeckColumn.classList.toggle("d-none", currentPage !== pageCount);
        }

        renderPagination();
    }

    function addButton(label, page, options = {}) {
        const item = document.createElement("li");
        item.className = "page-item";
        if (options.active) item.classList.add("active");
        if (options.disabled) item.classList.add("disabled");

        const button = document.createElement("button");
        button.type = "button";
        button.className = "page-link";
        button.textContent = label;
        button.disabled = Boolean(options.disabled);

        if (options.active) {
            button.setAttribute("aria-current", "page");
        }

        button.addEventListener("click", () => renderPage(page));
        item.appendChild(button);
        pagination.appendChild(item);
    }

    function renderPagination() {
        pagination.replaceChildren();

        addButton("Previous", currentPage - 1, {
            disabled: currentPage === 1
        });

        for (let page = 1; page <= pageCount; page++) {
            addButton(String(page), page, {
                active: page === currentPage
            });
        }

        addButton("Next", currentPage + 1, {
            disabled: currentPage === pageCount
        });
    }

    renderPage(1);
})();



    