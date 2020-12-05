using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public ParticleSystem[] ps = new ParticleSystem[4];
    // Start is called before the first frame update

    public void setPerfect(Vector3 Vec)
    {
        Instantiate(ps[0], Vec, Quaternion.identity);
        ps[0].Play();
    }


    public void setGood()
    {

    }

    public void setBad()
    {

    }
    public void setMiss()
    {


    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
