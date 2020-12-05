using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mScore : MonoBehaviour
{
    public Text tex;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tex.text = singtonEmtion.mScore.ToString();
    }
}
