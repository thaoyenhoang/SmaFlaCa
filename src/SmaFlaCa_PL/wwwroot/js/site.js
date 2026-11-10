// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const addDeckButton = document.getElementById("addDeckButton");
    addDeckButton.addEventListener('click', function () {
        document.querySelector("form").requestSubmit();
        // Read each input field's value
        const deckTitle = document.getElementById("deckTitle").value;
        if (deckTitle == "") {
            return;
        }
        const deckDescription = document.getElementById("deckDescription").value;
        const deckImagePath = document.getElementById("deckImagePath").value;


        //Write the typed input into the hidden form fields
        document.getElementById("newDeckTitle").value = deckTitle;
        document.getElementById("newDeckDescription").value = deckDescription;
        document.getElementById("newDeckImagePath").value = deckImagePath;

        

        //Click the (hidden) submit button to submit the form => Send the POST request to OnPostCreate()
   
        document.getElementById("submitNewDeck").click();


        const addDeckModal = document.getElementById("addDeckModal");
        addDeckModal.showModal();
        setTimeout(() => { addDeckModal.close(); }, 6000);
    })
})

document.getElementById("deleteDeckButton").addEventListener("click", function () {

        if (confirm("Do you want to delete this deck permanently?") == true) {

            const id = this.dataset.id;

            document.getElementById("selectedDeckId").value = id;
            document.getElementById("submitDeleteDeck").click();

        }
      
    })



    