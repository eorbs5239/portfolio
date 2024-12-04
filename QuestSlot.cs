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
        //Debug.Log("퀘스트 UI 갱신");

        if (questData != null)
        {
            titleText.text = questData.title;

            informationText.text = questData.Information;

            missionText.text = ""; //초기화

            foreach (Mission mission in questData.missions)
            {
                string fText = ""; //변수 지정

                if (mission.isClear)
                    fText = "<s>" + "- " + mission.mission + "</s>\n";
                else
                    fText = "- " + mission.mission + "\n";

                missionText.text += fText;
            }
        }


    }
}
