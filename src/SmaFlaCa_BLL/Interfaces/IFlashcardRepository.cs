using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;

namespace SmaFlaCa_BLL.Interfaces
{
    public interface IFlashcardRepository
    {
        List<Flashcard> GetAllFlashcards(int deckID);
        void CreateFlashcard(string question, string answer, string? cardImagePath, int deckID);
        void DeleteFlashcard(int cardId);
    }
}
