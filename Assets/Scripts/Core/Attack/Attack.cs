using System;
using UnityEngine;

namespace ChaosRising
{
    [Serializable]
    public class Attack
    {
        public float lifetime, speed, inheritedVelocity;
        public int projectileCount, startAngle, angleGap, angleChange, minDamage, maxDamage, startRotation, armorIgnored;
        public Vector2 offset;
        public Acceleration acceleration;
        public Orbit orbit;
        public Burst[] bursts;
        public Arc arc;
        public PingPong pingPong;
        public Collision collision;
        public Display display;
        public DeathEmission deathEmission;
    }

    [Serializable]
    public class Acceleration
    {
        public KeyValue<float>[] accelerations;
        public float max;
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
        public int count, cycles;
        public float interval;
    }

    [Serializable]
    public class Arc
    {
        public KeyValue<float>[] xVelocities, yVelocities;
    }

    [Serializable]
    public class PingPong
    {
        public float width, speed, spread;
    }

    [Serializable]
    public class Collision
    {
        public float dampen;
        public float bounce;
        public float lifetimeLoss = 1f;
    }

    [Serializable]
    public class Display
    {
        public float minSize, maxSize;
        public KeyValue<float>[] sizeOverTime;

        public Color tint;
        public KeyValue<Color>[] colorOverTime;
        public KeyValue<float>[] alphaOverTime;
        public bool blend;
    }

    [Serializable]
    public class Color
    {
        public float red, green, blue;

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
