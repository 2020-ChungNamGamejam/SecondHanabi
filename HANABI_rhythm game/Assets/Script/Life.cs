using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject[] mLife = new GameObject[6];



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (singtonEmtion.GetInstance().loseLife == true)
        {

            if (singtonEmtion.GetInstance().life < 1)
                SceneManager.LoadScene("End");
           if(singtonEmtion.GetInstance().life<=6&& singtonEmtion.GetInstance().life>0)
            {
                Debug.Log(singtonEmtion.GetInstance().life - 1);

                Destroy(mLife[singtonEmtion.GetInstance().life-1]);
                singtonEmtion.GetInstance().life--;
            }
        }
        
    }
}
