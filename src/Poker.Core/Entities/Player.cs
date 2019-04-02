using Poker.Core.Entities.Abstract;

namespace Poker.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
