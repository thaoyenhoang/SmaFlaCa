using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SmaFlaCa_BLL.Models
{
    public class Deck
    {
        public int deckId { get; set; }
        public string deckTitle { get; set; }
        public string deckDescription { get; set; } = "A cool description will go here";
        public string deckImagePath { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSltdyesaETmIsYYdxPW3gcpIW0LCkUWaTdcCzKII5VMw&s=10";
        public Deck(int deckId, string deckTitle, string deckDescription)
        {
            this.deckId = deckId;
            this.deckTitle = deckTitle;
            this.deckDescription = deckDescription;
        }
        public Deck(int deckId, string deckTitle)
        {
            this.deckId = deckId;
            this.deckTitle = deckTitle;
        }
        public Deck(int deckId, string deckTitle, string deckDescription, string deckImagePath)
        {
            this.deckId = deckId;
            this.deckTitle = deckTitle;
            this.deckDescription = deckDescription;
            this.deckImagePath = deckImagePath;
        }
    
    }
}
