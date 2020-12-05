using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using debug = UnityEngine.Debug;

public class prefabNodeMove : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();

    private void Awake()
    {
        sw.Start();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        if(sw.ElapsedMilliseconds>7000)
        {
            sw.Stop();
            Destroy(gameObject);//종료조건
        }
    }
}
