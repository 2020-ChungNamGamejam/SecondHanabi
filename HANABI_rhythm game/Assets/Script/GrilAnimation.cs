using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilAnimation : MonoBehaviour
{

  
    public int coutNow;

    enum girlState
    {
        idel,
        shot_l,
        idel2,
        shot_r
    }
    bool isIdels = true;
    bool isidels2 = true;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GirAimatioMove());
        coutNow = 0;
    }

    // Update is called once per frame
    void Update()
    {



    }
    private void FixedUpdate()
    {


    }


    IEnumerator GirAimatioMove()
    {
        while (true)
        {

            if (coutNow != singtonEmtion.GetInstance().modleCount)
            {

                if (coutNow % 2 == 0)
                {
                   
                    singtonEmtion.GetInstance().girl_shot_l();
                    coutNow = singtonEmtion.GetInstance().modleCount;
                    StartCoroutine(Courtineidel());
                }
                else if (coutNow % 2 == 1)
                {

                    singtonEmtion.GetInstance().girl_shot_r();
                    coutNow = singtonEmtion.GetInstance().modleCount;
                    StartCoroutine(Courtineidel());
                }
            }




            yield return null;
        }

    }
    IEnumerator Courtineidel()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
       
        singtonEmtion.GetInstance().girl_idel();


    }
}
