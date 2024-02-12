using UnityEngine;

public class trapAnimController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public string animationName = "Trap4";

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
    }
    public void SetSpriteRendererDeActive()
    {
        spriteRenderer.enabled = false;
    }
}
