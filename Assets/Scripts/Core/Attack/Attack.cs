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
        public Arc arc;
        public PingPong pingPong;
        public Display display;
        public DeathEmission deathEmission;
        public float inheritedVelocity;
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
    public class Arc
    {
        public KeyValue<float>[] xVelocities;
        public KeyValue<float>[] yVelocities;
    }

    [Serializable]
    public class PingPong
    {
        public float width;
        public float speed;
        public float spread;
    }

    [Serializable]
    public class Display
    {
        public float minSize;
        public float maxSize;
        public KeyValue<float>[] sizeOverTime;

        public Color tint;
        public KeyValue<Color>[] colorOverTime;
        public KeyValue<float>[] alphaOverTime;
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
    public class DeathEmission
    {
        public Attack attack;
        public float chance;
    }

    [Serializable]
    public class KeyValue<T>
    {
        public float key;
        public T value;
    }
}
