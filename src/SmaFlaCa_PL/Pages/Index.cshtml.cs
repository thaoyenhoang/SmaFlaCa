using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmaFlaCa_BLL.Interfaces;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Services;

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
    }
}
