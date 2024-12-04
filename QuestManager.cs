using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;

//퀘스트 제목
//퀘스트 설명

[System.Serializable]
public class QuestData
{
    public string title;
    public string Information;
    public Mission[] missions;
    public bool started = false;
    public bool clear = false;

}

[System.Serializable]
public class Mission
{

    public string mission;
    public bool isClear = false;

    
}

public class QuestManager : MonoBehaviour
{
    public QuestData[] questList;

    public Transform slotContainer;
    
    public GameObject slotPrefab;
    
    public List<QuestSlot> questSlot;
    //퀘스트 완료 코드


    [SerializeField]
    private GameObject Key;
    void Start()
    {
        gameObject.SetActive(false);
        InitQuestUI();
    }

    // Update is called once per frame
    
    void Update()
    {
        /*if (Key != null)
        {
            DisableSetActive();
        }
        else
        {
            EnableSetActive();
        }*/

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        if (Key == null)
        {
            CheckMission(0, 0, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckMission(0, 1, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckMission(0, 2, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckMission(0, 3, true);
        }
        if (Input.GetKeyDown(KeyCode.P))
            StartQuest(1);
    }
    void InitQuestUI()
    {
        questSlot = new List<QuestSlot>();

        foreach(QuestData quest in questList)
        {
            GameObject newQuestSlot = Instantiate(slotPrefab, slotContainer);

            QuestSlot newSlot = newQuestSlot.GetComponent<QuestSlot>();
            newSlot.questData = quest;
            newSlot.UpdateQuestUI();

           if (!quest.started || quest.clear) 
                newSlot.gameObject.SetActive(false);

            questSlot.Add(newSlot);
        }
    }
    
    void UpdateQuestUI() //퀘스트 업데이트
    {
        bool hasActiveQuest = false; //없다
        //int hasActiveQuestNum = 0;

        for (int i = 0 ; i < questList.Length; i++ ) 
        {
   
            questSlot[i].questData = questList[i];
            questSlot[i].UpdateQuestUI();

            //퀘스트 클리어,수주 여부로 UI 활성화
            if (!questList[i].started || questList[i].clear)
            {
                questSlot[i].gameObject.SetActive(false);
            }
            else
            {
                questSlot[i].gameObject.SetActive(true);

                //hasActiveQuestNum += 1;
                hasActiveQuest = true;
            }
        }

        slotContainer.gameObject.SetActive(hasActiveQuest);

    }
    public void StartQuest(int num)
    {
        questList[num].started = true;
        UpdateQuestUI();

    }
    public void ClearQuest(int num)
    {
        questList[num].clear = true;

        UpdateQuestUI();

    }
    public void NextQuest(int num)
    {
        questList[num].started = true;
        gameObject.SetActive(false);
    }
    /*private void EnableSetActive()
    {
        
        if (Descipt != null)
        {
            Descipt.SetActive(false);
        }
    }

    private void DisableSetActive()
    {
        
        if (Descipt != null)
        {
            Descipt.SetActive(true);
        }
    }*/

    public void CheckMission(int questNum, int missionNum, bool isClear)
    {
        if (questList[questNum].started)
        {
            questList[questNum].missions[missionNum].isClear = isClear;

            // 모든 미션을 확인
            for (int i = 0; i < questList[questNum].missions.Length; i++)
            {
                if (questList[questNum].missions[i].isClear != true)
                {
                    //클리어 안된 미션이 발견되다

                    //break;
                    UpdateQuestUI();
                    return; //함수 끝냄

                }
            }
            //여기까지 함수가 진행이 되었다. -> for문을 돌리는 동안 클리어 안된 미션을 못찾음
            //다 클리어했다.
            ClearQuest(questNum);

            // 다음 퀘스트 활성화
            if (questNum + 1 < questList.Length && !questList[questNum + 1].started)
            {
                gameObject.SetActive(true);
                NextQuest(questNum + 1);
            }
        }
        else
        {
            //아직 받지 않은 퀘스트다
        }
    }

    /*퀘스트 시작시
    - 세부미션 모드 클리어되지않은 상태로 초기화
    - 퀘스트 전체 클리어 같이 초기화*/


}
