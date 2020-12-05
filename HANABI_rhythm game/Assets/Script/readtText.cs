using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class readtText : MonoBehaviour
{
    List<int> KeyA = new List<int>();
    List<int> KeyS = new List<int>();
    List<int> KeyD = new List<int>();
    List<int> KeyJ = new List<int>();
    List<int> KeyK = new List<int>();

    float delaytime = 0.571428571428571f;
    public GameObject prefabNodeA;
    public GameObject prefabNodeS;
    public GameObject prefabNodeD;
    public GameObject prefabNodeJ;
    public GameObject prefabNodeK;

    void Start()
    {
        // string path = @"C:/Users/82108/WorkSpace/SecondHanabi/HANABI_rhythm game/Assets/text/sampleExample.txt";
        string path = Application.dataPath + @"\sampleExample.txt";
        string[] textValue = System.IO.File.ReadAllLines(path);

        if (textValue.Length > 0)
        {
            for (int i = 0; i < textValue.Length; i++)
            {
                for (int j = 0; j < textValue[i].Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            KeyA.Add(textValue[i][j]-48);
                            break;
                        case 1:
                            KeyS.Add(textValue[i][j] - 48);
                            break;
                        case 2:
                            KeyD.Add(textValue[i][j] - 48);
                            break;
                        case 3:
                            KeyJ.Add(textValue[i][j] - 48);
                            break;
                        case 4:
                            KeyK.Add(textValue[i][j] - 48);
                            break;
        
                    }

                }

            }

        }
        StartCoroutine(CreateNodeA());
        StartCoroutine(CreateNodeS());
        StartCoroutine(CreateNodeD());
        StartCoroutine(CreateNodeJ());
        StartCoroutine(CreateNodeK());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateNodeA()
    {
        int count = 0;

        while (true)
        {

            if (KeyA.Count - 1 < count)
                break;

            if (KeyA[count] == 1)
                Instantiate(prefabNodeA, new Vector3(-3, -5, 0), Quaternion.identity);





            yield return new WaitForSeconds(delaytime);
            count++;
        }


        yield return null;
    }

    IEnumerator CreateNodeS()
    {
        int count = 0;

        while (true)
        {

            if (KeyS.Count - 1 < count)
                break;

            if (KeyS[count] == 1)
                Instantiate(prefabNodeS, new Vector3(-1, -5, 0), Quaternion.identity);





            yield return new WaitForSeconds(delaytime);
            count++;
        }


        yield return null;
    }

    IEnumerator CreateNodeD()
    {
        int count = 0;

        while (true)
        {

            if (KeyD.Count - 1 < count)
                break;

            if (KeyD[count] == 1)
                Instantiate(prefabNodeD, new Vector3(1, -5, 0), Quaternion.identity);





            yield return new WaitForSeconds(delaytime);
            count++;
        }


        yield return null;
    }

    IEnumerator CreateNodeJ()
    {
        int count = 0;

        while (true)
        {

            if (KeyJ.Count - 1 < count)
                break;

            if (KeyJ[count] == 1)
                Instantiate(prefabNodeJ, new Vector3(3, -5, 0), Quaternion.identity);





            yield return new WaitForSeconds(delaytime);
            count++;
        }


        yield return null;
    }

    IEnumerator CreateNodeK()
    {
        int count = 0;

        while (true)
        {

            if (KeyK.Count-1 < count)
                break;

            if (KeyK[count] == 1)
                Instantiate(prefabNodeK, new Vector3(5, -5, 0), Quaternion.identity);





            yield return new WaitForSeconds(delaytime);
            count++;
        }


        yield return null;
    }

 

}
