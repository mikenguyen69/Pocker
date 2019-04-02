using Pocker.Core.Entities;

namespace Pocker.Core.Interfaces
{
    public interface IDealerService
    {
        void Shuffle(Deck deck, int times);
        void DealCards(Deck deck, PlayerHand hand);
        void CalculateHandRank(PlayerHand hand);
    }
}
