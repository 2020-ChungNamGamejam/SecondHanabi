using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameManager : MonoBehaviour
{
    public AudioSource audio;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

        if (!audio.isPlaying)
        {
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("End");
    }
}
