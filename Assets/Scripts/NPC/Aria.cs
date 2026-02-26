using UnityEngine;

public class Aria : MonoBehaviour
{
    public float speed = 3f;
    public float stopDistance = 0.05f;
    public Transform targetTransform;

    private Rigidbody2D rb2D;
    private Animator animator;

    private Vector2 movement;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (targetTransform == null)
        {
            movement = Vector2.zero;
            animator.SetBool("isRunning", false);
            return;
        }

        Vector2 direction = targetTransform.position - transform.position;
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            movement = direction.normalized;
            animator.SetBool("isRunning", true);

            // Flip
            if (movement.x > 0.01f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (movement.x < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            movement = Vector2.zero;
            animator.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
    }
}