using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("endPrefab", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void endPrefab()
    {
        Destroy(gameObject);
    }
}
