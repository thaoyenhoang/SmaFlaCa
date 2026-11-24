

const cards = document.querySelectorAll(".flashcard-content");

cards.forEach(card => {
    card.addEventListener("click", function () {
        card.classList.toggle("show");
    })
});

