using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownPet : MonoBehaviour
{
    public GameObject baby;
    public GameObject grown;
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            baby.SetActive(false);
            grown.SetActive(true);
            grown.transform.position = baby.transform.position;
        }
    }
}
