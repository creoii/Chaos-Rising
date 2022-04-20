using UnityEngine;
using ChaosRising;

public class PlayerController : MonoBehaviour
{
    private static readonly Vector3 faceleft = new Vector3(-1, 1, 1);

    private RaycastHit2D hit;
    private Vector3 movement;

    private CircleCollider2D circle;
    private Stats stats;
    private ProjectileGenerator projectileGenerator;

    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        stats = GetComponent<StatContainer>().stats;
        projectileGenerator = GetComponentInChildren<ProjectileGenerator>();
    }

    private void Update()
    {
        // translate input into movement
        if (Input.GetKey(KeyCode.A)) movement.x = -1;
        if (Input.GetKey(KeyCode.W)) movement.y = 1;
        if (Input.GetKey(KeyCode.S)) movement.y = -1;
        if (Input.GetKey(KeyCode.D)) movement.x = 1;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            projectileGenerator.UpdateAttack();
        }
    }

    private void FixedUpdate()
    {
        // collide on y axis
        hit = Physics2D.CircleCast(transform.position, circle.radius, new Vector2(0f, movement.y), Mathf.Abs(movement.y * Time.fixedDeltaTime), LayerMask.GetMask("Living", "Blocking"));
        if (hit.collider != null)
        {
            movement.y = 0f;
        }

        // collide on z axis
        hit = Physics2D.CircleCast(transform.position, circle.radius, new Vector2(movement.x, 0f), Mathf.Abs(movement.x * Time.fixedDeltaTime), LayerMask.GetMask("Living", "Blocking"));
        if (hit.collider != null)
        {
            movement.x = 0f;
        }

        if (movement != Vector3.zero)
        {
            // flip sprite
            if (movement.x > 0) transform.localScale = Vector3.one;
            else if (movement.x < 0) transform.localScale = faceleft;

            // move and reset
            transform.Translate(movement * stats.speed * Time.deltaTime);
            movement = Vector3.zero;
        }
    }
}
