using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Vector3 moveSpot = Vector3.zero;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Animator amin;
    private GameObject player;
    public float avoidanceRadius = 2.0f;
    public float avoidanceWeight = 2.0f;
    private void Start()
    {
        waitTime = startWaitTime;
        amin = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveToNextSpot());
    }
    private void Update()
    {

    }
    private IEnumerator MoveToNextSpot()
    {
        while (true)
        {
            amin.SetBool("isWalking", false);
            yield return new WaitForSeconds(waitTime);
            moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (transform.position.x < moveSpot.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            while (Vector2.Distance(transform.position, moveSpot) > 0.2f)
            {
                Vector3 directionToPlayer = transform.position - player.transform.position;
                float distanceToPlayer = directionToPlayer.magnitude;
                Vector3 avoidance = Vector3.zero;

                if (distanceToPlayer < avoidanceRadius)
                {
                    avoidance = directionToPlayer.normalized * avoidanceWeight;
                }

                Vector3 moveDirection = (moveSpot - transform.position + avoidance).normalized;
                transform.position += moveDirection * speed * Time.deltaTime;

                amin.SetBool("isWalking", true);
                transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
