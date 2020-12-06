using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject[] mLife = new GameObject[6];
    public int realLife = 0;
    public int realhart = 6;



    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(realLife);
       



        if (singtonEmtion.GetInstance().loseLife == true)
        {
            realLife = singtonEmtion.GetInstance().life / 5;

            if (singtonEmtion.GetInstance().life < 1)
                SceneManager.LoadScene("End");
           if(singtonEmtion.GetInstance().life<=30&& singtonEmtion.GetInstance().life>0)
            {

               

                if (realLife != realhart)
                {
                    Destroy(mLife[(singtonEmtion.GetInstance().life / 5) ]);
                    realhart = realLife;
                }
            }
        }
        
    }
}
