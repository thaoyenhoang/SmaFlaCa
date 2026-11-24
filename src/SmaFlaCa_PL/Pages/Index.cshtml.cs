using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmaFlaCa_Domain.Models;
using SmaFlaCa_IBLL.Interfaces;

namespace SmaFlaCa_PL.Pages
{
    public class IndexModel : PageModel
    {
        private IDeckService deckService;

        public List<Deck> decks { get; private set; }


        public IndexModel(IDeckService deckService)
        {
            this.deckService = deckService;
        }

        public void OnGet()
        {
            decks = deckService.GetAllDecks();

        }
        public IActionResult OnPostCreate(
          string newDeckTitle,
          string newDeckDescription,
          string newDeckImagePath)
        {
            deckService.CreateDeck(newDeckTitle, newDeckDescription, newDeckImagePath);
            return RedirectToPage();
        }
      
    }
}
