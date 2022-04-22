using System;

namespace ChaosRising
{
    [Serializable]
    public class Item
    {
        public string name, sprite, description;

        public Item(string name, string sprite, string description)
        {
            this.name = name;
            this.sprite = sprite;
            this.description = description;
        }

        public Item(string name, string description) : this(name, "Items/" + name, description)
        {
        }
    }
}
