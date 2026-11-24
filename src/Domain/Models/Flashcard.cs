using System;
using System.Collections.Generic;
using System.Text;

namespace SmaFlaCa_Domain.Models
{
    public class Flashcard
    {
        public int cardId { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string cardImagePath { get; set; } 
        public int cardDeckId { get; set; }
        public Flashcard(int cardId, string question, string answer, int cardDeckId)
        {
            this.cardId = cardId;
            this.question = question;
            this.answer = answer;
            this.cardDeckId = cardDeckId;
            this.cardImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSltdyesaETmIsYYdxPW3gcpIW0LCkUWaTdcCzKII5VMw&s=10";
        }
        public Flashcard(int cardId, string question, string answer, string cardImagePath, int cardDeckId)
        {
            this.cardId = cardId;   
            this.question = question;
            this.answer = answer;
            this.cardImagePath = cardImagePath;
            this.cardDeckId = cardDeckId;
        }
    }
}
