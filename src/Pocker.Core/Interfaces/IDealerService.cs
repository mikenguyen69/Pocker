using Poker.Core.Entities;
using System.Collections.Generic;

namespace Poker.Core.Interfaces
{
    public interface IDealerService
    {
        void Shuffle(Deck deck, int times);
        void DealCards(Deck deck, PlayerHand hand);
        void CalculateHandRank(PlayerHand hand);
        void AssignScore(GameRound round, int maxScore);
        IList<Player> GetWinners(TwoCardsGame game);
    }
}
