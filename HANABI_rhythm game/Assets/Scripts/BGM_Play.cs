using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BGM_Play : MonoBehaviour
{
    public AudioSource TheAudio;

    // Start is called before the first frame update
    void Awake()
    {
        TheAudio = GetComponent<AudioSource>();
    }

    public void StopBGM() => TheAudio.Stop();
}
