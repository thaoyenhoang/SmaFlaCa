using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Interfaces;

namespace SmaFlaCa_BLL.Services
{
    public class DeckService : IDeckService
    {
        private IDeckRepository _deckRepository; // BLL doesnt need to know about the DataRepository, it only needs to know about the IDeckRepository interface
        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }
        public List<Deck> GetAllDecks()
        {
            return _deckRepository.GetAllDecks();
        }
    }
}
