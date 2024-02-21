using UnityEngine;

public class trapAnimController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public string animationName = "Trap4";
    public Collider2D collider1;
    public Collider2D collider2;

    void Start()
    {
        InvokeRepeating("PlayAnimation", 0f, 3f);
    }

    void PlayAnimation()
    {
        animator.Play(animationName, -1, 0f);
    }
    public void SetSpriteRendererActive()
    {
        spriteRenderer.enabled = true;
        collider1.enabled = true;
        collider2.enabled = true;

    }
    public void SetSpriteRendererDeActive()
    {
        spriteRenderer.enabled = false;
        collider1.enabled = false;
        collider2.enabled = false;
    }
}
