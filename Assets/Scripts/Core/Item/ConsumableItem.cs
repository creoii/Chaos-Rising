using System;

namespace ChaosRising
{
    [Serializable]
    public class ConsumableItem : Item
    {
        public ConsumableItem(string name, string description, string sprite) : base(name, description, sprite)
        {
        }
    }
}
