using UnityEngine;

public class PlrAnimations : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    [SerializeField] private SpriteRenderer shadow;
    //[SerializeField] private ParticleSystem moveParticles;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("YVelocity", rb.linearVelocity.y);

        shadow.sprite = sprite.sprite;
    }

    public void SwitchEye()
    {
        animator.SetTrigger("EyeSwap");
    }
}
