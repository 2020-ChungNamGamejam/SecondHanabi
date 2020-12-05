using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class IngameSetCharacter : MonoBehaviour
{
    public int n { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        var skeleton = GetComponent<SkeletonAnimation>();
        var skeleton2 = GetComponent<SkeletonAnimation>();
        if (GameManager.FemaleCharactorSelect)
        {
            
        }
        else if (GameManager.MaleCharactorSelect)
        {
            
        }
        else
        {
            Debug.Log("fucking bug");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
