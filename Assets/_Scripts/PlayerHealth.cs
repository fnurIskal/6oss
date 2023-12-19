using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private Animator anim;
    private bool isDeath = false;
 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0 && !isDeath)
        {
            isDeath = true;
            anim.SetTrigger("Death");
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        anim.SetTrigger("Damage");
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
    void loadScene()
    {
        SceneManager.LoadScene("level1");
    }
}
