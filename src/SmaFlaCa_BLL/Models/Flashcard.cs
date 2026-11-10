using System;
using System.Collections.Generic;
using System.Text;

namespace SmaFlaCa_BLL.Models
{
    public class Flashcard
    {
        public int cardId { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string cardImagePath { get; set; }
        public Flashcard(int cardId, string question, string answer)
        {
            this.cardId = cardId;
            this.question = question;
            this.answer = answer;
        }
        public Flashcard(int cardId, string question, string answer, string cardImagePath)
        {
            this.cardId = cardId;   
            this.question = question;
            this.answer = answer;
            this.cardImagePath = cardImagePath;
        }
    }
}
