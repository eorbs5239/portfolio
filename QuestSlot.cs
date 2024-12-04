using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;

public class QuestSlot : MonoBehaviour
{
    public QuestData questData;

    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text informationText;
    [SerializeField]
    private TMP_Text missionText;


    void Update()
    {
        
    }
    public void UpdateQuestUI()
    {
        //Debug.Log("����Ʈ UI ����");

        if (questData != null)
        {
            titleText.text = questData.title;

            informationText.text = questData.Information;

            missionText.text = ""; //�ʱ�ȭ

            foreach (Mission mission in questData.missions)
            {
                string fText = ""; //���� ����

                if (mission.isClear)
                    fText = "<s>" + "- " + mission.mission + "</s>\n";
                else
                    fText = "- " + mission.mission + "\n";

                missionText.text += fText;
            }
        }


    }
}
