using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_IDAL.Interfaces
{
    public interface IFlashcardRepository
    {
        List<Flashcard> GetAllFlashcards(int deckID);
        void CreateFlashcard(string question, string answer, string? cardImagePath, int deckID);
        void DeleteFlashcard(int cardId);
        void UpdateFlashcard(int originalCardId, string updatedCardQuestion, string updatedCardAnswer, string? updatedCardImagePath);
    }
}
