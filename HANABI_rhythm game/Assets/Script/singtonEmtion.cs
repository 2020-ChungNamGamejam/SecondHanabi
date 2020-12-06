using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;



public class singtonEmtion : MonoBehaviour
{

    public static int mScore;

    public bool isAkey=false;
    public bool isSkey= false;
    public bool isDkey= false;
    public bool isJkey= false;
    public bool isKkey= false;
    int combe = 0;

    public int modleCount = 0;

    public int missCount = 0;

    public void girl_idel()
    {
        this.SetAnimation("idle", true, 0);
    }
    public void girl_shot_r()
    {
        this.SetAnimation("shot_r", true, 0);

    }
    public void girl_shot_l()
    {
        this.SetAnimation("shot_l", true, 0);
    }

    public int life = 30;

    public bool loseLife = false;

    enum state
    {
        perfect,
        grate,
        good,
        miss

    };
    state mState;

    public GameObject IPerfect;
    public GameObject IGreate;
    public GameObject IGood;
    public GameObject Imiss;

    public GameObject ePerfect;
    public GameObject eGreate;
    public GameObject eGood;
    public GameObject emiss;


    public bool isDown= false;
    public bool isEnd = false;

    public bool isMiissingHand = false;




    private singtonEmtion() { }
    private static singtonEmtion instance = null; 
    public static singtonEmtion GetInstance()
    { 
        if (instance == null)
        { 
            Debug.LogError("해당 오브젝트가 없다"); 
        } 
        return instance; 
    }

    public void Awake() 
    { 
        instance = this;
    }
    public void downTRUE()
    {
        isDown = true;
    
    }

    public void AkeyTRUE()
    {
        isAkey = true;
    }
    public void SkeyTRUE()
    {
        isSkey = true;
    }
    public void DkeyTRUE()
    {
        isDkey = true;
    }
    public void JkeyTRUE()
    {
        isJkey = true;
    }
    public void KkeyTRUE()
    {
        isKkey = true;
    }

    public void getEnd(bool End)
    {
        isEnd = End;
    }
    public bool setEnd()
    {
        return isEnd;
    }

    public void setPerfect()
    {
        mState = state.perfect;
 
    }

    public void setGrate()
    {
        mState = state.grate;

    }

    public void setBad()
    {
        mState = state.good;

    }
    public void setmiss()
    {
        mState = state.miss;


    }
    public void missionHand()
    {
        isMiissingHand = true;
    }
 


    public SkeletonAnimation skill;
    public GameObject girl, boy;
    private string cur_animation = "";
  

    private string CurrentAnimation;//재생



  


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.FemaleCharactorSelect)
        {
            girl.SetActive(true);
            skill = girl.GetComponent<SkeletonAnimation>();
        }
        else if (GameManager.MaleCharactorSelect)
        {
            boy.SetActive(true);
            skill = boy.GetComponent<SkeletonAnimation>();
        }
        else
        {
            Debug.Log("남녀 둘 다 선택되지 않은 예외");
        }
    }

    // Update is called once per frame
    void Update()
    {

      
   




        if (isMiissingHand)
        {
            loseLife = true;
            life -= 5;
            Instantiate(Imiss, new Vector3(0, 2.5f, 0), Quaternion.identity);
            Instantiate(emiss, new Vector3(0, 2.5f, 0), Quaternion.identity);
            isMiissingHand = false;
        }


        if (isDown)
        {
            

            if(!isAkey&&!isSkey && !isDkey && !isJkey && !isKkey)
            {
                //실패했을경우
                combe = 0; //콤보 초기화
                life -= 1;
                mState = state.miss;
                isDown = false;
                loseLife = true;
                Instantiate(Imiss, new Vector3(0, 2.5f, 0), Quaternion.identity);
                Instantiate(emiss, new Vector3(0, 2.5f, 0), Quaternion.identity);


            }
            //더 조건 넣어야됨 .
            else
            {
                combe++; //콤보 증가
                isDown = false;
                Debug.Log(mState);
                switch(mState)
                {
                    case state.perfect:
                        mScore += 100;
                        Instantiate(IPerfect, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        Instantiate(ePerfect, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        break;

                    case state.grate:
                        mScore += 75;
                        Instantiate(IGreate, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        Instantiate(eGreate, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        break;

                    case state.good:
                        mScore += 50;
                        Instantiate(IGood, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        Instantiate(eGood, new Vector3(0, 2.5f, 0), Quaternion.identity);
                        break;
                }
                
            }


        }
    }
   
     
    void SetAnimation(string name, bool loop, float speed)
    {
        if (name == cur_animation)
        {
            return;
        }
        else
        {
            skill.state.SetAnimation(0, name, loop).TimeScale = speed;
            cur_animation = name;
        }

    }
}
