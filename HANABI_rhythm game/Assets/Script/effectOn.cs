using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectOn : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EWffectOn", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void EWffectOn()
    {
        Debug.Log("log");
        Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);
        

    }

}
