using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SmaFlaCa_IBLL.Interfaces;
using SmaFlaCa_IDAL.Interfaces;
using SmaFlaCa_BLL.Services;
using SmaFlaCa_Domain.Models;

namespace SmaFlaCa_Unit_Tests.deck_crud
{
    public class UnitTest_CreateDeck
    {
        private Mock<IDeckRepository> deckRepositoryMock;
        private DeckService deckService;
        public UnitTest_CreateDeck()
        {
            deckRepositoryMock = new Mock<IDeckRepository>();
            deckService = new DeckService(deckRepositoryMock.Object);
        }
        [Fact]
        public void CreateDeck_ValidDeck_ReturnsCreatedDeck()
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
        }
    }
}
