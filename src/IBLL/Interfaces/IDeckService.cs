using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_IBLL.Interfaces
{
    public interface IDeckService
    {
        List<Deck> GetAllDecks();
        bool CreateDeck(string deckTitle, string deckDescription, string? deckImagePath);
        bool DeleteDeck(int deckId);
        bool UpdateDeck(int deckId, string updatedDeckTitle, string updatedDeckDescription, string? updatedDeckImagePath);
    }
}
