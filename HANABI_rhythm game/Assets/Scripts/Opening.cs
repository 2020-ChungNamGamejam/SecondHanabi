using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public bool BeforeLoad = true;
    public bool IsAlphaDown = true;
    public Text openText;
    public float alphaSpeed = 0.03f; 

    private void Update()
    {
        Color Alpha;

        if (BeforeLoad)
        {

            Alpha = openText.color;

            if (IsAlphaDown)
            {
                Alpha.a = Alpha.a - alphaSpeed;
            }
            else
            {
                Alpha.a = Alpha.a + alphaSpeed;
            }

            if (openText.color.a >= 1f)
            {
                IsAlphaDown = true;
            }
            if (openText.color.a <= 0.01f)
            {
                IsAlphaDown = false;
            }

            openText.color = Alpha;

        }

    }
}
