using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_IBLL.Interfaces;
using SmaFlaCa_IDAL.Interfaces;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_BLL.Services
{
    public class DeckService : IDeckService
    {
        private IDeckRepository deckRepository;
        public DeckService(IDeckRepository deckRepository)
        {
            this.deckRepository = deckRepository;
        }
        public List<Deck> GetAllDecks()
        {
            return deckRepository.GetAllDecks();
        }
        public bool CreateDeck(string deckTitle, string deckDescription, string? deckImagePath)
        {
            return deckRepository.CreateDeck(deckTitle, deckDescription, deckImagePath);
        }
        public bool DeleteDeck(int deckId)
        {
            return deckRepository.DeleteDeck(deckId);
        }
        public bool UpdateDeck(int deckId, string updatedDeckTitle, string updatedDeckDescription, string? updatedDeckImagePath)
        {
            return deckRepository.UpdateDeck(deckId, updatedDeckTitle, updatedDeckDescription, updatedDeckImagePath);
        }
    }
}
