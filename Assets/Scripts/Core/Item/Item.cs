using System;

namespace ChaosRising
{
    [Serializable]
    public class Item
    {
        public string name, sprite;

        public Item(string name, string sprite)
        {
            this.name = name;
            this.sprite = sprite;
        }

        public Item(string name) : this(name, "Items/" + name)
        {

        }
    }
}
