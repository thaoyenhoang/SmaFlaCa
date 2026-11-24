using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SmaFlaCa_IBLL.Interfaces;
using SmaFlaCa_IDAL.Interfaces;
using SmaFlaCa_BLL.Services;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_Unit_Tests
{
    public class TestDeckService
    {
        private Mock<IDeckRepository> deckRepositoryMock;
        private DeckService deckService;
        public TestDeckService()
        {
            deckRepositoryMock = new Mock<IDeckRepository>();
            deckService = new DeckService(deckRepositoryMock.Object);
        }
        [Fact]
        public void GetAllDecks_ReturnsAllDecks()
        {
            //Arrange
            var mockDecks = new List<Deck>
            {
                new Deck(1, "Deck 1", "Description 1", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRB1kSudjPbsOnCfNKM6CcaVBE_hOn6ApAqXJhCdjpIUA&s=10"),
                new Deck(2, "Deck 2", "Description 2", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQW3hZoh8cZbdQLZ9Zuc5hyPuCLQLdqNBOoy8Htel7ctw&s=10"),
            };
            deckRepositoryMock.Setup(repo => repo.GetAllDecks()).Returns(mockDecks);

            //Act
            var result = deckService.GetAllDecks();

            //Assert
            Assert.Equal(mockDecks, result);
            deckRepositoryMock.Verify(repo => repo.GetAllDecks(), Times.Once);
        }
        [Fact]
        public void CreateDeck_ValidDeck_ReturnsIfDeckCreated()
        {
            //Arrange
            const string deckTitle = "Starter";
            const string deckDescription = "A starter deck";
            const string? deckImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQW3hZoh8cZbdQLZ9Zuc5hyPuCLQLdqNBOoy8Htel7ctw&s=10";

            deckRepositoryMock.Setup(repo => repo.CreateDeck(deckTitle, deckDescription, deckImagePath)).Returns(true);

            //Act
            var result = deckService.CreateDeck(deckTitle, deckDescription, deckImagePath);

            //Assert
            Assert.True(result);
            deckRepositoryMock.Verify(repo => repo.CreateDeck(deckTitle, deckDescription, deckImagePath),Times.Once);
        }
        [Fact]
        public void DeleteDeck_ValidDeckId_ReturnsIfDeckDeleted()
        {
            //Arrange
            const int deckId = 1;
            deckRepositoryMock.Setup(repo => repo.DeleteDeck(deckId)).Returns(true);
            
            //Act
            var result = deckService.DeleteDeck(deckId);
            
            //Assert
            Assert.True(result);
            deckRepositoryMock.Verify(repo => repo.DeleteDeck(deckId), Times.Once);
        }

        [Fact]
        public void UpdateDeck_ValidDeckIdAndUpdatedValues_CallsUpdateDeckOnRepository()
        {
            //Arrange
            const int deckId = 1;
            const string updatedDeckTitle = "Updated Deck Title";
            const string updatedDeckDescription = "Updated Deck Description";
            const string? updatedDeckImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQW3hZoh8cZbdQLZ9Zuc5hyPuCLQLdqNBOoy8Htel7ctw&s=10";
            deckRepositoryMock.Setup(repo => repo.UpdateDeck(deckId, updatedDeckTitle, updatedDeckDescription, updatedDeckImagePath)).Returns(true);
            
            //Act
            var result = deckService.UpdateDeck(deckId, updatedDeckTitle, updatedDeckDescription, updatedDeckImagePath);
            
            //Assert
            Assert.True(result);
            deckRepositoryMock.Verify(repo => repo.UpdateDeck(deckId, updatedDeckTitle, updatedDeckDescription, updatedDeckImagePath), Times.Once);
        }
    }
}
