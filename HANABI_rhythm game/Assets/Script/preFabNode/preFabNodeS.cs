using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using debug = UnityEngine.Debug;

public class preFabNodeS : MonoBehaviour
{
    float distance = 5f;
    Stopwatch sw = new Stopwatch();

    bool SKeyOn = true;

    Vector3 Vec;
    public GameObject[] Go = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        sw.Start();
        StartCoroutine(Skey());
        Vec = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        if (sw.ElapsedMilliseconds > 7000)
        {
            singtonEmtion.GetInstance().missionHand();
            Instantiate(Go[3], Vec, Quaternion.identity);
            sw.Stop();
            Destroy(gameObject);//종료조건
        }
    }

    IEnumerator Skey()
    {
        Stopwatch sw = new Stopwatch(); // 스탑워치 돌리기
        sw.Start();                           //종료조건못찾음...

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                singtonEmtion.GetInstance().modleCount++;

               
                    if (sw.ElapsedMilliseconds > distance * 1000 - 100 && sw.ElapsedMilliseconds < distance * 1000 + 100)
                    {
                        //퍼펙트조건
                        Instantiate(Go[0], Vec, Quaternion.identity);
                        singtonEmtion.GetInstance().setPerfect();
                        singtonEmtion.GetInstance().SkeyTRUE();
                        Destroy(gameObject);
                    }
                    else if ((sw.ElapsedMilliseconds > distance * 1000 - 250 && sw.ElapsedMilliseconds < distance * 1000 - 100) || (sw.ElapsedMilliseconds > distance * 1000 + 100 && sw.ElapsedMilliseconds < distance * 1000 + 250))
                    {
                        //굿
                        Instantiate(Go[1], Vec, Quaternion.identity);
                        singtonEmtion.GetInstance().setGrate();
                        singtonEmtion.GetInstance().SkeyTRUE();
                        Destroy(gameObject);
                    }
                    else if ((sw.ElapsedMilliseconds > distance * 1000 - 400 && sw.ElapsedMilliseconds < distance * 1000 - 250) || (sw.ElapsedMilliseconds > distance * 1000 + 250 && sw.ElapsedMilliseconds < distance * 1000 + 400))
                    {
                        //bad
                        Instantiate(Go[2], Vec, Quaternion.identity);
                        singtonEmtion.GetInstance().setBad();
                        singtonEmtion.GetInstance().SkeyTRUE();
                        Destroy(gameObject);
                    }
                    singtonEmtion.GetInstance().downTRUE();


                if (Input.anyKey)
                {
                    yield break;
                }

            }
     
            

            yield return null;
        }
        yield return null;
    }
}
