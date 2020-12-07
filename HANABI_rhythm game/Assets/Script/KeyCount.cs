using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        singtonEmtion.mScore = 0;
        StartCoroutine(KeyCountNow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KeyCountNow()
    {
        while(true)
        { 

            if (Input.GetKeyDown(KeyCode.D))
            {
                singtonEmtion.GetInstance().modleCount++;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                singtonEmtion.GetInstance().modleCount++;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                singtonEmtion.GetInstance().modleCount++;

            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                singtonEmtion.GetInstance().modleCount++;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                singtonEmtion.GetInstance().modleCount++;

            }


           yield return null;

        }



    }
}
