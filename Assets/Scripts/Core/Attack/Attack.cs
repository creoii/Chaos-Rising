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
        public Acceleration acceleration;
        public Orbit orbit;
        public Burst[] bursts;
        public Display display = null;
        public bool whiplike;
    }

    [Serializable]
    public class Acceleration
    {
        public Frame<float>[] accelerations;
        public float offset = 0f;
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
        public Frame<float>[] sizes;

        public Color tint;
        public Frame<Color>[] colors;
        public Frame<float>[] alphas;
        public bool blend;
    }

    [Serializable]
    public class Color
    {
        public int red;
        public int green;
        public int blue;

        public UnityEngine.Color ToColor()
        {
            return new UnityEngine.Color(red, green, blue);
        }
    }

    [Serializable]
    public class Frame<T>
    {
        public float time;
        public T value;
    }
}
