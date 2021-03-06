using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_heeots6 : MonoBehaviour
{
    Dictionary<int, QuestData_heeots3> questList;
    public GameObject[] questObject;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;

    //폰 알람
    public AudioSource phoneAlarm;
    public AudioSource roomBGM;
    public AudioSource barBGM;

    //참여할지 말지 클릭하는 판넬
    public GameObject talkPanel;

    //종강파티 이미지 넣을 것
    public GameObject FinishImage;

    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_heeots3>();
        roomBGM.Play();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        questObject[0].SetActive(true);
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_heeots3("카톡을 확인하자", new int[] {1000}));
        questList.Add(20, new QuestData_heeots3("끝", new int[] {0}));
        
    }

    public int getQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string checkQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    public string checkQuest(int id)
    {
        //Next Talk Target
        if (id == questList[questId].storyObjId[questActionIndex]) {
            questActionIndex++;
        }

        //Control Quest Object
        controlQuestObject();

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].storyObjId.Length) {
            nextQuest();
        }
        
        //Quest Name
        return questList[questId].questName;
    }

    void nextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 1 && isTouched == false) {

                    phoneAlarm.Stop(); //폰 알람
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                break;

            default:
                break;
        }
    }
    //폰 화면 나오고 꺼질때 쓰이는 함수
    public void touchPhone()
    {
        questObject[1].SetActive(false);
        isInteract = false;
        isTouched = true;
        talkPanel.SetActive(true);
    }

    //종강파티 이미지로 넘어가기 위한 함수
    public void onApplyBtnClick6()
    {
        questObject[2].SetActive(false);
        isInteract = false;

        roomBGM.Stop();

        //참여한다고 하면 종강파티 이미지 보여줌
        FinishImage.SetActive(true);
        barBGM.Play();
    }

    //종강파티 이미지를 클릭하면, 성적확인 엔딩 장면
    public void onApplyBtnClick6_1(){
        GameData.gamedata.health -= 2;
        GameData.gamedata.popular += 10;
        GameData.gamedata.alchol += 10;

        //능력치 보정
        //전공
        if(GameData.gamedata.major>100){GameData.gamedata.major=100;}
        else if(GameData.gamedata.major<0){GameData.gamedata.major=0;}
        //체력
        if(GameData.gamedata.health>100){GameData.gamedata.health=100;}
        else if(GameData.gamedata.health<0){GameData.gamedata.health=0;}
        //알코올 분해력
        if(GameData.gamedata.alchol>100){GameData.gamedata.alchol=100;}
        else if(GameData.gamedata.alchol<0){GameData.gamedata.alchol=0;}
        //인기도
        if(GameData.gamedata.popular>100){GameData.gamedata.popular=100;}
        else if(GameData.gamedata.popular<0){GameData.gamedata.popular=0;}
        //스트레스
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}
        else if(GameData.gamedata.stress>100){GameData.gamedata.stress=100;}
        
        SceneManager.LoadScene("Game_Ending_Scene_sk");
    }

    public void onNoBtnClick6()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        
        //참여하지 않으면  엔딩씬
        SceneManager.LoadScene("Game_Ending_Scene_sk");
    }
}
