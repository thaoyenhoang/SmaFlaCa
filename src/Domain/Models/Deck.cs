using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SmaFlaCa_Domain.Models
{
    public class Deck
    {
        public int deckId { get; set; }
        public string deckTitle { get; set; }
        public string deckDescription { get; set; } 
        public string deckImagePath { get; set; } 
        
       public static Deck WithDefaultDescription(int deckId, string deckTitle, string deckImagePath)
        { 
            return new Deck(deckId, deckTitle, "A cool description will go here", deckImagePath);
        }
        public Deck(int deckId, string deckTitle, string deckDescription)
        {
            this.deckId = deckId;
            this.deckTitle = deckTitle;
            this.deckDescription = deckDescription;
            this.deckImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSltdyesaETmIsYYdxPW3gcpIW0LCkUWaTdcCzKII5VMw&s=10";
        }
      
        public Deck(int deckID, string deckTitle)
        {
            this.deckId = deckID;
            this.deckTitle = deckTitle;
            this.deckDescription = "A cool description will go here";
            this.deckImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSltdyesaETmIsYYdxPW3gcpIW0LCkUWaTdcCzKII5VMw&s=10";
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
