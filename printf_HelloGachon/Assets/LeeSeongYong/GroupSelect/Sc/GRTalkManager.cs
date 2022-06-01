using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GRTalkManager : MonoBehaviour
{
    
    Dictionary<int, string[]> talkData;
    Dictionary<int, string[]> talkName;
    Dictionary<int, Sprite> portraitData;
    private AudioSource audioSource;
    public AudioClip audioClip; 
    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;
    public GameObject border;
    public GameObject SeePan;
    public GameObject ActionBtn;
    public GameObject talkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject newStu; //newStu 오브젝트
    public GameObject mudang; //mudang 오브젝트
    public GameObject mudangQuest; // 무당이 내릴때 누르는 버튼
    public GameObject ChoicPanel;
    public GameObject fadePanel;
    public GRQuestManager questManager;
    public GameObject friend;
    public GRManager gameManager;
    public GameObject Portal;
    public int ChoiceCount=0;
    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    public int frId;
    Vector3 pos2;
    string[] Yes={"좋았어! 프리덤 광장으로 가보자:2","기대 되는 걸!:2"};
    string[] No={"아쉽지만 어쩔 수 없지...:0"};
    string[] StartGR={"프리덤 광장에서 동아리 홍보전을 하고 있어!:0","무슨 동아리가 있을지 정말 궁금 한데?:0","같이 구경하러 갈래?:2"};
    string[] StartMT={"안녕? 우리 학과가 이번에 MT를 가게 되었어.:0","MT에 가면 동기들과 게임도 하고 같이 술도 마시면서 친해질 수 있는 좋은 기회야!:2","혹시 술을 못 마시더라도 괜찮아! 술은 적당히 마셔도 된다구:2","혹시 MT갈 생각 있니?:2"};
    string[] YesMT={"좋은 생각이야!:0","그럼 우리 대운동장에서 만나자!:2"};
    string[] NoMT={"아쉽지만 어쩔 수 없지:2"};
    string[] GoMT={"어서 와!:0","가서 재밌게 놀아보자고! 술은 너가 마시고 싶은 만큼만 마시면 되는걸 명심해!:2","그럼 출발!:2"};
    string[] StartaHan={"한마음 페스티벌이라는 것이 열린다고 해!:0","대체 무슨 축제일까? 너무 기대되는 걸!:0","선배님에게 가보자!:2"};
    string[] talkHan={"어서 와 한마음 페스티벌에 갈 준비가 되었니?:0","선배님! 한마음 페스티벌이 열린다는데 한마음 축제가 뭔가요?:2","한마음 페스티벌 일명 한마페는 5월달에 열리는 일종의 체육대회와 물놀이를 합친 축제야:1","가천대 WIND 시스템을 통해서 사전신청을 할 수 있지:0","사전신청을 한 학우들에게는 한마페 티셔츠와 경품 추첨 팔찌를 준다고:1","혹시라도 사전 신청을 못했어도 걱정하지마. 현장에서 참여할 수 있어:0","단!!! 한마페의 드레스코드는 파란색 상의라는걸 알아둬!:0","뿐만 아니라 축하 공연과 EDM공연도 있으니 재밌게 놀 수가 있다고!! 다들 파란색 티셔츠는 준비했지?:1","네! 준비 했어요!!:4","가서 물놀이도 즐기고 공연도 즐겨보자 너무 재밌을거 같아!!:5"};

    void Awake()
    {        
        rb = mudang.GetComponent<Rigidbody2D>();
        rb2=friend.GetComponent<Rigidbody2D>();
        talkData = new Dictionary<int, string[]>(); //대화에 문장이 여러개 존재
        portraitData = new Dictionary<int, Sprite>();
        audioSource = this.GetComponent<AudioSource>();
        talkName = new Dictionary<int, string[]>();
        GenerateData();
    }
    private void Start() {
        if(gameManager.success)
            Portal.SetActive(true);
    }
    //대화 생성하기
   void GenerateData(){

       //buildings
       talkData.Add(30,StartGR);
       talkData.Add(40,StartMT);
       talkData.Add(50,GoMT);
       talkData.Add(10+ 50,GoMT);
       talkData.Add(70,StartaHan);
       talkData.Add(10+ 70,StartaHan);
       talkData.Add(5,GoMT);
       talkData.Add(120+ 5,talkHan);
       talkData.Add(100, new string[] {"이곳은 카페다. 카페이름은 파스쿠치이다."});
       talkData.Add(200, new string[] {"이곳은 IT대학이다. AI공학관이 지어지기 전에 컴퓨터공학과 학생들이 수업을 듣던 곳이다."});
       talkData.Add(300, new string[] {"이곳은 비전타워다. 가천컨벤션센터, 우편취급국, 은행, 강의실 등이 있다."});
       talkData.Add(400, new string[] {"이곳은 비전타워다. 비전타워는 두 개의 건물이 연결되어 있다."});
       talkData.Add(500, new string[] {"이곳은 AI공학관이다. 컴퓨터공학과 학생들이 주로 사용하는 곳이다."});
       talkData.Add(600, new string[] {"이곳은 바이오나노연구원이다."});
       talkData.Add(700, new string[] {"이곳은 한의과대학이다."});
       talkData.Add(800, new string[] {"이곳은 산학관이다."});
       talkData.Add(900, new string[] {"이곳은 바이오나노대학이다."});
       talkData.Add(10000, new string[] {"이곳은 체육대학2이다."});
       talkData.Add(20000, new string[] {"이곳은 학군단이다."});
       talkData.Add(30000, new string[] {"이곳은 기숙사다."});
       talkData.Add(40000, new string[] {"이곳은 편의점이다. 편의점은 세븐일레븐이다."});
       talkData.Add(50000, new string[] {"이곳은 학생회관이다."});
       talkData.Add(60000, new string[] {"이곳은 중앙도서관이다."});
       talkData.Add(70000, new string[] {"이곳은 교육대학원이다."});
       talkData.Add(80000, new string[] {"이곳은 전자정보도서관이다."});
       talkData.Add(90000, new string[] {"이곳은 글로벌센터다."});
       talkData.Add(100000, new string[] {"이곳은 체육대학1이다."});
       talkData.Add(200000, new string[] {"이곳은 대학원이다."});
       talkData.Add(300000, new string[] {"이곳은 공과대학2이다."});
       talkData.Add(400000, new string[] {"이곳은 프리덤광장이다."});
       talkData.Add(500000, new string[] {"이곳은 가천관이다."});
       talkData.Add(600000, new string[] {"이곳은 인피니티동상이다."});
       talkData.Add(700000, new string[] {"이곳은 대운동장이다."});



      
        //선배 default 대사
       talkData.Add(2000, new string[] {"안녕?:0", 
                                        "혹시 궁금한게 있니?:0"});
        //무당이 default 대사
       talkData.Add(3000, new string[] {"탑승하시겠습니까?"});


       //Quest Talk(퀘스트 넘버 + npc 넘버)
       //Quest_1 1월      
       talkData.Add(10+ 1000,StartaHan);
       talkData.Add(11+ 2000, talkHan);
       talkData.Add(12+ 2000, new string[]{"예시:0"});

       //Quest_2 오리엔테이션
       talkData.Add(20+ 2000, new string[] {"AI공학관에 들어가면 오리엔테이션을 진행할거야! :0"});
       talkData.Add(21+ 2000, new string[] {"바로 앞이 AI공학관이야:0"});

       //Quest_3 간식행사
       
       //Quest_4 종강파티
    talkName.Add(100, new string[] {"카페"});
       talkName.Add(200, new string[] {"IT대학"});
       talkName.Add(300, new string[] {"비전타워"});
       talkName.Add(400, new string[] {"비전타워"});
       talkName.Add(500, new string[] {"AI공학관"});
       talkName.Add(600, new string[] {"바이오나노연구원"});
       talkName.Add(700, new string[] {"한의과대학"});
       talkName.Add(800, new string[] {"산학관"});
       talkName.Add(900, new string[] {"바이오나노대학"});
       talkName.Add(10000, new string[] {"체육대학2"});
       talkName.Add(20000, new string[] {"학군단"});
       talkName.Add(30000, new string[] {" 기숙사"});
       talkName.Add(40000, new string[] {"편의점"});
       talkName.Add(50000, new string[] {"학생회관"});
       talkName.Add(60000, new string[] {"중앙도서관"});
       talkName.Add(70000, new string[] {"교육대학원"});
       talkName.Add(80000, new string[] {"전자정보도서관"});
       talkName.Add(90000, new string[] {"글로벌센터"});
       talkName.Add(100000, new string[] {"체육대학1"});
       talkName.Add(200000, new string[] {"대학원"});
       talkName.Add(300000, new string[] {"공과대학2"});
       talkName.Add(400000, new string[] {"프리덤광장"});
       talkName.Add(500000, new string[] {"가천관"});
       talkName.Add(600000, new string[] {"인피니티동상"});
       talkName.Add(700000, new string[] {"대운동장"});

       string playerName = GameData.gamedata.playerName;
       talkName.Add(30, new string[] {  "친구"});
       talkName.Add(40,new string[] {"선배"});
       talkName.Add(50, new string[] {"선배"});
       talkName.Add(3000, new string[] { "무당이" });
       talkName.Add(1000,new string[] { "친구" });
       talkName.Add(2000,new string[]{"선배"});

       //portrait Data
       portraitData.Add(7000+0,portraitArr[0]); //플레이어 및 인트로에 쓰일 선배와 친구
       portraitData.Add(7000+1,portraitArr[1]);
       portraitData.Add(7000+2,portraitArr[2]);
       portraitData.Add(7000+3,portraitArr[3]);
       portraitData.Add(7000+4,portraitArr[17]); //선배
       portraitData.Add(7000+5,portraitArr[18]); //친구


       portraitData.Add(1000+0,portraitArr[4]);//친구
       portraitData.Add(1000+1,portraitArr[5]); 
       portraitData.Add(1000+2,portraitArr[6]);
       portraitData.Add(1000+3,portraitArr[7]);


       portraitData.Add(2000+0,portraitArr[8]); //선배
       portraitData.Add(2000+1,portraitArr[10]);
       portraitData.Add(2000+2,portraitArr[4]);
       portraitData.Add(2000+3,portraitArr[6]);
       portraitData.Add(2000+4,portraitArr[17]);
       portraitData.Add(2000+5,portraitArr[18]);
       


       
        portraitData.Add(30+0,portraitArr[4]); 
        portraitData.Add(30+1,portraitArr[5]); 
        portraitData.Add(30+2,portraitArr[6]); 
        portraitData.Add(30+3,portraitArr[7]);

        portraitData.Add(40+0,portraitArr[8]); 
        portraitData.Add(40+1,portraitArr[9]); 
        portraitData.Add(40+2,portraitArr[10]); 
        portraitData.Add(40+3,portraitArr[11]);
        
        portraitData.Add(50+0,portraitArr[8]); 
        portraitData.Add(50+1,portraitArr[9]); 
        portraitData.Add(50+2,portraitArr[10]); 
        portraitData.Add(50+3,portraitArr[11]);

        portraitData.Add(70+0,portraitArr[4]); 
        portraitData.Add(70+1,portraitArr[5]); 
        portraitData.Add(70+2,portraitArr[6]); 
        portraitData.Add(70+3,portraitArr[7]);

        portraitData.Add(5+0,portraitArr[8]); 
        portraitData.Add(5+1,portraitArr[10]); 
        portraitData.Add(5+2,portraitArr[4]); 
        portraitData.Add(5+3,portraitArr[6]);
        
        
        
     



   }
    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }
   public string GetTalk(int id, int talkIndex)
   {       

       if(!talkData.ContainsKey(id)){
           
           if((id-questManager.GetQuestTalkIndex(id))==3000){
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
  
               
                  
                  talkPanel3.SetActive(true);
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                   
               }
                 
           }}
           else{
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
                    
                
                 
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                     
               }
                 
           }else{
               //해당 퀘스트 진행 순서 중 대사가 없을 때
               //퀘스트 맨 처음 대사를 가져옴
               if(talkIndex == talkData[id-id%10].Length){                  
               
                  return null;
                  }                 
               else{
                   return talkData[id - id%10][talkIndex];
                   
                  }
                  
                  
              }
             }
            
       }

       if(talkIndex==talkData[id].Length){
           if(talkData[id]==StartGR&&ChoiceCount==0){ 
                ChoicPanel.SetActive(true);
           }
           else if(talkData[id]==StartMT&&ChoiceCount==1)
           {
               ChoicPanel.SetActive(true);
           }

           if(talkData[id]==No)
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("MTStart");
            
           if(talkData[id]==GoMT){
                GameData.gamedata.health-=2;
                GameData.gamedata.popular+=10;
                
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

                GameObject.Find("Canvas").GetComponent<FadeINOUT>().MTstartFadeOut();
           }
            else if(talkData[id]==NoMT)
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_4April");
            if(talkData[id]==StartaHan)
            {
                frId=1000;
                gameManager.Count=3;
                rb2.constraints = RigidbodyConstraints2D.None;
                rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
                pos2 = newStu.transform.position;
                friend.transform.position = new Vector3(pos2.x+1,pos2.y+1, 0);
            }
            if(talkData[id]==talkHan)
            {
                //ChoicPanel.SetActive(true);
                GameData.gamedata.stress-=8;
                GameData.gamedata.health-=5;
                GameData.gamedata.popular+=8;
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
                
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom5");
            }
           
           return null;
       }
       else{
           return talkData[id][talkIndex];
            
       }
      
   }

   public Sprite GetPortrait(int id, int portraitIndex)
   {
       return portraitData[id+portraitIndex];
   }
   public void Choice(string type)
   {
       switch(type)
       {
           case "y":
            if(ChoiceCount==0){
                talkData[30]=Yes;
                if(gameManager.success){
                    Portal.SetActive(true);
                }
                ChoicPanel.SetActive(false);
                GameObject.Find("GRGameManager").GetComponent<GRManager>().TestSub();
            }
            else if(ChoiceCount==1)
            {
                talkData[40]=YesMT;
                Portal.SetActive(true);
                ChoicPanel.SetActive(false);
                GameObject.Find("GRGameManager").GetComponent<GRManager>().TestSub();
            }
            
           break;

           case "n":
            if(ChoiceCount==0){
                talkData[30]=No;
                fadePanel.GetComponent<Image>().color=new Color(0,0,0);
                ChoicPanel.SetActive(false);
                GameObject.Find("GRGameManager").GetComponent<GRManager>().TestSub();
            }
            else if(ChoiceCount==1)
            {
                talkData[40]=NoMT;
                fadePanel.GetComponent<Image>().color=new Color(0,0,0);
                ChoicPanel.SetActive(false);
                GameObject.Find("GRGameManager").GetComponent<GRManager>().TestSub();
            }
            
           break;
       }
   }
//무당이를 탈 것인지 안 탈 것인지 물어보는 함수
   public void SelectTalk(string type){

       var heemudangAction = mudang.GetComponent<GRMudangAction>();
       var heeobjectdata =   mudang.GetComponent<heeObjectData>();
       Vector3 pos;
       pos = this.mudang.transform.position;
       switch(type){
           case "y": 
                talkPanel3.SetActive(false);
                mudangQuest.SetActive(true);

                newStu.SetActive(false);
                friend.SetActive(false);
                border.SetActive(true);
                gameManager.SetCameraTarget(mudang);
                ActionBtn.SetActive(false);
                heemudangAction.enabled = true;
                audioSource.clip = audioClip;
                audioSource.loop = false;               
                audioSource.Play();
                heeobjectdata.id = 12345;
                heeobjectdata.enabled= false;

                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
               
                break;
           case "n":  
                talkPanel3.SetActive(false);
                break;    
       }
   }
}
