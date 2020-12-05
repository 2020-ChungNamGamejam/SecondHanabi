using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class IngameSetCharacter : MonoBehaviour
{
    public SkeletonAnimation Girl;
    public SkeletonAnimation Boy;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Char start");
        
        var skeleton = GetComponent<SkeletonAnimation>();

        

        /*
        if (GameManager.FemaleCharactorSelect)
        {
            skeleton = Girl;
        }
        else if (GameManager.MaleCharactorSelect)
        {
            skeleton = Boy;
        }
        else
        {
            Debug.Log("fucking bug");
        }
        */
    }
}
