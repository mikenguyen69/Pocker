using Pocker.Core.Entities.Abstract;

namespace Pocker.Core.Entities
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
