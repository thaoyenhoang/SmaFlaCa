using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_IDAL.Interfaces
{
    public interface IDeckRepository
    {
        List<Deck> GetAllDecks();
        bool CreateDeck(string deckTitle, string deckDescription, string? deckImagePath);
        bool DeleteDeck(int deckId);
        bool UpdateDeck(int deckId, string updatedDeckTitle, string updatedDeckDescription, string? updatedDeckImagePath);
    }
}
