document.getElementById("deleteDeckButton").addEventListener("click", function () {

    if (confirm("Do you want to delete this deck permanently?") == true) {

        const id = this.dataset.id;

        document.getElementById("selectedDeckId").value = id;
        document.getElementById("submitDeleteDeck").click();

    }

})
document.getElementById("addCardButton").addEventListener('click', function () {
    document.querySelector("form").requestSubmit();

    // Read each input field's value
    const question = document.getElementById("cardQuestion").value;
    if (question == "") {
        return;
    }
    const answer = document.getElementById("cardAnswer").value;
    const cardImagePath = document.getElementById("cardImagePath").value;
    const deckId = this.dataset.id;

    //Write the typed input into the hidden form fields
    document.getElementById("newCardQuestion").value = question;
    document.getElementById("newCardAnswer").value = answer;
    document.getElementById("newCardImagePath").value = cardImagePath;
    document.getElementById("newCardDeckId").value = deckId;

    //Click the (hidden) submit button to submit the form => Send the POST request to OnPostCreate()
    document.getElementById("submitNewCard").click();
    })