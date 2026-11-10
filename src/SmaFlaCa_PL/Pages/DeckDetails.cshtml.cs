using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmaFlaCa_BLL.Interfaces;
using SmaFlaCa_BLL.Models;

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
        public async Task<IActionResult> OnGet(int id)
        {
            decks = deckService.GetAllDecks();
            
            deck = decks.FirstOrDefault(deck => deck.deckId == id);

            if (deck is null)
            {
                return NotFound();
            }
            flashcards = flashcardService.GetAllFlashcards(id);
            return Page();
        }
        public IActionResult OnPostCreateFlashcard(
            string question,
            string answer,
            string? cardImagePath,
            int deckId)
        {
            flashcardService.CreateFlashcard(question, answer, cardImagePath, deckId);
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostDeleteDeck(int selectedDeckId)
        {
            deckService.DeleteDeck(selectedDeckId);
            return RedirectToPage("/Index");
        }
    }
}
