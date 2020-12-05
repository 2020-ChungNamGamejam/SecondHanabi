using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject IntroCanvas;
    public GameObject CharctorSelectCanvas;
    public Image coverIMG;

    public bool MaleCharactorSelect = false;
    public bool FemaleCharactorSelect = false;

    void Start()
    {
        Color color = coverIMG.color;
        color.a = 0f;
        coverIMG.color = color;
        IntroCanvas.SetActive(true);
        CharctorSelectCanvas.SetActive(false);
    }
}
