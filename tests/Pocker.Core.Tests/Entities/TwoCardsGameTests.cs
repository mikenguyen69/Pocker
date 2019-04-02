using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Entities;
using Poker.Core.Exceptions;
using Poker.Core.Interfaces;
using Poker.Core.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Tests.Entities
{
    [TestClass]
    public class TwoCardsGameTests
    {
        private DependencyInjector _injector;
        private IRepository<Player> playerRepository;

        public TwoCardsGameTests()
        {
            _injector = new DependencyInjector();
            playerRepository = _injector.ResolveService<IRepository<Player>>();
        }

        [ExpectedException(typeof(InvalidNumberOfPlayerException))]
        [TestMethod]
        public void ShouldThrowInvalidNumberOfPlayerException()
        {
            // Arrange
            IList<Player> playerList = playerRepository.List();

            TwoCardsGame game = new TwoCardsGame(playerList, 4);

            // Act && Arrange
        }

        [ExpectedException(typeof(InvalidNumberOfRoundException))]
        [TestMethod]
        public void ShouldThrowInvalidNumberOfRoundException()
        {
            // Arrange
            IList<Player> playerList = playerRepository.List().Take(5).ToList();

            TwoCardsGame game = new TwoCardsGame(playerList, 100);

            // Act && Arrange
        }

        [DataRow(5, 5, 5, 5)]
        [DataRow(5, 3, 3, 5)]
        [DataRow(6, 4, 4, 6)]
        [DataTestMethod]
        public void NewGame_WithNumberOfPlayersAndRounds(int numberOfPlayers, int numberOfRounds, int expectedGamesRounds, int expectedPlayerHands)
        {
            // Arrange 
            var players = playerRepository.List().Take(numberOfPlayers).ToList();
            var game = new TwoCardsGame(players, numberOfRounds);

            // Act 

            // Assert
            Assert.AreEqual(expectedGamesRounds, game.GameRounds.Count);
            Assert.IsTrue(game.GameRounds.All(x => !x.Finished && x.PlayerHands.Count == expectedPlayerHands));
        }
    }
}
