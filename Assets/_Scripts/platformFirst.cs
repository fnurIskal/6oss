using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class platformFirst : MonoBehaviour
{

    [SerializeField] private GameObject[] points = null;
    [SerializeField] private float speed;
    private int currentPoint = 0;

    void Update()
    {


        if (currentPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[0].transform.position) < 0.2f)
                currentPoint = 1;
        }
        else if (currentPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[1].transform.position) < 0.2f)
                currentPoint = 0;
        }
    }
}
