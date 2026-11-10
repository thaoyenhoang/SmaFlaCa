using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Interfaces;

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
        public void CreateDeck(string deckTitle, string deckDescription, string? deckImagePath)
        {
            deckRepository.CreateDeck(deckTitle, deckDescription, deckImagePath);
        }
        public void DeleteDeck(int deckId)
        {
            deckRepository.DeleteDeck(deckId);
        }
    }
}
