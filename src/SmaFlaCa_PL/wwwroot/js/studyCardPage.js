
//Flip card
 const cards = document.querySelectorAll(".flashcard-content");

 cards.forEach(card => {
     card.addEventListener("click", function () {
        card.classList.toggle("show");
    })
});

//Move to next card
    const ratingButtons = document.querySelectorAll(".nextCardButton");
    const progress = document.getElementById("cardProgress");

    let currentIndex = 0;

    ratingButtons.forEach(button => {
        button.addEventListener("click", () => {
            cards[currentIndex].hidden = true;
            currentIndex++;

            if (currentIndex < cards.length) {
                cards[currentIndex].hidden = false;
                progress.textContent =
                    `Card ${currentIndex + 1} of ${cards.length}`;
            } else {
                progress.textContent = "You’ve reviewed all the cards!";
                ratingButtons.forEach(button => {
                    button.hidden = true;
                });
            }
        });
    });
y