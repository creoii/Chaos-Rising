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

        float angle = 0f;
        if (attack.projectileCount > 1) angle += attack.angleGap * ((attack.projectileCount * .5f) - .5f);
        for (int i = 0; i < attack.projectileCount; ++i)
        {
            GameObject obj = new GameObject(name + i);
            obj.transform.parent = transform;
            CreateGenerator(i, obj.AddComponent<ParticleSystem>(), angle -= attack.angleGap);
        }
    }

    [System.Obsolete]
    private void CreateGenerator(int index, ParticleSystem particleSystem, float startAngle)
    {
        particleSystems[index] = particleSystem;

        particleSystem.transform.position = Vector3.back;
        particleSystem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

        particleSystem.loop = false;
        particleSystem.startSize = .1f;
        particleSystem.startSpeed = attack.speed;
        particleSystem.startLifetime = attack.lifetime;

        UnityEngine.Color tint = attack.display.tint.ToColor();
        if (tint != UnityEngine.Color.white)
        {
            particleSystem.startColor = tint;
        }

        ParticleSystem.CustomDataModule data = particleSystem.customData;
        data.enabled = true;
        data.SetMode(ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Vector);
        data.SetVectorComponentCount(ParticleSystemCustomData.Custom1, 1);
        data.SetVector(ParticleSystemCustomData.Custom1, 0, new ParticleSystem.MinMaxCurve(attack.minDamage, attack.maxDamage));

        ParticleSystem.MainModule main = particleSystem.main;
        main.emitterVelocityMode = ParticleSystemEmitterVelocityMode.Transform;
        main.simulationSpace = ParticleSystemSimulationSpace.World;

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
        
        ParticleSystem.ShapeModule shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        shape.angle = 0;
        shape.radius = 0f;

        ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = particleSystem.textureSheetAnimation;
        textureSheetAnimation.enabled = true;
        textureSheetAnimation.mode = ParticleSystemAnimationMode.Sprites;
        textureSheetAnimation.AddSprite(Resources.Load<Sprite>("Sprites/Projectiles/fire_bolt"));

        ParticleSystem.CollisionModule collision = particleSystem.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        collision.quality = ParticleSystemCollisionQuality.Medium;
        collision.bounce = 0f;
        collision.lifetimeLoss = 1f;
        collision.sendCollisionMessages = true;
        collision.radiusScale = .1f;
        collision.collidesWith = LayerMask.GetMask("Living", "Blocking");

        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.sharedMaterial = Resources.Load<Material>("Materials/Sprites");

        if (attack.display.sizes.Length > 0)
        {
            ParticleSystem.SizeOverLifetimeModule sizeOverLifetime = particleSystem.sizeOverLifetime;
            sizeOverLifetime.enabled = true;
            Keyframe[] sizes = new Keyframe[attack.display.sizes.Length];
            for (int i = 0; i < attack.display.sizes.Length; ++i)
            {
                KeyValue<float> kv = attack.display.sizes[i];
                sizes[i] = new Keyframe(kv.key, kv.value);
            }
            sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(sizes));
        }
        
        if (attack.display.colors.Length > 0)
        {
            ParticleSystem.ColorOverLifetimeModule colorOverLifetime = particleSystem.colorOverLifetime;
            colorOverLifetime.enabled = true;

            GradientColorKey[] colors = new GradientColorKey[attack.display.colors.Length];
            for (int i = 0; i < attack.display.colors.Length; ++i)
            {
                KeyValue<ChaosRising.Color> kv = attack.display.colors[i];
                colors[i] = new GradientColorKey(kv.value.ToColor(), kv.key);
            }

            GradientAlphaKey[] alphas = new GradientAlphaKey[attack.display.alphas.Length];
            for (int i = 0; i < attack.display.alphas.Length; ++i)
            {
                KeyValue<float> kv = attack.display.alphas[i];
                alphas[i] = new GradientAlphaKey(kv.value, kv.key);
            }

            Gradient gradient = new Gradient();
            if (!attack.display.blend) gradient.mode = GradientMode.Fixed;
            gradient.SetKeys(colors, alphas);
            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
        }

        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = particleSystem.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.space = ParticleSystemSimulationSpace.World;

        KeyValue<float>[] accelerations = attack.accelerations;
        Keyframe[] accKeyFrame = new Keyframe[accelerations.Length];
        if (accelerations.Length > 0)
        {
            for (int i = 0; i < attack.accelerations.Length; ++i)
            {
                KeyValue<float> kv = attack.accelerations[i];
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

        velocityOverLifetime.orbitalYMultiplier = attack.orbit.speed;
        if (attack.orbit.radial) velocityOverLifetime.radial = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ParticleSystem.EmitParams emission = new ParticleSystem.EmitParams();
            if ((attackTime -= Time.deltaTime) < 0f)
            {
                ParticleSystem.ShapeModule shape;
                for (int i = 0; i < particleSystems.Length; ++i)
                {
                    shape = particleSystems[i].shape;
                    shape.rotation = new Vector3(0f, MouseUtility.GetMouseAngle(transform.position, false) + (attack.angleGap * i), 0f);

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
