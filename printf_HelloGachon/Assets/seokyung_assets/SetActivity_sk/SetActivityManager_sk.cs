using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetActivityManager_sk : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;
    public int Count = 5;
    public string getGroup;
    public GameObject clubBtn;
    public Text majortext;
    public Text stresstext;
    public Text healthtext;
    public Text populartext;
    public Text alcholtext;
    public Text infoTxt;
    public GameObject w1Panel;
    public Text w1Txt;
    public GameObject w2Panel;
    public Text w2Txt;
    public GameObject w3Panel;
    public Text w3Txt;
    public GameObject w4Panel;
    public Text w4Txt;
    public GameObject w5Panel;
    public Text w5Txt;
    public float getHealth;
    public float getPopular;
    public float getStress;
    public float getMajor;
    public float getAlchol;  
    private Color32 activityColor;
    private string activityName;
    public GameObject schedulePanel;
    public GameObject activityPanel;
    public GameObject player;
    
    private void Awake() {
        audioSource = this.GetComponent<AudioSource>(); 
    }
    void Start()
    {
        //GameData 사용 시 코드
        majortext.text="전공 : "+GameData.gamedata.major;
        stresstext.text="스트레스 : "+GameData.gamedata.stress;
        healthtext.text="체력 : "+GameData.gamedata.health;
        populartext.text="인기도 : "+GameData.gamedata.popular;
        alcholtext.text="알코올 분해력 : "+GameData.gamedata.alchol;
        infoTxt.text = " ";

        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getGroup=GameData.gamedata.groupname;

        if(GameData.gamedata.groupname!="")
            clubBtn.SetActive(true);
<<<<<<< HEAD
        bgmstart();
=======

        schedulePanel.SetActive(true);
        activityPanel.SetActive(true);
        player.SetActive(true);

        /*
        getMajor = 0;
        getStress = 0;
        getHealth = 100;
        getAlchol = 0;
        getPopular = 0;        
        getGroup = "Music";

        //로직 확인용 더미데이터
        majortext.text="전공 : " + getMajor;
        stresstext.text="스트레스 : " + getStress;
        healthtext.text="체력 : " + getHealth;
        populartext.text="인기도 : " + getPopular;
        alcholtext.text="알코올 분해력 : " + getAlchol;
        infoTxt.text = " ";
        */
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
    }

    private void Update() {
        majortext.text="전공 : "+getMajor;
        stresstext.text="스트레스 : "+getStress;
        healthtext.text="체력 : "+getHealth;
        populartext.text="인기도 : "+getPopular;
        alcholtext.text="알코올 분해력 : "+getAlchol;
        if(getMajor<0)
            getMajor=0;
        if(getStress<0)
            getStress=0;
        if(getHealth<0)
            getHealth=0;
        if(getPopular<0)
            getPopular=0;
        if(getAlchol<0)
            getAlchol=0;
    }
    public void bgmstart()
    {
        audioSource.clip=audioClip;
        audioSource.Play();
    }
    public void abilityChange(string type)
    {
        switch(type)
        {
            case "Drink":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getAlchol+=5;
                    getPopular+=5;
                    getMajor-=3;

                    activityColor = new Color32(138, 255, 143, 255);
                    activityName = "술약속";
                    infoTxt.text = "오늘 먹고 죽는거야~~~\n전공 -3, 인기도 +5,\n체력 -5, 알코올 분해력 +5";
                }
                break;
            case "Health":
                if(Count>0)
                {
                    Count--;
                    getHealth+=5;
                    getStress-=5;


<<<<<<< HEAD
                    w2Panel.GetComponent<Image>().color = new Color32(255, 99, 88, 225);
                    w2Txt.text = "운동";
                    infoTxt.text = "앉아만 있지 말고 운동 좀 해";
=======
                    activityColor = new Color32(255, 99, 88, 225);
                    activityName = "운동";
                    infoTxt.text = "코딩하려면 일단 살아는 있어야겠지\n체력 +5, 스트레스 -5,";
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
                }
                break;
            case "Study":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getStress+=5;
                    getMajor+=5;

                    activityColor = new Color32(104, 142, 225, 225);
                    activityName = "스터디";
                    infoTxt.text = "공부에는 왕도가 없다!\n전공 +5, 체력 -5,\n스트레스 +5";
                }
                break;
            case "Interest":
                if(Count>0&&getHealth>4)
                {
                   Count--;
                    getHealth-=5;
                    getStress-=3;
                    getPopular+=5;

                    activityColor = new Color32(255, 227, 88, 255);
                    activityName = "취미\n활동";
                    infoTxt.text = "하고 싶었던거 다 해볼거야!!\n인기도 +5, 체력 -5,\n스트레스 -3";
                }
                break;
            case "Club":
                if(Count>0)
                {
                    if(getGroup=="Music"&&getHealth>2)
                    {
                        Count--;
                        getStress-=5;
                        getHealth-=3;
                        getPopular+=3;
                        getAlchol+=5;
<<<<<<< HEAD
=======
                        infoTxt.text = "동방가서 누워서 기타쳐야지~\n인기도 +3, 체력 -3,\n스트레스 -5, 알코올 분해력 +5";
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)

                    }else if(getGroup=="Religion"&&getHealth>2)
                    {
                        Count--;
<<<<<<< HEAD
                        getStress+=3;
                        getHealth-=3;
                        getAlchol+=5;
                        getMajor+=5;
                    }else if(getGroup=="Major"&&getHealth>4)
