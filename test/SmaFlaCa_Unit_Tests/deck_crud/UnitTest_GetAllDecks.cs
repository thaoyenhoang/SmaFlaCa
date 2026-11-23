using Moq;
using SmaFlaCa_IBLL.Interfaces;
using SmaFlaCa_IDAL.Interfaces;
using SmaFlaCa_BLL.Services;
using SmaFlaCa_Domain.Models;
namespace SmaFlaCa_Unit_Tests.deck_crud
{
    public class UnitTest_GetAllDecks
    {
        private Mock<IDeckRepository> deckRepositoryMock;
        private DeckService deckService;
        public UnitTest_GetAllDecks()
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
        }

    }
}
