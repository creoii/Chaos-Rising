using System;
using UnityEngine;

namespace ChaosRising
{
    [Serializable]
    public class Attack
    {
        public TargetType targetType;
        public PositionType spawnPositionType;
        public float lifetime, speed, rateOfFire, targetPrediction, inheritedVelocity;
        public int projectileCount, angleGap, startAngle, angleChange, minDamage, maxDamage, startRotation, armorIgnored;
        public Vector2 offset;
        public Acceleration acceleration;
        public Orbit orbit;
        public Burst[] bursts;
        public PingPong pingPong;
        public Collision collision;
        public Display display;
        // public DeathEmission deathEmission;

        [HideInInspector] public float attackTime;
    }

    [Serializable]
    public class Acceleration
    {
        public float offset;
        public float acceleration;
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
        public float sizeOffset;
        public float sizeChange;

        public float rotateOffset;
        public float rotateChange;

        public float tintRed;
        public float tintGreen;
        public float tintBlue;
        public float tintAlpha;
        public float colorOffset;
        public float colorChangeRed;
        public float colorChangeGreen;
        public float colorChangeBlue;
        public float colorChangeAlpha;
        public float alphaOffset;
        public float alphaChange;
        public bool blend;
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

        public KeyValue(float key, T value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public enum TargetType
    {
        Player,
        Mouse,
        Fixed
    }

    public enum PositionType
    {
        Origin,
        Mouse
    }
}
