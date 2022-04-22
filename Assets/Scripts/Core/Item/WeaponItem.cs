using System;

namespace ChaosRising
{
    [Serializable]
    public class WeaponItem : Item
    {
        public Attack[] attacks;
        public int maxSigils;

        public WeaponItem(string name, string description, string sprite, Attack[] attacks, int maxSigils) : base(name, description, sprite)
        {
            this.attacks = attacks;
            this.maxSigils = maxSigils;
        }
    }
}
