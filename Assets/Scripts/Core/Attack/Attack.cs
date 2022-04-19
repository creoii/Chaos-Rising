using System;

namespace ChaosRising
{
    [Serializable]
    public class Attack
    {
        public float lifetime;
        public float speed;
        public int projectileCount;
        public int angleGap;
        public int minDamage;
        public int maxDamage;
        public KeyValue<float>[] accelerations;
        public Orbit orbit;
        public Burst[] bursts;
        public Display display;
        public bool whiplike;
    }

    [Serializable]
    public class Orbit
    {
        public float speed;
        public bool radial;
    }

    [Serializable]
    public class Burst
    {
        public int count;
        public int cycles;
        public float interval;
    }

    [Serializable]
    public class Display
    {
        public float minSize;
        public float maxSize;
        public KeyValue<float>[] sizes;

        public Color tint;
        public KeyValue<Color>[] colors;
        public KeyValue<float>[] alphas;
        public bool blend;
    }

    [Serializable]
    public class Color
    {
        public float red;
        public float green;
        public float blue;

        public UnityEngine.Color ToColor()
        {
            return new UnityEngine.Color(red, green, blue);
        }
    }

    [Serializable]
    public class KeyValue<T>
    {
        public float key;
        public T value;
    }
}
