using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node : MonoBehaviour
{
    public GameObject mNode;// 노드 속성받아오기
    float delayTime;



    //노드속성 아직 못찾음
    //노트의 키는 asdjk
    Dictionary<string, float> itemMap;


    // Start is called before the first frame update
    void Start()
    {
        itemMap = new Dictionary<string, float>();
        // 노드생성하기(미리 하기 )
       // itemMap["A"] = 1.0f;
        //itemMap["A"] = 2.0f;
        //itemMap["A"] = 3.0f;


        StartCoroutine(CreateNode());


        //추가적으로 늘리기
        // itemMap.Add("D", 2.0f);
        //itemMap.Add("S", 3.0f);
        //itemMap.Add("J", 4.0f);
        //itemMap.Add("K", 5.0f);
    }
        

    // Update is called once per frame
    void Update()
    {
       
    }

    
    IEnumerator CreateNode()
    {
        var listNode = itemMap.Values.ToList();
        float fristNode = 0;
        float secondNode = listNode[0];
        int count = 0;
        Debug.Log("1");

   
       

        while (true)
        {
    
            if (listNode.Count < count)
            {
                break;
            }
            
            yield return new WaitForSeconds(secondNode- fristNode);
            Debug.Log("a");

            fristNode = secondNode;
            secondNode = listNode[count+1];
            count++;
        }



        yield return null;
    }
    /*
     * 
     * foreach(KeyValuePair<string, string> item in myTable) {
				Console.WriteLine("[{0}:{1}]", item.Key, item.Value); 
     */
}