=======
                        getStress-=7;
                        getHealth-=3;
                        getAlchol-=5;
                        infoTxt.text = "비나이다 비나이다 오류없이 실행되게 해주세요\n체력 -3, 스트레스 -7,\n알코올 분해력 -5";
                    }else if(getGroup=="Major")
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
                    {
                        Count--;
                        getHealth-=3;
                        getMajor+=5;
                        getStress+=3;
                        getAlchol+=5;
                        infoTxt.text = "동아리 친구들이랑 공부하다 술마시러 가야지~\n인기도 +3, 체력 -3,\n스트레스 -5, 알코올 분해력 +5";
                    }else if(getGroup=="Health")
                    {
                        Count--;
                        getStress-=5;
                        getHealth+=5;
                        getAlchol-=3;
<<<<<<< HEAD
                    }else if(getGroup=="Perpormance"&&getHealth>4)
=======
                        infoTxt.text = "아 근손실은 못참지 ㅋㅋ\n체력 +5, 스트레스 -5,\n알코올 분해력 -3";
                    }else if(getGroup=="Perpormance")
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
                    {
                        Count--;
                        getStress-=5;
                        getHealth-=5;
                        getPopular+=5;
                        getAlchol+=5;
<<<<<<< HEAD
                    }else if(getGroup=="Hobby"&&getHealth>2)
=======
                        infoTxt.text = "동아리 공연 준비해야지~\n인기도 +5, 체력 -5,\n스트레스 -5, 알코올 분해력 +5";
                    }else if(getGroup=="Hobby")
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
                    {
                        Count--;
                        getStress-=5;
                        getHealth-=3;
                        getAlchol+=5;
<<<<<<< HEAD
=======
                        infoTxt.text = "오늘은 동아리 친구들이랑 뭘 해볼까나~?\n체력 -3, 스트레스 -5,\n알코올 분해력 +5";
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
                    }

                    activityColor = new Color32(255, 167, 236, 225);
                    activityName = "동아리";
                }
                break;
        }

        if(Count == 4) {
            w1Panel.GetComponent<Image>().color = activityColor;
            w1Txt.text = activityName;
        }
        else if(Count == 3) {
            w2Panel.GetComponent<Image>().color = activityColor;
            w2Txt.text = activityName;
        }
        else if(Count == 2) {
            w3Panel.GetComponent<Image>().color = activityColor;
            w3Txt.text = activityName;
        }
        else if(Count == 1) {
            w4Panel.GetComponent<Image>().color = activityColor;
            w4Txt.text = activityName;
        }
        else if(Count == 0) {
            w5Panel.GetComponent<Image>().color = activityColor;
            w5Txt.text = activityName;
        }
    }

    public void resetChange()
    {
        Count = 5;

        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        
        /*
        getMajor = 0;
        getStress = 0;
        getHealth = 100;
        getAlchol = 0;
        getPopular = 0;
        */
        
        w1Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w1Txt.text = "";
        w2Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w2Txt.text = "";
        w3Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w3Txt.text = "";
        w4Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w4Txt.text = "";
        w5Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w5Txt.text = "";
    }

    public void doActivity()
    {
        schedulePanel.SetActive(false);
        activityPanel.SetActive(false);
        player.SetActive(false);
        Debug.Log("do Activities");
    }

    public void Complete()
    {
        GameData.gamedata.health=getHealth;
        GameData.gamedata.alchol=getAlchol;
        GameData.gamedata.major=getMajor;
        GameData.gamedata.popular=getPopular;
        GameData.gamedata.stress=getStress;
        if(GameData.gamedata.month=="3월"){
            GameData.gamedata.month="4월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom3");
        }
        else if(GameData.gamedata.month=="4월")
        {
            GameData.gamedata.month="5월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom4");
            
        }else if(GameData.gamedata.month=="5월")
        {
            GameData.gamedata.month="6월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("SYGFestivalStart");
        }else if(GameData.gamedata.month=="6월")
        {
<<<<<<< HEAD
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Game_Ending_Scene_sk");
=======
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom6");
>>>>>>> b4790b1 (Feat: 육성 로직 구현 및 씬과 GameData 연결)
        }
    }
}