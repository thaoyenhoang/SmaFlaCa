using SmaFlaCa_BLL.Interfaces;
using SmaFlaCa_BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmaFlaCa_BLL.Services
{
    public class FlashcardService : IFlashcardService
    {
        private IFlashcardRepository flashcardRepository;
        public FlashcardService(IFlashcardRepository flashcardRepository)
        {
            this.flashcardRepository = flashcardRepository;
        }
        public List<Flashcard> GetAllFlashcards(int deckID)
        {
            return this.flashcardRepository.GetAllFlashcards(deckID);
        }
        public void CreateFlashcard(string question, string answer, string? cardImagePath, int deckID)
        {
            flashcardRepository.CreateFlashcard(question, answer, cardImagePath, deckID);
        }
        public void DeleteFlashcard(int cardId)
        {
            flashcardRepository.DeleteFlashcard(cardId);
        }
    }
}
