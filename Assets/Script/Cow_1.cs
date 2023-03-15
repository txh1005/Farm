using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cow_1: MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator amin;
    public Vector2 startPos;
    public float distance;
    public float speed;
    private int flip=1;

    private Vector2 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBtw = Vector2.Distance(startPos, transform.position);
        if (distance<distanceBtw)
        {
            if (transform.position.x>startPos.x && flip==1)
            {
                flip = -1;
                
            }
            else if(transform.position.x < startPos.x && flip == -1)
            {
                flip = 1;
            }
        }
        rigid.velocity = new Vector2(speed*flip,rigid.velocity.y);
        transform.localScale = new Vector2(flip, 1);
        amin.SetBool("isWalking", true);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (!Application.isPlaying)
        {
            startPos = transform.position;
        }
        Gizmos.DrawLine(new Vector2(startPos.x - distance, startPos.y), new Vector2(startPos.x + distance, startPos.y));
    }
}
