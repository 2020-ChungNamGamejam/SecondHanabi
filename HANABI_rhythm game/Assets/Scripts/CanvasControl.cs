using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public GameObject logo;
    public GameObject CharactorSelect;
    public GameObject BgmPlayer;
    public GameObject MenuCanvas;
    public GameObject OpenIgmage;
    public GameObject ButtonIgmage;
    public GameObject HowToPlayIgmage;
    public GameObject BackGroundIMG;

    private BGM_Play bgmPlay;

    [SerializeField] private AudioClip[] clip;
    private AudioSource TheAudio;

    public bool IsKeyInput = false;

    private void Start()
    {
        logo = Instantiate(logo);
        logo.SetActive(true);

        TheAudio = GetComponent<AudioSource>();
        bgmPlay = BgmPlayer.GetComponent<BGM_Play>();

        CharactorSelect.SetActive(false);
        OpenIgmage.SetActive(true);
        ButtonIgmage.SetActive(false);
        HowToPlayIgmage.SetActive(false);
        BackGroundIMG.SetActive(true);
        Debug.Log($"bgmplay : {bgmPlay}, theaudio : {bgmPlay.TheAudio}");
        bgmPlay.TheAudio.Play();
    }

    private void Update()
    {
        if (!IsKeyInput && Input.anyKeyDown)
        {
            effectSound(0);
            Canvas_Control("Start");
            IsKeyInput = true;
        }
    }

    public void Canvas_Control(string type)
    {
        switch (type)
        {
            case "Start":
                Debug.Log("Start");
                logo.SetActive(true);
                OpenIgmage.SetActive(false);
                ButtonIgmage.SetActive(true);
                HowToPlayIgmage.SetActive(false);
                BackGroundIMG.SetActive(true);
                break;

            case "HowToPlay":
                Debug.Log("HowToPlay");
                logo.SetActive(false);
                OpenIgmage.SetActive(false);
                ButtonIgmage.SetActive(false);
                HowToPlayIgmage.SetActive(true);
                BackGroundIMG.SetActive(true);
                break;

            case "Exit":
                Debug.Log("Exit");
                logo.SetActive(true);
                OpenIgmage.SetActive(false);
                ButtonIgmage.SetActive(true);
                HowToPlayIgmage.SetActive(false);
                BackGroundIMG.SetActive(true);
                break;

            case "Play":
                Debug.Log("Play");
                logo.SetActive(false);
                CharactorSelect.SetActive(true);
                MenuCanvas.SetActive(false);
                break;
        }
    }

    /*
     * 0 : Press Any Key Sound
     * 1 : Game Start Sound
     * 2 : How To Play sound
     */

    public void HowToPlay_Button_On()
    {
        effectSound(2);
        Canvas_Control("HowToPlay");
    }

    public void Exit_Button_On()
    {
        Canvas_Control("Exit");
    }
    public void Play_Button_On()
    {
        effectSound(1);
        Canvas_Control("Play");
    }

    public void effectSound(int songnum)
    {
        TheAudio.clip = clip[songnum];
        TheAudio.Play();
    }
}
