using System;

namespace ChaosRising
{
    [Serializable]
    public class SigilItem : Item
    {
        public float cooldown;
        public Attack[] attacks;

        public SigilItem(string name, string description, string sprite, float cooldown, Attack[] attacks) : base(name, description, sprite)
        {
            this.cooldown = cooldown;
            this.attacks = attacks;
        }
    }
}
