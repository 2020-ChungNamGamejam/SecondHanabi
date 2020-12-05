using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharSelect : MonoBehaviour
{
    public GameManager gameManager;
    

    [SerializeField] private AudioClip[] clip;
    private AudioSource TheAudio;

    public GameObject another;
    public GameObject coverIMG;
    public Image coverImage;

    Color32 CharAlpha;
    Color32 TextAlpha;

    Text char1Name;

    Image char1Img;

    string ObjName;

    private void Awake()
    {

        coverIMG.SetActive(false);
        TheAudio = GetComponent<AudioSource>();

        char1Img = transform.GetChild(0).GetComponent<Image>();
        char1Name = transform.GetComponentInChildren<Text>();

        GetComponent<Button>().onClick.AddListener(OnButton);

        Color32 color = char1Img.color;

        color.a = 80;
        char1Img.color = color;
        char1Name.color = color;
    }

    public void OnMouseEnter()
    {
        GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
        if (!gameManagerLogic.FemaleCharactorSelect && !gameManagerLogic.MaleCharactorSelect)
        {
            ObjName = gameObject.name;
            AudioOn();
            ImageEffect(ObjName);
        }
    }

    public void OnMouseExit()
    {
        GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
        if (!gameManagerLogic.MaleCharactorSelect && !gameManagerLogic.FemaleCharactorSelect)
        {
            ObjName = gameObject.name;
            AudioOff();
            ImageEffect(ObjName);
        }
    }

    void ImageEffect(string name)
    {
        CharAlpha = char1Img.color;
        TextAlpha = char1Name.color;
        ChangeAlpha(CharAlpha, char1Name, char1Img);
    }

    void ChangeAlpha(Color32 color, Text obj, Image obj2)
    {
        color.a = (byte)(color.a == 80 ? 255 : 80);
        obj.color = color;
        obj2.color = color;
    }

    void AudioOn()
    {
        GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
        if(gameManagerLogic)
        TheAudio.clip = clip[0];
        TheAudio.Play();
    }
    void AudioOff()
    {
        TheAudio.Stop();
    }

    public void OnButton()
    {

        GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
        if (!gameManagerLogic.FemaleCharactorSelect && !gameManagerLogic.MaleCharactorSelect)
        {
            if(gameObject.name == "Male")
            {
                gameManagerLogic.MaleCharactorSelect = true;
            }
            else
            {
                gameManagerLogic.FemaleCharactorSelect = true;
            }
            
            TheAudio.Stop();
            TheAudio.clip = clip[1];
            TheAudio.Play();
            coverIMG.SetActive(true);
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        Color color = coverImage.color;
        Color32 color32 = coverImage.color;
        color32.a = 0;
        coverImage.color = color32;

        while(color.a <= 1f)
        {
            color.a += Time.deltaTime;
            coverImage.color = color;
            yield return null;
        }

        color.a = 1f;
        coverImage.color = color;

        TheAudio.Stop();
        GameObject.FindObjectOfType<BGM_Play>().StopBGM();
        // 메임 게임 scene 전환 시점
    }
}
