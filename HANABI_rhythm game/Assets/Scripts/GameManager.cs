using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject IntroCanvas;
    public GameObject CharctorSelectCanvas;
    public Image coverIMG;

    public static bool MaleCharactorSelect = false;
    public static bool FemaleCharactorSelect = false;

    void Start()
    {
        MaleCharactorSelect = false;
        FemaleCharactorSelect = false;

        if (Instance == null)
        {
            Instance = this;
        }
        
        Color color = coverIMG.color;
        color.a = 0f;
        coverIMG.color = color;
        IntroCanvas.SetActive(true);
        CharctorSelectCanvas.SetActive(false);
    }
}
