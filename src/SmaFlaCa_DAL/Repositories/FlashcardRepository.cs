using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace SmaFlaCa_DAL.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private string connectionString;
        public FlashcardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Flashcard> GetAllFlashcards(int deckID)
        {
            List<Flashcard> flashcards = new List<Flashcard>();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("SELECT * FROM Flashcards WHERE DeckID = @DeckID", connection))
                    {
                        command.Parameters.AddWithValue("@DeckID", deckID);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int cardId = reader.GetInt32(0);
                                string question = reader.GetString(1);
                                string answer = reader.GetString(2);
                                int cardDeckId = reader.GetInt32(4);
                                if (reader.IsDBNull(3))
                                {
                                    flashcards.Add(new Flashcard(cardId, question, answer, cardDeckId));
                                }
                                else
                                {
                                    string? cardImagePath = reader.GetString(3);
                                    flashcards.Add(new Flashcard(cardId, question, answer, cardImagePath, cardDeckId));
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return flashcards;
            }
        }
        public void CreateFlashcard(string question, string answer, string cardImagePath, int deckID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("INSERT INTO Flashcards (Question, Answer, CardImagePath, DeckID) VALUES (@Question, @Answer, @CardImagePath, @DeckID)", connection))
                    {
                        command.Parameters.AddWithValue("@Question", question);
                        command.Parameters.AddWithValue("@Answer", answer);
                        if (cardImagePath == null)
                        {
                            command.Parameters.AddWithValue("@CardImagePath", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CardImagePath", cardImagePath);
                        }
                        command.Parameters.AddWithValue("@DeckID", deckID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DeleteFlashcard(int cardId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("DELETE FROM Flashcards WHERE CardID = @CardID", connection))
                    {
                        command.Parameters.AddWithValue("@CardID", cardId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }

}
 
