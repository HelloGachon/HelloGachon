using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class heeTalkManager : MonoBehaviour
{
    
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;

    public GameObject talkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject newStu; //newStu 오브젝트
    public GameObject mudang; //mudang 오브젝트
    public GameObject mudangQuest; // 무당이 내릴때 누르는 버튼


    public heeQuestManager questManager;
    public heegameManager gameManager;


    private Rigidbody2D rb;
        

    void Awake()
    {        
        rb = mudang.GetComponent<Rigidbody2D>();
        talkData = new Dictionary<int, string[]>(); //대화에 문장이 여러개 존재
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    //대화 생성하기
   void GenerateData(){

       //buildings
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



       //npcs
       //시작할때 intro 대사 , 튜토리얼, npc들 익히기
       talkData.Add(7000, new string[] {"와!!! 가천대학교 컴퓨터공학과에 합격했다!!! 아싸!!!!:1",
                                        "입학하기 전에 학과별로 단체톡방에 들어갈 수 있구나!!! 들어가봐야지!!!!:3",
                                        "(단톡방- 나= 안녕하세요!!:0",
                                        "선배= 안녕하세요 반갑습니다~ 우리 학과에 온 걸 환영합니다~:4",
                                        "친구= 반가워요! 혹시 20살이신가요?:5",
                                        "나= 네네!:0",
                                        "친구= 오! 동갑이시네요!!! 친하게 지내요!! 반말 사용해도 될까요?:5",
                                        "나= 응!! 친하게 지내자!!:0",
                                        "친구= IT대학 쪽에 서있는 나한테 와봐!):5"
                                        });
       
       //친구 default 대사
       talkData.Add(1000, new string[] {"안녕? 나도 컴공 신입생이야!:0", 
                                        "만나서 반가워~ 친하게 지내자!:2"});
       //선배 default 대사
       talkData.Add(2000, new string[] {"안녕?:0", 
                                        "나는 선배야:2"});
        //무당이 default 대사
       talkData.Add(3000, new string[] {"탑승하시겠습니까?"});


       //Quest Talk(퀘스트 넘버 + npc 넘버)
       //Quest_1 1월      
       talkData.Add(10+ 1000, new string[] {"잘 찾아왔어!!:2","AI공학관 앞에 가서 선배님께 인사드려!!:0"});
       talkData.Add(11+ 2000, new string[] {"오 왔니?:2", "앞으로 학교 생활에 도움을 줄게!!:0", "가천대 컴퓨터공학과에 온걸 진심으로 환영해!!:2"});

       //Quest_2 오리엔테이션
       talkData.Add(20+ 2000, new string[] {"AI공학관에 들어가면 오리엔테이션을 진행할거야! :0"});
       talkData.Add(21+ 2000, new string[] {"바로 앞이 AI공학관이야:0"});

       //Quest_3 간식행사
       
       //Quest_4 종강파티
        

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
       portraitData.Add(2000+1,portraitArr[9]);
       portraitData.Add(2000+2,portraitArr[10]);
       portraitData.Add(2000+3,portraitArr[11]);


       portraitData.Add(4000+0,portraitArr[12]); //교수
       portraitData.Add(4000+1,portraitArr[13]);
       portraitData.Add(4000+2,portraitArr[14]);
       portraitData.Add(4000+3,portraitArr[15]);


       portraitData.Add(6000+0,portraitArr[16]); //이길여 총장님



   }

   public string GetTalk(int id, int talkIndex)
   {       

       if(!talkData.ContainsKey(id)){
           Debug.Log(id);
           if((id-questManager.GetQuestTalkIndex(id))==3000){
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
  
                //   Debug.Log("77777777777777777777777");
                  
                  talkPanel3.SetActive(true);
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                    // Debug.Log("2222222");
               }
                 
           }}
           else{
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
                    
                //   Debug.Log("333333");
                 
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                    // Debug.Log("2222222");
               }
                 
           }else{
               //해당 퀘스트 진행 순서 중 대사가 없을 때
               //퀘스트 맨 처음 대사를 가져옴
               if(talkIndex == talkData[id-id%10].Length){                  
                //   Debug.Log("44444444444");
                  return null;
                  }                 
               else{
                   return talkData[id - id%10][talkIndex];
                //    Debug.Log("2222222");
                  }
                  
                  
              }
             }
            
       }

       if(talkIndex==talkData[id].Length){ 
            // Debug.Log("555555555");
           return null;
       }
       else{
           return talkData[id][talkIndex];
        //    Debug.Log("2222222");
       }
      
   }

   public Sprite GetPortrait(int id, int portraitIndex)
   {
       return portraitData[id+portraitIndex];
   }

//무당이를 탈 것인지 안 탈 것인지 물어보는 함수
   public void SelectTalk(string type){

       var heemudangAction = mudang.GetComponent<heeMudangAction>();
       var heeobjectdata =   mudang.GetComponent<heeObjectData>();
       Vector3 pos;
       pos = this.mudang.transform.position;
       switch(type){
           case "y": 
                talkPanel3.SetActive(false);
                mudangQuest.SetActive(true);

                newStu.SetActive(false);
                gameManager.SetCameraTarget(mudang);
                
                heemudangAction.enabled = true;

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