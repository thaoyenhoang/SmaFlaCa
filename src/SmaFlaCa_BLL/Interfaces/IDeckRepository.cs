using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;

namespace SmaFlaCa_BLL.Interfaces
{
    public interface IDeckRepository
    {
        List<Deck> GetAllDecks();
        void CreateDeck(string deckTitle, string deckDescription, string? deckImagePath);
        void DeleteDeck(int deckId);
    }
}
