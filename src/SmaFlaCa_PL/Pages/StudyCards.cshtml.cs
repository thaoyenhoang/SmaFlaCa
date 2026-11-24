using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmaFlaCa_Domain.Models;
using SmaFlaCa_IBLL.Interfaces;

namespace SmaFlaCa_PL.Pages
{
    public class StudyCardModel : PageModel
    {
        private IDeckService deckService;
        private IFlashcardService flashcardService;

        public List<Deck> decks { get; private set; }
        public List<Flashcard> flashcards { get; private set; }

        public StudyCardModel(IDeckService deckService, IFlashcardService flashcardService)
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
    }
}
