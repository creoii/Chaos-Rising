using ChaosRising;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    public Attack attack;
    public ParticleSystem[] particleSystems;

    private Stats stats;

    private float attackTime;

    [System.Obsolete]
    private void Start()
    {
        particleSystems = new ParticleSystem[attack.projectileCount];
        stats = GetComponentInParent<StatContainer>().stats;

        for (int i = 0; i < attack.projectileCount; ++i)
        {
            GameObject obj = new GameObject(name + i);
            obj.transform.parent = transform;
            CreateGenerator(i, attack, obj.AddComponent<ParticleSystem>(), false);
        }
    }

    [System.Obsolete]
    private void CreateGenerator(int index, Attack attack, ParticleSystem particleSystem, bool sub)
    {
        if (!sub) particleSystems[index] = particleSystem;

        particleSystem.transform.position = Vector3.back;
        particleSystem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

        particleSystem.loop = false;
        particleSystem.startSize = .1f;
        particleSystem.startSpeed = attack.speed;
        particleSystem.startLifetime = attack.lifetime;

        #region Tint
        UnityEngine.Color tint = attack.display.tint.ToColor();
        if (tint != UnityEngine.Color.white)
        {
            particleSystem.startColor = tint;
        }
        #endregion

        #region Damage
        ParticleSystem.CustomDataModule data = particleSystem.customData;
        data.enabled = true;
        data.SetMode(ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Vector);
        data.SetVectorComponentCount(ParticleSystemCustomData.Custom1, 2);
        data.SetVector(ParticleSystemCustomData.Custom1, 0, new ParticleSystem.MinMaxCurve(attack.minDamage, attack.maxDamage));
        data.SetVector(ParticleSystemCustomData.Custom1, 1, new ParticleSystem.MinMaxCurve(attack.armorIgnored, 0f));
        #endregion

        #region Main
        ParticleSystem.MainModule main = particleSystem.main;
        main.emitterVelocityMode = ParticleSystemEmitterVelocityMode.Transform;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        #endregion

        #region Inherit
        ParticleSystem.InheritVelocityModule inheritVelocity = particleSystem.inheritVelocity;
        inheritVelocity.curveMultiplier = attack.inheritedVelocity;
        #endregion

        #region Emission
        ParticleSystem.EmissionModule emission = particleSystem.emission;
        emission.rate = 0f;
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[attack.bursts.Length];
        for (int i = 0; i < bursts.Length; ++i)
        {
            bursts[i] = new ParticleSystem.Burst();
            bursts[i].time = 0f;
            bursts[i].count = attack.bursts[i].count;
            bursts[i].cycleCount = attack.bursts[i].cycles;
            bursts[i].repeatInterval = attack.bursts[i].interval;
        }
        emission.SetBursts(bursts);
        #endregion

        #region Shape
        ParticleSystem.ShapeModule shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        shape.angle = 0f;
        shape.radius = 0f;
        
        if (attack.pingPong.width > 0f)
        {
            shape.arcMode = ParticleSystemShapeMultiModeValue.PingPong;
            shape.radius = attack.pingPong.width;
            shape.arcSpeed = attack.pingPong.speed;
            shape.arcSpread = attack.pingPong.spread;
        }
        #endregion

        #region Texture Sheet Animation
        ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = particleSystem.textureSheetAnimation;
        textureSheetAnimation.enabled = true;
        textureSheetAnimation.mode = ParticleSystemAnimationMode.Sprites;
        textureSheetAnimation.AddSprite(Resources.Load<Sprite>("Sprites/Projectiles/fire_bolt"));
        #endregion

        #region Collision
        ParticleSystem.CollisionModule collision = particleSystem.collision;
        collision.enabled = true;
        collision.mode = ParticleSystemCollisionMode.Collision2D;
        collision.type = ParticleSystemCollisionType.World;
        collision.quality = ParticleSystemCollisionQuality.Medium;
        collision.bounce = 0f;
        collision.lifetimeLoss = 1f;
        collision.sendCollisionMessages = true;
        collision.collidesWith = LayerMask.GetMask("Blocking", "Enemy");
        #endregion

        #region GPU & Material
        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.sharedMaterial = Resources.Load<Material>("Materials/Sprites");
        renderer.enableGPUInstancing = true;
        #endregion

        #region Size Over Time
        if (attack.display.sizeOverTime.Length > 0)
        {
            ParticleSystem.SizeOverLifetimeModule sizeOverLifetime = particleSystem.sizeOverLifetime;
            sizeOverLifetime.enabled = true;
            Keyframe[] sizes = new Keyframe[attack.display.sizeOverTime.Length];
            for (int i = 0; i < attack.display.sizeOverTime.Length; ++i)
            {
                KeyValue<float> kv = attack.display.sizeOverTime[i];
                sizes[i] = new Keyframe(kv.key, kv.value);
            }
            sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(sizes));
        }
        #endregion

        #region Color Over Time
        if (attack.display.colorOverTime.Length > 0)
        {
            ParticleSystem.ColorOverLifetimeModule colorOverLifetime = particleSystem.colorOverLifetime;
            colorOverLifetime.enabled = true;

            GradientColorKey[] colors = new GradientColorKey[attack.display.colorOverTime.Length];
            for (int i = 0; i < attack.display.colorOverTime.Length; ++i)
            {
                KeyValue<ChaosRising.Color> kv = attack.display.colorOverTime[i];
                colors[i] = new GradientColorKey(kv.value.ToColor(), kv.key);
            }

            GradientAlphaKey[] alphas = new GradientAlphaKey[attack.display.alphaOverTime.Length];
            for (int i = 0; i < attack.display.alphaOverTime.Length; ++i)
            {
                KeyValue<float> kv = attack.display.alphaOverTime[i];
                alphas[i] = new GradientAlphaKey(kv.value, kv.key);
            }

            Gradient gradient = new Gradient();
            if (!attack.display.blend) gradient.mode = GradientMode.Fixed;
            gradient.SetKeys(colors, alphas);
            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        #endregion

        #region Acceleration
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = particleSystem.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.space = ParticleSystemSimulationSpace.World;

        KeyValue<float>[] accelerations = attack.acceleration.accelerations;
        Keyframe[] accKeyFrame = new Keyframe[accelerations.Length];
        if (accelerations.Length > 0)
        {
            for (int i = 0; i < attack.acceleration.accelerations.Length; ++i)
            {
                KeyValue<float> kv = attack.acceleration.accelerations[i];
                accKeyFrame[i] = new Keyframe(kv.key, kv.value);
            }
        }
        else
        {
            accKeyFrame = new Keyframe[1]
            {
                new Keyframe(0f, 1f),
            };
        }
        
        velocityOverLifetime.speedModifier = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(accKeyFrame));

        if (attack.acceleration.max >= 0f)
        {
            ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime = particleSystem.limitVelocityOverLifetime;
            limitVelocityOverLifetime.enabled = true;
            limitVelocityOverLifetime.space = ParticleSystemSimulationSpace.World;

            limitVelocityOverLifetime.limit = attack.acceleration.max;
        }
        #endregion

        #region Arc
        if (attack.arc.xVelocities.Length > 0)
        {
            Keyframe[] xVelocities = new Keyframe[attack.arc.xVelocities.Length];
            for (int i = 0; i < attack.arc.xVelocities.Length; ++i)
            {
                KeyValue<float> kv = attack.arc.xVelocities[i];
                xVelocities[i] = new Keyframe(kv.key, kv.value);
            }
            velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(xVelocities));
        }
        else
        {
            velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(new Keyframe[]
            {
                new Keyframe(0f, 0f)
            }));
        }

        if (attack.arc.yVelocities.Length > 0)
        {
            Keyframe[] yVelocities = new Keyframe[attack.arc.yVelocities.Length];
            for (int i = 0; i < attack.arc.yVelocities.Length; ++i)
            {
                KeyValue<float> kv = attack.arc.yVelocities[i];
                yVelocities[i] = new Keyframe(kv.key, kv.value);
            }
            velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(yVelocities));
        }
        else
        {
            velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(new Keyframe[]
            {
                new Keyframe(0f, 0f)
            }));
        }

        velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(new Keyframe[]
        {
            new Keyframe(0f, 0f)
        }));
        #endregion

        #region Orbit
        velocityOverLifetime.orbitalYMultiplier = attack.orbit.speed;
        if (attack.orbit.radial) velocityOverLifetime.radial = 1;

        if (attack.deathEmission.attack != null && !sub)
        {
            GameObject obj = new GameObject(name + "_subEmitter");
            obj.transform.parent = transform.GetChild(index);

            ParticleSystem subSystem = obj.AddComponent<ParticleSystem>();
            CreateGenerator(-1, attack.deathEmission.attack, subSystem, true);

            ParticleSystem.SubEmittersModule subEmitters = particleSystem.subEmitters;
            subEmitters.enabled = true;
            subEmitters.AddSubEmitter(subSystem, ParticleSystemSubEmitterType.Death, ParticleSystemSubEmitterProperties.InheritNothing, attack.deathEmission.chance);
        }
        #endregion
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ParticleSystem.EmitParams emission = new ParticleSystem.EmitParams();
            if ((attackTime -= Time.deltaTime) < 0f)
            {
                ParticleSystem.ShapeModule shape;
                float angle = MouseUtility.GetMouseAngle(transform.position, false);
                if (attack.projectileCount > 1) angle -= attack.angleGap * (((attack.projectileCount - 1f) / 2f) + 1);
                for (int i = 0; i < particleSystems.Length; ++i)
                {
                    shape = particleSystems[i].shape;
                    shape.rotation = new Vector3(0f, angle += attack.angleGap, 0f);

                    if (attack.display.maxSize > 0)
                    {
                        emission.startSize = Random.Range(attack.display.minSize, attack.display.maxSize);
                    }

                    particleSystems[i].Emit(emission, 1);
                    attackTime = 1f / stats.dexterity;
                }
            }
        }
    }
}
