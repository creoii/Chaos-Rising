using System;

namespace ChaosRising
{
    [Serializable]
    public class AbilityItem : Item
    {
        public float manaCost;
        public float cooldown;
        public Attack[] attacks;

        public AbilityItem(string name, string description, string sprite, float manaCost, float cooldown, Attack[] attacks) : base(name, description, sprite)
        {
            this.manaCost = manaCost;
            this.cooldown = cooldown;
            this.attacks = attacks;
        }
    }
}
