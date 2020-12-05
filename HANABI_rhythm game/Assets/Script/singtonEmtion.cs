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
    private string cur_animation = "";
    public enum animState
    {
        idel, shot_l, shot_r


    }

    private animState _animState;//처리
    private string CurrentAnimation;//재생

    public void LeftShot()
    {
        SetAnimation("shot_l", true, 1.0f);
    }

    public void r()
    {
        SetAnimation("shot_l", true, 1.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(combe==0)
            SetAnimation("idle", true, 0.01f);


        if (isMiissingHand)
        {
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
                mState = state.miss;
                isDown = false;
                Instantiate(Imiss, new Vector3(0, 2.5f, 0), Quaternion.identity);
                Instantiate(emiss, new Vector3(0, 2.5f, 0), Quaternion.identity);


            }
            //더 조건 넣어야됨 .
            else
            {
                combe++; //콤보 증가
               if(combe%2==0)
                {
                    SetAnimation("shot_l", true, 0.01f);
                }
               if(combe%2==1)
                {
                    SetAnimation("shot_r", true, 0.01f);
                }
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
