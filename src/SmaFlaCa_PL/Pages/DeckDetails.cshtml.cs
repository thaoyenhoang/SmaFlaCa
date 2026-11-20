using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmaFlaCa_IBLL.Interfaces;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_PL.Pages
{
    public class DeckDetailsModel : PageModel
    {
        private IDeckService deckService;
        private IFlashcardService flashcardService;

        public List<Deck> decks { get; private set; }
        public List<Flashcard> flashcards { get; private set; }

        public DeckDetailsModel(IDeckService deckService, IFlashcardService flashcardService)
        {
            this.deckService = deckService;
            this.flashcardService = flashcardService;
        }
        public Deck? deck { get; private set; }
        public void OnGet(int id)
        {
            decks = deckService.GetAllDecks();
            
            deck = decks.FirstOrDefault(deck => deck.deckId == id);

            flashcards = flashcardService.GetAllFlashcards(id);
        }
        public IActionResult OnPostCreateFlashcard(
            string newCardQuestion,
            string newCardAnswer,
            string? newCardImagePath,
            int newCardDeckId)
        {
            flashcardService.CreateFlashcard(newCardQuestion, newCardAnswer, newCardImagePath, newCardDeckId);
            return RedirectToPage("/DeckDetails", new { id = newCardDeckId });
        }
        public IActionResult OnPostDeleteDeck(int selectedDeckId)
        {
            deckService.DeleteDeck(selectedDeckId);
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostUpdateDeck(int originalDeckId, string updatedDeckTitle, string updatedDeckDescription, string? updatedDeckImagePath)
        {
            deckService.UpdateDeck(originalDeckId, updatedDeckTitle, updatedDeckDescription, updatedDeckImagePath);
            return RedirectToPage("/DeckDetails", new { id = originalDeckId });
        }
        public IActionResult OnPostDeleteFlashcard(int selectedCardId, int selectedDeckId)
        {
            flashcardService.DeleteFlashcard(selectedCardId);
            return RedirectToPage("/DeckDetails", new { id = selectedDeckId });
        }
        public IActionResult OnPostUpdateFlashcard(int originalCardId, string updatedCardQuestion, string updatedCardAnswer, string? updatedCardImagePath, int originalDeckId)
        {
            flashcardService.UpdateFlashcard(originalCardId, updatedCardQuestion, updatedCardAnswer, updatedCardImagePath);
            return RedirectToPage("/DeckDetails", new { id = originalDeckId });
        }
    }
}
