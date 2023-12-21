using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public GameObject head;
    public float damage;
    public Transform headPos;
    public GameObject earthquake;
    public Transform[] earthquakePos;
    public Animator anim;
    public float attack3range;
    public float attack2range;
    public float attack1range;
    private float timer;
    private GameObject player;
    private bool isLeft = true;
    [SerializeField] private GameObject[] spawnPoints;
    private int pointIndex = 0;
    private PolygonCollider2D punchCollider;
    private enum MovementState { idle, attack1, attack2, attack3}
    public float deathTime = 1f;
    void Start()
    {
        punchCollider = GetComponent<PolygonCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        punchCollider.enabled = false;
       
    }
    void Update()
    {
        newFlip();
        Animations();

    }
   
    
     void Animations()
    {

        MovementState state;
        float p = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log($"Distance to player: {p}");

        if (p < attack3range && p >= attack2range)
        {
            state = MovementState.attack3;
            anim.SetInteger("state", (int)state);
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                Instantiate(head, headPos.position, Quaternion.identity);
            }
        }
        else if (p < attack2range && p >= attack1range)
        {
            state = MovementState.attack2;
            anim.SetInteger("state", (int)state);
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                if (isLeft)
                {   
                    earthquake.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    Instantiate(earthquake, earthquakePos[0].position, Quaternion.identity);
                    
                }
                else
                {

                    earthquake.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    Instantiate(earthquake, earthquakePos[1].position, Quaternion.identity);
                    
                }
            }
        }

        else if (p < attack1range)
        {
            state = MovementState.attack1;
            anim.SetInteger("state", (int)state);
        }
        if (Input.GetKeyDown(KeyCode.J)) // caný 5 azalýyomuþ gibi düþün kýnýk
        {
            anim.SetTrigger("Teleport");
            pointIndex++;
        }
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            anim.SetTrigger("Hurt");
           

        }
       
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            anim.SetTrigger("Death");
            Invoke("Destroy", deathTime);

        }
       
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void newFlip()
    {

        float a = transform.position.x - player.transform.position.x;
        if (a > 0)
        {
            if (transform.localScale.x > 0)
            {
                flip();
                isLeft = true;
            }
        }

        else
        {
            if (transform.localScale.x < 0)
            {
                flip();
                isLeft = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attack1range);
        Gizmos.DrawWireSphere(transform.position, attack2range);
        Gizmos.DrawWireSphere(transform.position, attack3range);
    }
    public void Teleport()
    {
        gameObject.SetActive(false);

        if (pointIndex == 1)
        {
            transform.position = spawnPoints[0].transform.position;
        }
        if (pointIndex == 2)
        {
            transform.position = spawnPoints[1].transform.position;
        }
        if (pointIndex == 3)
        {
            transform.position = spawnPoints[2].transform.position;
        }
        if (pointIndex == 4)
        {
            transform.position = spawnPoints[3].transform.position;
        }
        if (pointIndex == 5)
        {
            transform.position = spawnPoints[4].transform.position;
        }

        gameObject.SetActive(true);
    }
   
    public void PunchAttack()
    {
       
        if (Vector2.Distance(transform.position, player.transform.position) < 2.4)
        {
            player.GetComponent<healthManager>().TakeDamage(damage);
        }
    }

    public void punchenable()
    {
       punchCollider.enabled = true;
    }

    public void punchdisable()
    {
        punchCollider.enabled = false;
    }

}