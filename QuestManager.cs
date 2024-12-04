using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;

//����Ʈ ����
//����Ʈ ����

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
    //����Ʈ �Ϸ� �ڵ�


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
    
    void UpdateQuestUI() //����Ʈ ������Ʈ
    {
        bool hasActiveQuest = false; //����
        //int hasActiveQuestNum = 0;

        for (int i = 0 ; i < questList.Length; i++ ) 
        {
   
            questSlot[i].questData = questList[i];
            questSlot[i].UpdateQuestUI();

            //����Ʈ Ŭ����,���� ���η� UI Ȱ��ȭ
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

            // ��� �̼��� Ȯ��
            for (int i = 0; i < questList[questNum].missions.Length; i++)
            {
                if (questList[questNum].missions[i].isClear != true)
                {
                    //Ŭ���� �ȵ� �̼��� �߰ߵǴ�

                    //break;
                    UpdateQuestUI();
                    return; //�Լ� ����

                }
            }
            //������� �Լ��� ������ �Ǿ���. -> for���� ������ ���� Ŭ���� �ȵ� �̼��� ��ã��
            //�� Ŭ�����ߴ�.
            ClearQuest(questNum);

            // ���� ����Ʈ Ȱ��ȭ
            if (questNum + 1 < questList.Length && !questList[questNum + 1].started)
            {
                gameObject.SetActive(true);
                NextQuest(questNum + 1);
            }
        }
        else
        {
            //���� ���� ���� ����Ʈ��
        }
    }

    /*����Ʈ ���۽�
    - ���ι̼� ��� Ŭ����������� ���·� �ʱ�ȭ
    - ����Ʈ ��ü Ŭ���� ���� �ʱ�ȭ*/


}
