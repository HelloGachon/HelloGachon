using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager_otl_sk : MonoBehaviour
{
    Dictionary<int, QuestData_otl_sk> questList;
    public OTManager_sk oManager;
    public TalkManager_otl_sk tManager;
    public GameObject[] questObject;
    public GameObject dialogPanel;
    public GameObject controlSet;
    public Text dialogName;
    public Text dialogText;
    public Image portraitImg;
    public bool isInteract;
    public bool isTalking;
    public bool isChoosing;
    public int btnId;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;
    public float getHealth;
    public float getPopular;
    public float getAlchol;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_otl_sk>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        isTalking = false;
        isChoosing = false;

        getPopular=GameData.gamedata.popular;
        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
    }
    
    void generateData()
    {
        // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
        questList.Add(10, new QuestData_otl_sk("선배님께 말걸자!", new int[] { 2000 }));
        questList.Add(20, new QuestData_otl_sk("오티 시작!", new int[] { 200, 2000 }));
        questList.Add(30, new QuestData_otl_sk("뒷풀이에 갈까?", new int[] { 2000 }));
        questList.Add(40, new QuestData_otl_sk("오티 씬 종료!", new int[] { 0 }));
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
        //Control Quest Object
        controlQuestObject();

        //Next Talk Target
        if (id == questList[questId].storyObjId[questActionIndex]) {
            questActionIndex++;
        }

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].storyObjId.Length) {
            nextQuest();
        }
        
        //Quest Name
        return questList[questId].questName;
    }

    void nextQuest()
    {
        questActionIndex = 0;
        questId += 10;
    }

    public void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 0) {
                    questObject[1].SetActive(true);                            
                }
                break;
            case 20:
                if(questActionIndex == 0 && oManager.objDataId == 200) {
                    isTalking = true;
                    oManager.isInteract = true;
                    questObject[0].SetActive(true);                                  
                }
                if(questActionIndex == 1) {
                    questObject[1].SetActive(false);
                }
                break;
            case 30:
                if(questActionIndex == 0) {
                    isChoosing = true;
                    questObject[2].SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    //선택지 버튼 눌렀을 때 실행되는 함수들
    // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
    public void on1BtnClick()
    {
        //1번 누르면 학번 및 홈페이지 설명
        questObject[0].SetActive(false);
        btnId = 3000;
        introduceTalk();
    }
    public void on2BtnClick()
    {
        //2번 누르면 수강신청 설명
        questObject[0].SetActive(false);
        btnId = 4000;
        introduceTalk();
    }
    public void on3BtnClick()
    {
        //3번 누르면 사이버캠퍼스 설명
        questObject[0].SetActive(false);
        btnId = 5000;
        introduceTalk();
    }
    public void on4BtnClick()
    {
        //4번 누르면 학사행정 설명
        questObject[0].SetActive(false);
        btnId = 6000;
        introduceTalk();
    }
    public void on5BtnClick()
    {
        //5번 누르면 비교과신청(WIND) 설명
        questObject[0].SetActive(false);
        btnId = 7000;
        introduceTalk();
    }
    public void on6BtnClick()
    {
        //6번 누르면 등록금 설명
        questObject[0].SetActive(false);
        btnId = 8000;
        introduceTalk();
    }
    public void onSkipBtnClick()
    {
        //건너뛰기 누르면 오티 씬 종료
        questObject[0].SetActive(false);
        btnId = 9000;
        isTalking = false;
        introduceTalk();
    }

    public void introduceTalk(){
        string talkName = tManager.getName(btnId, nameIndex);
        string talkData = tManager.getTalk(btnId, talkIndex);

        //End Talk
        if(talkData == null){
            isInteract = false;        
            oManager.isInteract = false;
            talkIndex = 0;
            oManager.talkIndex = 0;
            dialogPanel.SetActive(false);
            if(isTalking) {
                questActionIndex = 0;
                controlQuestObject();
            }
            else {                
                controlSet.SetActive(true);
                questActionIndex = 1;
                controlQuestObject();             
            }            
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됨
        }
        
        dialogName.text = talkName;
        dialogText.text = talkData.Split(':')[0];
        portraitImg.sprite = tManager.getPortrait(btnId, int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정

        isInteract = true;
        talkIndex++;

        dialogPanel.SetActive(true);
        controlSet.SetActive(false);
    }

    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isChoosing = false;

        //능력치 부여 및 저장
        getHealth-=5;
        getPopular+=10;
        getAlchol+=10;

        GameData.gamedata.health=getHealth;
        GameData.gamedata.popular=getPopular;
        GameData.gamedata.alchol=getAlchol;

        //참가하면 뒷풀이 씬으로 이동
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("OT_AfterParty_sk");
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isChoosing = false;
        
        //참가하지 않으면 수강신청 씬 진행
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("BeforeMiniGame1");
    }
}
