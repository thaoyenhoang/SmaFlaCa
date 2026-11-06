using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Interfaces;

namespace SmaFlaCa_BLL.Services
{
    public class DeckService : IDeckService
    {
        private IDeckRepository _deckRepository;
        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }
        public List<Deck> GetAllDecks()
        {
            return _deckRepository.GetAllDecks();
        }
        public void CreateDeck(string deckTitle, string deckDescription, string? deckImagePath)
        {
            _deckRepository.CreateDeck(deckTitle, deckDescription, deckImagePath);
        }
        public void DeleteDeck(int deckId)
        {
            _deckRepository.DeleteDeck(deckId);
        }
    }
}
