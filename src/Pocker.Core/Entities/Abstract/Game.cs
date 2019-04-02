using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;
using System.Collections.Generic;

namespace Pocker.Core.Entities.Abstract
{
    public abstract class Game : BaseEntity
    {
        public IList<Player> Players { get; set; }
        public IList<GameRound> GameRounds { get; set; }

        public Game(IList<Player> players, int numberOfRounds, int numberOfCards)
        {
            // Validate number of players is between 2 to 6
            if (players.Count < 2 || players.Count > 6)
            {
                throw new InvalidNumberOfPlayerException(GlobalConstants.INVALID_NUMBEROFPLAYER_EXCEPTION);
            }
            else
            {
                Players = players;
            }

            // Validate number of rounds is between 2 to 5 rounds
            if (numberOfRounds < 2 || numberOfRounds > 5)
            {
                throw new InvalidNumberOfRoundException(GlobalConstants.INVALID_NUMBEROFROUND_EXCEPTION);
            }
            else
            {
                GameRounds = new List<GameRound>();

                for (int i = 0; i < numberOfRounds; i++)
                {
                    GameRound round = new GameRound(players, numberOfCards);
                    GameRounds.Add(round);
                }
            }
        }
    }
}
