using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilAnimation : MonoBehaviour
{

    public GameObject G_RightPrticle;
    public GameObject G_leftPrticle;


    enum girlState
    {
        idel,
        shot_l,
        shot_r
    }
    bool isIdels=true;
    bool isidels2 = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (singtonEmtion.GetInstance().modleCount%4==1)
        {
            singtonEmtion.GetInstance().girl_idel();
            isIdels = false;
            isidels2 = false;
        }
       else if (singtonEmtion.GetInstance().modleCount%4 == 3)
        {
            singtonEmtion.GetInstance().girl_idel();
            isIdels = false;
            isidels2 = false;
        }
       

    }
    private void FixedUpdate()
    {

   
    }

}
