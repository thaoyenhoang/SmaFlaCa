// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const addDeckButton = document.getElementById("addDeckButton");
    if (!addDeckButton) return;
    addDeckButton.addEventListener('click', function () {

        // Read each input field's value
        const deckTitle = document.getElementById("deckTitle").value;
        const deckDescription = document.getElementById("deckDescription").value;
        const deckImagePath = document.getElementById("deckImagePath").value;


        //Write the typed input into the hidden form fields
        document.getElementById("newDeckTitle").value = deckTitle;
        document.getElementById("newDeckDescription").value = deckDescription;
        document.getElementById("newDeckImagePath").value = deckImagePath;

        //Click the (hidden) submit button to submit the form => Send the POST request to OnPostCreate()
        document.getElementById("submitNewDeck").click();
    })
})
function DeckClickEvents() {

    // Go through every deck, on each deck listen for a click
    const decks = document.querySelectorAll(".card")

    decks.forEach(deck => {
        deck.addEventListener('click', function () {

            // first remove the selected class on all other decks
            decks.forEach(deck => deck.classList.remove("selected"));

            // add the selected class to the clicked deck
            this.classList.add("selected");
        });

    });
}

document.getElementById("deleteDeckButton").addEventListener("click", function () {
        const selectedDeck = document.querySelector(".selected");

        if (confirm("Do you want to delete this deck permanently?") == true) {

            const id = selectedDeck.dataset.id;

            document.getElementById("selectedDeckId").value = id;
            document.getElementById("submitDeleteDeck").click();

        }
        else {
            selectedRow.classList.remove("selected");
        }
    })
