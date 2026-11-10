using System;
using System.Collections.Generic;
using System.Text;
using SmaFlaCa_BLL.Models;
using SmaFlaCa_BLL.Interfaces;
using Microsoft.Data.SqlClient;

namespace SmaFlaCa_DAL.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private string connectionString;
        public DeckRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Deck> GetAllDecks()
        {
            List<Deck> decks = new List<Deck>();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("SELECT * FROM DECK", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                if (reader.IsDBNull(2) && reader.IsDBNull(3))
                                {
                                    decks.Add(new Deck(id, title));
                                }
                                else if (reader.IsDBNull(2) && !reader.IsDBNull(3))
                                {
                                    string? imagePath = reader.GetString(3);
                                    decks.Add(new Deck(id, title, imagePath));
                                }
                                else if (reader.IsDBNull(3) && !reader.IsDBNull(2))
                                {
                                    string? description = reader.GetString(2);
                                    decks.Add(new Deck(id, title, description));
                                }
                                else
                                {
                                    string? description = reader.GetString(2);
                                    string? imagePath = reader.GetString(3);
                                    decks.Add(new Deck(id, title, description, imagePath));
                                }
                            }
                              
                            }
                        }
                    }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return decks;
            }
        }
        public void CreateDeck(string deckTitle, string deckDescription, string? deckImagePath)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("INSERT INTO DECK (deckTitle, deckDescription, deckImagePath) VALUES (@deckTitle, @deckDescription, @deckImagePath)", connection))
                    {
                        command.Parameters.AddWithValue("@deckTitle", deckTitle);
                        if (deckDescription == null)
                        {
                            command.Parameters.AddWithValue("@deckDescription", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@deckDescription", deckDescription);
                        }
                        if (deckImagePath == null)
                        {
                            command.Parameters.AddWithValue("@deckImagePath", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@deckImagePath", deckImagePath);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                      
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DeleteDeck(int deckId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    using (var command = new SqlCommand("DELETE FROM DECK WHERE deckId = @deckId", connection))
                    {
                        command.Parameters.AddWithValue("@deckId", deckId);
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
    
