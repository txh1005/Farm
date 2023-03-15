using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCow : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Animator amin;
    private void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        amin = GetComponent<Animator>();
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
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (transform.position.x<moveSpot.position.x)
            {
                transform.localScale = new Vector2(1,1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            while (Vector2.Distance(transform.position, moveSpot.position) > 0.2f)
            {
                amin.SetBool("isWalking", true);
                transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
                yield return null;
            }
        }
    }

}
