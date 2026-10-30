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
                                string description = reader.GetString(2);
                                if (reader.IsDBNull(3))
                                {
                                    decks.Add(new Deck(id, title, description));
                                }
                                else
                                {
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
    }
}
    
