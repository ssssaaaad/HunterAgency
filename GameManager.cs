using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MonsterList monsterList;
    public CharacterList characterList;
    public GameObject unitContract;
    public GameObject unitCare;
    public GameObject unitManagement;
    public Camera uiCamera;
    public GameObject upSide;
    public GameObject unitListNum;
    public GameObject mainLobby;
    public Transform[] backgrounds;
    public GameObject dungenLobby;
    public BattleTrigger battleTrigger;


    public GameObject StartBackground;



    //영입관련 UI
    public GameObject[] unitContractCharListSelectContract;
    public GameObject[] unitContractCharListSelectContractEnoughMoney;
    public GameObject[] unitContractCharListSelectContractLackOfMoney;
    public GameObject[] unitContractCharListContracted;

    public GameObject unitContract계약창부족;

    //치료관련 UI
    public GameObject[] uniCareCharListSelectCure;

    //유닛관리관련 UI
    public GameObject[] unitManagementCharListSelectCureCure;
    public GameObject[] unitManagementCharListSelectCureFullHp;
    public GameObject[] unitManagementCharListSelectCure;
    public GameObject[] unitManagementCharListSelectCureCuring;

    //던전관련 UI
    public GameObject dungenLobbyUnitSelect;
    public GameObject[] dungenLobbyUnitSelectCharListSelectHunter;
    public Monster[] huntedMonsterList;
    public GameObject dungeonStart;
    public GameObject victory;
    public GameObject lose;
    public GameObject eixtDungeonButton;
    public GameObject 가림판;
    public GameObject dungeonLobbyCancle;
    public GameObject dungeonLobbyStop;

 
    List<HunterData> hunterList = new List<HunterData>();
    HunterData[] dungeonHunterList = new HunterData[4];
    HunterData[] dungeonHunterUnitList = new HunterData[4];
    Monster[] dungeonMonsterList = new Monster[3];
    HunterData[] lobbyChaList = new HunterData[4]; 


    public Text unitListNumUI;
    public Text unitListMaxNumUI;
    public Text moneyText;
    public Text dayText;


    public Text[] newCharname;
    public Text[] newCharMaxHpText;
    public Text[] newCharCurrentHpText;
    public Text[] newCharLevelText;
    public Text[] newCharContractMoneyText;
    public Image[] newCharPosition;

    public Text[] curingCharname;
    public Text[] curingCharMaxHpText;
    public Text[] curingCharCurrentHpText;
    public Text[] curingCharLevelText;
    public Text[] curingCharmoodText;
    public Image[] curingCharPosition;
    public Text[] curingCharContractDday;

    public Text[] managementCharname;
    public Text[] managementCharMaxHpText;
    public Text[] managementCharCurrentHpText;
    public Text[] managementCharLevelText;
    public Text[] managementCharmoodText;
    public Image[] managementCharPosition;
    public Text[] managementCharContractDday;


    public Text[] dungenLobbyCharname;
    public Text[] dungenLobbyCharMaxHpText;
    public Text[] dungenLobbyCharCurrentHpText;
    public Text[] dungenLobbyCharLevelText;
    public Text[] dungenUnitSelectCharname;
    public Text[] dungenUnitSelectCharMaxHpText;
    public Text[] dungenUnitSelectCharCurrentHpText;
    public Text[] dungenUnitSelectCharLevelText;
    public Text[] dungenUnitSelectCharmoodText;
    public Image[] dungenUnitSelectCharPosition;
    public Text[] dungenUnitSelectCharContractDday;

    int day = 0;
    int newDay = 1;
    bool charContractListButton = true;
    int money;
    int MaxcharList = 20;
    int currentList = 0;
    int curingPageNum = 0;
    int ManagementPageNum = 0;
    double newHunterPosX = -4.6;
    double newHunterPosY;
    bool[] charContractedList = new bool[8];
    public float speed;
    bool fight = false;
    public int power = 0;
    public int monsterHp = 0;
    public int monsterPower = 0;
    public bool targetOn = false;
    public float attackCoolTime = 0;
    int monsterCount = 0;
    int huntedMonsterNum = 0;
    int mc = 0;
    int exp = 0;
    public int selectedDungeonHunterListNum;
    public bool dungeon = false;
    public int dungeonHunterHp;
    public float randtime1 = 2;
    public float randtime2 = 2;
    public float randtime3 = 2;
    public float randtime4 = 2;

    float randX1 = 0;
    float randY1 = 0;
    bool isMove1 = false;

    float randX2 = 0;
    float randY2 = 0;
    bool isMove2 = false;

    float randX3 = 0;
    float randY3 = 0;
    bool isMove3 = false;

    float randX4 = 0;
    float randY4 = 0;
    bool isMove4 = false;

    bool isUManagementOpen = false;
    bool isUCareOpen = false;
    bool isUComtractOpen = false;
    bool isDLOpen = false;

    public bool[] hunterSelected = new bool[4] { false, false, false, false };
    public int hunterSelectedNum;





    // Start is called before the first frame update
    void Start()
    {
        uiCamera.transform.position = new Vector3(0, 0, -10);
        money = 30000;
        moneyText.text = money.ToString();
        characterList.CreateNewHunterList();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        dayText.text = day.ToString();
        unitListNumUI.text = characterList.GetHunterListcurrentNum().ToString();
        unitListMaxNumUI.text = characterList.GetHunterListMaxNum().ToString();
        if (day != newDay)
        {
            characterList.SettingHunterCurrentNum();
            characterList.CreateNewHunterList();
            characterList.HillingUnit();
            day++;
            for (int i = 0; i < charContractedList.Length; i++)
            {
                charContractedList[i] = false;
            }
            for (int i = 0; i < unitContractCharListContracted.Length; i++)
            {
                unitContractCharListContracted[i].SetActive(false);
            }
           
        }

        if(CharacterList.hunterNum!=0)
        {
            for(int i = 0; i <CharacterList.hunterNum; i++ )
            {
                switch(i)
                {
                    case 0:
                        if (lobbyChaList[i] == null)
                        {
                            lobbyChaList[i] = Instantiate(CharacterList.myHunterList[i], 
                                new Vector3(-2.8f, 0.6f, 0), new Quaternion(0, 180, 0, 0));
                        }
                        randtime1 -= Time.deltaTime;
                        
                        if (randtime1<=0)
                        {
                            randtime1 = UnityEngine.Random.Range(1, 6);
                            randX1 = UnityEngine.Random.Range(-1, 2);
                            randY1 = UnityEngine.Random.Range(-1, 2);
                            isMove1 = (Random.value > 0.5f);
                            if (isMove1)
                            {
                               
                                if (randX1<=0)
                                {
                                    
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                                }
                                else
                                {
                                    
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                                }                             
                                lobbyChaList[i].Walk();
                            }
                            else
                            {
                                lobbyChaList[i].idle();
                            }
                        }
                        if(isMove1)
                        {
                            float x = lobbyChaList[i].gameObject.transform.position.x;
                            float y = lobbyChaList[i].gameObject.transform.position.y;
                            if (x >= 4.7)
                                randX1 = -1;
                            else if (x <= -4.8)
                                randX1 = 1;
                            
                            if (y >= 2.2)
                                randY1 = -1;
                            else if (y <= -6.3)
                                randY1 = 1;

                            lobbyChaList[i].gameObject.transform.Translate(new Vector3
                                (randX1, randY1, 0) * 0.3f * Time.deltaTime);
                        }
                        else
                        {
                            lobbyChaList[i].transform.Translate(new Vector3(randX1, randY1, 0) * 0 * Time.deltaTime);
                        }
                        
                        break;
                    case 1:
                        if (lobbyChaList[i] == null)
                        {
                            lobbyChaList[i] = Instantiate(CharacterList.myHunterList[i], new Vector3(0.0f, 0.6f, 0), new Quaternion(0, 180, 0, 0));
                        }
                        randtime2 -= Time.deltaTime;

                        if (randtime2 <= 0)
                        {
                            randtime2 = UnityEngine.Random.Range(1, 6);
                            randX2 = UnityEngine.Random.Range(-1, 2);
                            randY2 = UnityEngine.Random.Range(-1, 2);
                            isMove2 = (Random.value > 0.5f);
                            if (isMove2)
                            {
                                
                                if (randX1 <= 0)
                                {
             
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                                }
                                else
                                {
                                    
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                                }
                                lobbyChaList[i].Walk();
                            }
                            else
                            {
                                lobbyChaList[i].idle();
                            }
                        }
                        if (isMove2)
                        {
                            float x = lobbyChaList[i].gameObject.transform.position.x;
                            float y = lobbyChaList[i].gameObject.transform.position.y;
                            if (x >= 4.7)
                                randX2 = -1;
                            else if (x <= -4.8)
                                randX2 = 1;

                            if (y >= 2.2)
                                randY2 = -1;
                            else if (y <= -6.3)
                                randY2 = 1;

                            lobbyChaList[i].gameObject.transform.Translate(new Vector3(randX2, randY2, 0) * 0.3f * Time.deltaTime);
                        }
                        else
                        {
                            lobbyChaList[i].transform.Translate(new Vector3(randX2, randY2, 0) * 0 * Time.deltaTime);
                        }
                        break;
                    case 2:
                        if (lobbyChaList[i] == null)
                        {
                            lobbyChaList[i] = Instantiate(CharacterList.myHunterList[i], new Vector3(-2f, -4.6f, 0), new Quaternion(0, 180, 0, 0));
                        }
                        randtime1 -= Time.deltaTime;

                        if (randtime3 <= 0)
                        {
                            randtime3 = UnityEngine.Random.Range(3, 6);
                            randX3 = UnityEngine.Random.Range(-1, 2);
                            randY3 = UnityEngine.Random.Range(-1, 2);
                            isMove3 = (Random.value > 0.5f);
                            if (isMove3)
                            {
                           
                                if (randX3 <= 0)
                                {
                                    
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                                }
                                else
                                {
                                   
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                                }
                                lobbyChaList[i].Walk();
                            }
                            else
                            {
                                lobbyChaList[i].idle();
                            }
                        }
                        if (isMove3)
                        {
                            float x = lobbyChaList[i].gameObject.transform.position.x;
                            float y = lobbyChaList[i].gameObject.transform.position.y;
                            if (x >= 4.7)
                                randX3 = -1;
                            else if (x <= -4.8)
                                randX3 = 1;

                            if (y >= 2.2)
                                randY3 = -1;
                            else if (y <= -6.3)
                                randY3 = 1;

                            lobbyChaList[i].gameObject.transform.Translate(new Vector3(randX3, randY3, 0) * 0.3f * Time.deltaTime);
                        }
                        else
                        {
                            lobbyChaList[i].transform.Translate(new Vector3(randX3, randY3, 0) * 0 * Time.deltaTime);
                        }
                        break;
                    case 3:
                        if (lobbyChaList[i] == null)
                        {
                            lobbyChaList[i] = Instantiate(CharacterList.myHunterList[i], new Vector3(2.06f, -5.13f, 0), new Quaternion(0, 180, 0, 0));
                        }
                        randtime4 -= Time.deltaTime;

                        if (randtime4 <= 0)
                        {
                            randtime4 = UnityEngine.Random.Range(1, 6);
                            randX4 = UnityEngine.Random.Range(-1, 2);
                            randY4 = UnityEngine.Random.Range(-1, 2);
                            isMove4 = (Random.value > 0.5f);
                            if (isMove4)
                            {
                          
                                if (randX4 <= 0)
                                {
                                   
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                                }
                                else
                                {
                                    
                                    lobbyChaList[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                                }
                                lobbyChaList[i].Walk();
                            }
                            else
                            {
                                lobbyChaList[i].idle();
                            }
                        }
                        if (isMove4)
                        {
                            float x = lobbyChaList[i].gameObject.transform.position.x;
                            float y = lobbyChaList[i].gameObject.transform.position.y;
                            if (x >= 4.7)
                                randX4 = -1;
                            else if (x <= -4.8)
                                randX4 = 1;

                            if (y >= 2.2)
                                randY4 = -1;
                            else if (y <= -6.3)
                                randY4 = 1;

                            lobbyChaList[i].gameObject.transform.Translate(new Vector3(randX4, randY4, 0) * 0.3f * Time.deltaTime);
                        }
                        else
                        {
                            lobbyChaList[i].transform.Translate(new Vector3(randX4, randY4, 0) * 0 * Time.deltaTime);
                        }
                        break;
                }
            }
        }

        if (isDLOpen || isUComtractOpen || isUCareOpen || isUManagementOpen)
        {
            if (CharacterList.hunterNum != 0)
            {
                for (int i = 0; i < CharacterList.hunterNum; i++)
                {
                    if (i > 3)
                        i = 3;
                    lobbyChaList[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (CharacterList.hunterNum != 0)
            {
                for (int i = 0; i < CharacterList.hunterNum; i++)
                {
                    lobbyChaList[i].gameObject.SetActive(true);
                }
            }
        }



        if(dungeon)
        {

            targetOn = monsterList.targetOn;
            if (dungeon && !targetOn)
            {
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                }
            }
            Run();
            if(targetOn)
            {
                attackCoolTime = +Time.deltaTime;
                if (attackCoolTime < 3)
                {
                    monsterPower = monsterList.GetMonsterPower();
                    Attack();
                    attackCoolTime = 0;
                    CalculationHunterHp(monsterPower);
                    
                    dungeonMonsterList[monsterList.monsterNum] = monsterList.GetMonsterData();
                    Debug.Log("monsterList.monsterNum = " + monsterList.monsterNum);
                    if (CalculationHunterHpAdd() <= 0)
                    {
                        Lose();                    
                    }
                  
                }
            }
              if(monsterList.monsterNum >=3)
                    {
                        targetOn = false;
                        dungeon = false;
                        Idle();
                        Calculate();
                        victory.SetActive(true);
                        eixtDungeonButton.SetActive(true);
                        monsterList.monsterNum = 0;
                        Debug.Log("끝");
                    }
        }


    }

    public void StartButton()
    {
        StartBackground.SetActive(false);
    }

    //영입창 관련

    //영입 버튼 눌렀을때
    public void UnitContractButton()
    {
        isUComtractOpen = true;
        for (int i = 0; i < 4; i++)
        {
            if (charContractedList[i] == true)
            {
                unitContractCharListContracted[i].SetActive(true);
            }
            else
            {
                unitContractCharListContracted[i].SetActive(false);
            }
            HunterData newHunterData = CharacterList.newHunterList[i];
            newCharname[i].text = newHunterData.name;
            newCharLevelText[i].text = newHunterData.level.ToString();
            newCharMaxHpText[i].text = newHunterData.maxHp.ToString();
            newCharCurrentHpText[i].text = newHunterData.currentHp.ToString();
            newCharContractMoneyText[i].text = newHunterData.contractMoney.ToString();
            switch ((i + 1) % 4)
            {
                case 1:
                    newHunterPosY = 2.8;
                    break;
                case 2:
                    newHunterPosY = -0.6;
                    break;
                case 3:
                    newHunterPosY = -4.2;
                    break;
                case 0:
                    newHunterPosY = -7.6;
                    break;
            }
            hunterList.Add(Instantiate(newHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));


        }
        charContractListButton = true;

        unitContract.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            unitContractCharListSelectContract[i].SetActive(false);
            unitContractCharListSelectContractEnoughMoney[i].SetActive(false);
            unitContractCharListSelectContractLackOfMoney[i].SetActive(false);

        }

    }



    //신규 캐릭터 창 위로
    public void UnitContractUpButton()
    {

        if (charContractListButton == true)
        {

        }
        else if (charContractListButton == false)
        {

            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null) 
                Destroy(hunterList[d].gameObject);
            }
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("charContractedList" + i + ":" + charContractedList[i]);
                if (charContractedList[i] == true)
                {
                    
                    unitContractCharListContracted[i].SetActive(true);
                }
                else
                {
                    unitContractCharListContracted[i].SetActive(false);
                }
                HunterData newHunterData = CharacterList.newHunterList[i];
                newCharname[i].text = newHunterData.name;
                newCharLevelText[i].text = newHunterData.level.ToString();
                newCharMaxHpText[i].text = newHunterData.maxHp.ToString();
                newCharCurrentHpText[i].text = newHunterData.currentHp.ToString();
                newCharContractMoneyText[i].text = newHunterData.contractMoney.ToString();
                switch ((i + 1) % 4)
                {
                    case 1:
                        newHunterPosY = 2.8;
                        break;
                    case 2:
                        newHunterPosY = -0.6;
                        break;
                    case 3:
                        newHunterPosY = -4.2;
                        break;
                    case 0:
                        newHunterPosY = -7.6;
                        break;
                }
                hunterList.Add(Instantiate(newHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));

            }
            charContractListButton = true;
            for (int i = 0; i < 4; i++)
            {
                unitContractCharListSelectContract[i].SetActive(false);
                unitContractCharListSelectContractEnoughMoney[i].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[i].SetActive(false);
            }

        }
    }

    //신규 캐릭터 창 아래로
    public void UnitContractDownButton()
    {
        
        if (charContractListButton == false)
        {

        }
        else if (charContractListButton == true)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null) 
                    Destroy(hunterList[d].gameObject);
            }
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("charContractedList" + i + ":" + charContractedList[i]);
                if (charContractedList[i + 4] == true)
                {
                    
                    unitContractCharListContracted[i].SetActive(true);
                }
                else
                {
                    unitContractCharListContracted[i].SetActive(false);
                }
                HunterData newHunterData = CharacterList.newHunterList[i+4];
                newCharname[i].text = newHunterData.name;
                newCharLevelText[i].text = newHunterData.level.ToString();
                newCharMaxHpText[i].text = newHunterData.maxHp.ToString();
                newCharCurrentHpText[i].text = newHunterData.currentHp.ToString();
                newCharContractMoneyText[i].text = newHunterData.contractMoney.ToString();
                switch ((i + 1) % 4)
                {
                    case 1:
                        newHunterPosY = 2.8;
                        break;
                    case 2:
                        newHunterPosY = -0.6;
                        break;
                    case 3:
                        newHunterPosY = -4.2;
                        break;
                    case 0:
                        newHunterPosY = -7.6;
                        break;
                }
                hunterList.Add(Instantiate(newHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));

            }
            for (int i = 0; i < 4; i++)
            {
                unitContractCharListSelectContract[i].SetActive(false);
                unitContractCharListSelectContractEnoughMoney[i].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[i].SetActive(false);
            }
        }
        charContractListButton = false;

    }

    //신규 캐릭터 선택
    public void UnitContractCharList1()
    {
        unitContractCharListSelectContract[0].SetActive(true);
        if (charContractListButton == true)
        {
            HunterData newHunterData = CharacterList.newHunterList[0];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[0].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[0].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[0].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[0].SetActive(true);
            }

        }
        if (charContractListButton == false)
        {
            HunterData newHunterData = CharacterList.newHunterList[4];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[0].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[0].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[0].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[0].SetActive(true);
            }

        }
    }
    public void UnitContractCharList2()
    {
        unitContractCharListSelectContract[1].SetActive(true);
        if (charContractListButton == true)
        {
            HunterData newHunterData = CharacterList.newHunterList[1];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[1].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[1].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[1].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[1].SetActive(true);
            }

        }
        if (charContractListButton == false)
        {
            HunterData newHunterData = CharacterList.newHunterList[5];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[1].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[1].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[1].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[1].SetActive(true);
            }

        }

    }
    public void UnitContractCharList3()
    {
        unitContractCharListSelectContract[2].SetActive(true);
        if (charContractListButton == true)
        {
            HunterData newHunterData = CharacterList.newHunterList[2];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[2].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[2].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[2].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[2].SetActive(true);
            }

        }
        if (charContractListButton == false)
        {
            HunterData newHunterData = CharacterList.newHunterList[6];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[2].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[2].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[2].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[2].SetActive(true);
            }

        }
    }
    public void UnitContractCharList4()
    {
        unitContractCharListSelectContract[3].SetActive(true);
        if (charContractListButton == true)
        {
            HunterData newHunterData = CharacterList.newHunterList[3];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[3].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[3].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[3].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[3].SetActive(true);
            }

        }
        if (charContractListButton == false)
        {
            HunterData newHunterData = CharacterList.newHunterList[7];
            if (money >= newHunterData.contractMoney)
            {
                unitContractCharListSelectContractEnoughMoney[3].SetActive(true);
                unitContractCharListSelectContractLackOfMoney[3].SetActive(false);
            }
            else
            {
                unitContractCharListSelectContractEnoughMoney[3].SetActive(false);
                unitContractCharListSelectContractLackOfMoney[3].SetActive(true);
            }

        }
    }

    //신규 캐틱터 선택 후 계약 선택
    public void UnitContractCharList1Contract()
    {
        if (charContractListButton == true)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = CharacterList.newHunterList[0];
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(0);
                money -= newHunterData.contractMoney;
                charContractedList[0] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[0].SetActive(true);
            }
            else
            {
                return;
            }

        }
        if (charContractListButton == false)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(4);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(4);
                money -= newHunterData.contractMoney;
                charContractedList[4] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[0].SetActive(true);
            }
            else
            {
                return;
            }

        }
    }

    public void UnitContractCharList2Contract()
    {
        if (charContractListButton == true)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(1);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(1);
                money -= newHunterData.contractMoney;
                charContractedList[1] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[1].SetActive(true);

            }
            else
            {
                return;
            }

        }
        if (charContractListButton == false)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(5);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(5);
                money -= newHunterData.contractMoney; ;
                charContractedList[5] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[1].SetActive(true);

            }
            else
            {
                return;
            }

        }
    }

    public void UnitContractCharList3Contract()
    {
        if (charContractListButton == true)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(2);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(2);
                money -= newHunterData.contractMoney;
                charContractedList[2] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[2].SetActive(true);
            }
            else
            {
                return;
            }

        }
        if (charContractListButton == false)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(6);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(6);
                money -= newHunterData.contractMoney;
                charContractedList[6] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[2].SetActive(true);
            }
            else
            {
                return;
            }

        }
    }

    public void UnitContractCharList4Contract()
    {
        if (charContractListButton == true)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(3);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(3);
                money -= newHunterData.contractMoney;
                charContractedList[3] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[3].SetActive(true);
            }
            else
            {
                return;
            }

        }
        if (charContractListButton == false)
        {
            if (CharacterList.hunterListMaxNum <= CharacterList.hunterNum)
            {
                unitContract계약창부족.SetActive(true);
                return;
            }
            HunterData newHunterData = characterList.GetNewHunterData(7);
            if (money >= newHunterData.contractMoney)
            {
                characterList.SelectNewHunter(7);
                money -= newHunterData.contractMoney;
                charContractedList[7] = true;
                moneyText.text = money.ToString();
                unitContractCharListContracted[3].SetActive(true);
            }
            else
            {
                return;
            }

        }
    }

    //계약창 부족 끄기
    public void UnitContract계약창부족끄기()
    {
        unitContract계약창부족.SetActive(false);
    }

    //신규 캐릭터창 누른후 뒤돌아가기
    public void UnitContractCharList1SelectContractCancle()
    {
        unitContractCharListSelectContract[0].SetActive(false);
    }

    public void UnitContractCharList2SelectContractCancle()
    {
        unitContractCharListSelectContract[1].SetActive(false);
    }

    public void UnitContractCharList3SelectContractCancle()
    {
        unitContractCharListSelectContract[2].SetActive(false);
    }

    public void UnitContractCharList4SelectContractCancle()
    {
        unitContractCharListSelectContract[3].SetActive(false);
    }

    //영입창 닫기
    public void UnitContractConcle()
    {
        isUComtractOpen = false;
        Debug.Log(isUComtractOpen);
        for (int d = 0; d < hunterList.Count; d++)
        {
            if (hunterList[d] != null)
                Destroy(hunterList[d].gameObject);
        }
        unitContract.SetActive(false);
        charContractListButton = true;
        ManagementPageNum = 0;
        for(int d = 0; d < unitContractCharListContracted.Length; d++)
        {
            unitContractCharListContracted[d].SetActive(false);
        }
    }


    //치료 창 관련

    //메인화면에 치료 버튼 눌렀을때
    public void UnitCareButton()
    {
        isUCareOpen = true;
        unitCare.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            HunterData curingHunterData = CharacterList.curingHunterList[i + (curingPageNum * 4)];
            if (curingHunterData == null)
            {
                curingCharname[i].text = " ";
                curingCharLevelText[i].text = " ";
                curingCharMaxHpText[i].text = " ";
                curingCharCurrentHpText[i].text = " ";
                curingCharContractDday[i].text = " ";
                curingCharmoodText[i].text = " ";
            }
            else
            {
                curingCharname[i].text = curingHunterData.name;
                curingCharLevelText[i].text = curingHunterData.level.ToString();
                curingCharMaxHpText[i].text = curingHunterData.maxHp.ToString();
                curingCharCurrentHpText[i].text = curingHunterData.currentHp.ToString();
                curingCharContractDday[i].text = curingHunterData.contractRenewal.ToString();
                curingCharmoodText[i].text = curingHunterData.mood.ToString();
                switch ((i + 1) % 4)
                {
                    case 1:
                        newHunterPosY = 2.8;
                        break;
                    case 2:
                        newHunterPosY = -0.6;
                        break;
                    case 3:
                        newHunterPosY = -4.2;
                        break;
                    case 0:
                        newHunterPosY = -7.6;
                        break;
                }
                hunterList.Add(Instantiate(curingHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));
            }
        }
        charContractListButton = true;
        unitCare.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            uniCareCharListSelectCure[i].SetActive(false);
        }
    }

    //치료 캐릭터 창 위로
    public void UnitCareUpButton()
    {
        int curingHunterListPageMax = CharacterList.curingHunterList.Length / 4;
        if (curingPageNum <= curingHunterListPageMax && curingPageNum != 0)
        {
            charContractListButton = false;
            curingPageNum--;
        }
        else
        {
            charContractListButton = true;
        }
        if (charContractListButton == true)
        {
            return;
        }
        else if (charContractListButton == false)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            UnitCareButton();
            for (int i = 0; i < uniCareCharListSelectCure.Length; i++)
                uniCareCharListSelectCure[i].SetActive(false);
        }
    }

    //치료 캐릭터 창 아래로
    public void UnitCareDownButton()
    {

        int curingHunterListPageMax = CharacterList.curingHunterList.Length / 4;
        if (curingPageNum < curingHunterListPageMax)
        {
            charContractListButton = true;
            curingPageNum++;
        }
        else
        {
            charContractListButton = false;
        }
        if (charContractListButton == false)
        {
            return;
        }
        else if (charContractListButton == true)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            UnitCareButton();
            for (int i = 0; i < uniCareCharListSelectCure.Length; i++)
                uniCareCharListSelectCure[i].SetActive(false);

        }
    }

    //치료중인 캐릭터창눌렀을때

    public void UnitCureCharList1SelectCure()
    {
        uniCareCharListSelectCure[0].SetActive(true);
    }

    public void UnitCureCharList2SelectCure()
    {
        uniCareCharListSelectCure[1].SetActive(true);
    }

    public void UnitCureCharList3SelectCure()
    {
        uniCareCharListSelectCure[2].SetActive(true);
    }

    public void UnitCureCharList4SelectCure()
    {
        uniCareCharListSelectCure[3].SetActive(true);
    }

    //치료중인 캐릭터 치료 중지
    public void UnitCureCharList1SelectCureCureCancle()
    {
        characterList.StopHillingUnit(0 + (curingPageNum * 4));
        UnitCareButton();
    }
    public void UnitCureCharList2SelectCureCureCancle()
    {
        characterList.StopHillingUnit(1 + (curingPageNum * 4));
        UnitCareButton();
    }
    public void UnitCureCharList3SelectCureCureCancle()
    {
        characterList.StopHillingUnit(2 + (curingPageNum * 4));
        UnitCareButton();
    }
    public void UnitCureCharList4SelectCureCureCancle()
    {
        characterList.StopHillingUnit(3 + (curingPageNum * 4));
        UnitCareButton();
    }


    //치료중인 캐릭터창 누른후 뒤돌아가기
    public void UnitCureCharList1SelectCureCancle()
    {
        uniCareCharListSelectCure[0].SetActive(false);
    }

    public void UnitCureCharList2SelectCureCancle()
    {
        uniCareCharListSelectCure[1].SetActive(false);
    }

    public void UnitCureCharList3SelectCureCancle()
    {
        uniCareCharListSelectCure[2].SetActive(false);
    }

    public void UnitCureCharList4SelectCureCancle()
    {
        uniCareCharListSelectCure[3].SetActive(false);
    }


    //치료창 닫기
    public void UnitCareConcle()
    {
        isUCareOpen = false;
        for (int d = 0; d < hunterList.Count; d++)
        {
            if (hunterList[d] != null)
                Destroy(hunterList[d].gameObject);
        }
        unitCare.SetActive(false);
        charContractListButton = true;
        curingPageNum = 0;
    }


    //유닛관리창 관련

    //메인화면에 관리 버튼 눌렀을때
    public void UnitManagementButton()
    {
        isUManagementOpen = true;
        unitManagement.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            HunterData myHunterData = characterList.GetMyHunterData(i + (ManagementPageNum * 4));
            if (myHunterData == null)
            {
                managementCharname[i].text = " ";
                managementCharLevelText[i].text = " ";
                managementCharMaxHpText[i].text = " ";
                managementCharCurrentHpText[i].text = " ";
                managementCharContractDday[i].text = " ";
                managementCharmoodText[i].text = " ";
            }
            else
            {
                Debug.Log(myHunterData.hunterId);
                managementCharname[i].text = myHunterData.name;
                managementCharLevelText[i].text = myHunterData.level.ToString();
                managementCharMaxHpText[i].text = myHunterData.maxHp.ToString();
                managementCharCurrentHpText[i].text = myHunterData.currentHp.ToString();
                managementCharContractDday[i].text = myHunterData.contractRenewal.ToString();
                managementCharmoodText[i].text = myHunterData.mood.ToString();
                switch ((i + 1) % 4)
                {
                    case 1:
                        newHunterPosY = 2.8;
                        break;
                    case 2:
                        newHunterPosY = -0.6;
                        break;
                    case 3:
                        newHunterPosY = -4.2;
                        break;
                    case 0:
                        newHunterPosY = -7.6;
                        break;
                }
                hunterList.Add(Instantiate(myHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));
            }
        }
        charContractListButton = true;
        unitManagement.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            unitManagementCharListSelectCure[i].SetActive(false);
            unitManagementCharListSelectCureCure[i].SetActive(false);
            unitManagementCharListSelectCureFullHp[i].SetActive(false);
            unitManagementCharListSelectCureCuring[i].SetActive(false);
        }
    }

    //관리 캐릭터 창 위로
    public void UnitManagementUpButton()
    {
        charContractListButton = true;
        int curingHunterListPageMax = CharacterList.myHunterList.Length / 4;
        if (ManagementPageNum <= curingHunterListPageMax && ManagementPageNum != 0)
        {
            charContractListButton = false;
            ManagementPageNum--;
        }
        else
        {
            charContractListButton = true;
        }
        if (charContractListButton == true)
        {
            return;
        }
        else if (charContractListButton == false)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            UnitManagementButton();
            for (int i = 0; i < 4; i++)
            {
                unitManagementCharListSelectCure[i].SetActive(false);
                unitManagementCharListSelectCureCure[i].SetActive(false);
                unitManagementCharListSelectCureFullHp[i].SetActive(false);
                unitManagementCharListSelectCureCuring[i].SetActive(false);
            }
        }
    }

    //관리 캐릭터 창 아래로
    public void UnitManagementDownButton()
    {

        charContractListButton = false;
        int curingHunterListPageMax = CharacterList.myHunterList.Length / 4;
        if (ManagementPageNum < curingHunterListPageMax)
        {
            charContractListButton = true;
            ManagementPageNum++;
        }
        else
        {
            charContractListButton = false;
        }
        if (charContractListButton == false)
        {
            return;
        }
        else if (charContractListButton == true)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            UnitManagementButton();
            for (int i = 0; i < 4; i++)
            {
                unitManagementCharListSelectCure[i].SetActive(false);
                unitManagementCharListSelectCureCure[i].SetActive(false);
                unitManagementCharListSelectCureFullHp[i].SetActive(false);
                unitManagementCharListSelectCureCuring[i].SetActive(false);
            }
        }
    }

    //캐릭터를 눌렀을때
    public void UnitManagementCharList1ButtonDown()
    {
        int hunterListCurrentNum = CharacterList.hunterNum;
        if (hunterListCurrentNum <= 0 + (ManagementPageNum * 4))
        {
            return;
        }
        unitManagementCharListSelectCure[0].SetActive(true);
        int isLowHp = characterList.UnitManagementCharListButtonDown(0 + (ManagementPageNum * 4));
        if (isLowHp == 1)
        {
            unitManagementCharListSelectCureFullHp[0].SetActive(false);
            unitManagementCharListSelectCureCure[0].SetActive(true);
            unitManagementCharListSelectCureCuring[0].SetActive(false);
        }
        else if (isLowHp == 2)
        {
            unitManagementCharListSelectCureFullHp[0].SetActive(false);
            unitManagementCharListSelectCureCure[0].SetActive(false);
            unitManagementCharListSelectCureCuring[0].SetActive(true);
        }
        else
        {
            unitManagementCharListSelectCureFullHp[0].SetActive(true);
            unitManagementCharListSelectCureCure[0].SetActive(false);
            unitManagementCharListSelectCureCuring[0].SetActive(false);
        }
    }
    public void UnitManagementCharList2ButtonDown()
    {
        int hunterListCurrentNum = CharacterList.hunterNum;
        if (hunterListCurrentNum <= 1 + (ManagementPageNum * 4))
        {
            return;
        }
        unitManagementCharListSelectCure[1].SetActive(true);
        int isLowHp = characterList.UnitManagementCharListButtonDown(1 + (ManagementPageNum * 4));
        if (isLowHp == 1)
        {
            unitManagementCharListSelectCureFullHp[1].SetActive(false);
            unitManagementCharListSelectCureCure[1].SetActive(true);
            unitManagementCharListSelectCureCuring[1].SetActive(false);
        }
        else if (isLowHp == 2)
        {
            unitManagementCharListSelectCureFullHp[1].SetActive(false);
            unitManagementCharListSelectCureCure[1].SetActive(false);
            unitManagementCharListSelectCureCuring[1].SetActive(true);
        }
        else
        {
            unitManagementCharListSelectCureFullHp[1].SetActive(true);
            unitManagementCharListSelectCureCure[1].SetActive(false);
            unitManagementCharListSelectCureCuring[1].SetActive(false);
        }
    }
    public void UnitManagementCharList3ButtonDown()
    {
        int hunterListCurrentNum = CharacterList.hunterNum;
        if (hunterListCurrentNum <= 2 + (ManagementPageNum * 4))
        {
            return;
        }
        unitManagementCharListSelectCure[2].SetActive(true);
        int isLowHp = characterList.UnitManagementCharListButtonDown(2 + (ManagementPageNum * 4));
        if (isLowHp == 1)
        {
            unitManagementCharListSelectCureFullHp[2].SetActive(false);
            unitManagementCharListSelectCureCure[2].SetActive(true);
            unitManagementCharListSelectCureCuring[2].SetActive(false);
        }
        else if (isLowHp == 2)
        {
            unitManagementCharListSelectCureFullHp[2].SetActive(false);
            unitManagementCharListSelectCureCure[2].SetActive(false);
            unitManagementCharListSelectCureCuring[2].SetActive(true);
        }
        else
        {
            unitManagementCharListSelectCureFullHp[2].SetActive(true);
            unitManagementCharListSelectCureCure[2].SetActive(false);
            unitManagementCharListSelectCureCuring[2].SetActive(false);
        }
    }
    public void UnitManagementCharList4ButtonDown()
    {
        int hunterListCurrentNum = CharacterList.hunterNum;
        if (hunterListCurrentNum <= 3 + (ManagementPageNum * 4))
        {
            return;
        }
        unitManagementCharListSelectCure[3].SetActive(true);
        int isLowHp = characterList.UnitManagementCharListButtonDown(3 + (ManagementPageNum * 4));
        if (isLowHp == 1)
        {
            unitManagementCharListSelectCureFullHp[3].SetActive(false);
            unitManagementCharListSelectCureCure[3].SetActive(true);
            unitManagementCharListSelectCureCuring[3].SetActive(false);
        }
        else if (isLowHp == 2)
        {
            unitManagementCharListSelectCureFullHp[3].SetActive(false);
            unitManagementCharListSelectCureCure[3].SetActive(false);
            unitManagementCharListSelectCureCuring[3].SetActive(true);
        }
        else
        {
            unitManagementCharListSelectCureFullHp[3].SetActive(true);
            unitManagementCharListSelectCureCure[3].SetActive(false);
            unitManagementCharListSelectCureCuring[3].SetActive(false);
        }
    }

    //캐릭터 누른후 취소버튼
    public void UnitManagementCharList1SelectCureCancle()
    {
        unitManagementCharListSelectCureFullHp[0].SetActive(false);
        unitManagementCharListSelectCureCure[0].SetActive(false);
        unitManagementCharListSelectCure[0].SetActive(false);
        unitManagementCharListSelectCureCuring[0].SetActive(false);
    }
    public void UnitManagementCharList2SelectCureCancle()
    {
        unitManagementCharListSelectCureFullHp[1].SetActive(false);
        unitManagementCharListSelectCureCure[1].SetActive(false);
        unitManagementCharListSelectCure[1].SetActive(false);
        unitManagementCharListSelectCureCuring[1].SetActive(false);
    }
    public void UnitManagementCharList3SelectCureCancle()
    {
        unitManagementCharListSelectCureFullHp[2].SetActive(false);
        unitManagementCharListSelectCureCure[2].SetActive(false);
        unitManagementCharListSelectCure[2].SetActive(false);
        unitManagementCharListSelectCureCuring[2].SetActive(false);
    }
    public void UnitManagementCharList4SelectCureCancle()
    {
        unitManagementCharListSelectCureFullHp[3].SetActive(false);
        unitManagementCharListSelectCureCure[3].SetActive(false);
        unitManagementCharListSelectCure[3].SetActive(false);
        unitManagementCharListSelectCureCuring[3].SetActive(false);
    }

    //캐릭터를 누른후 치료버튼
    public void UnitManagementCharList1SeletCure()
    {
        characterList.PickOutCuringHunter(0 + (ManagementPageNum * 4));
        unitManagementCharListSelectCure[0].SetActive(false);
    }
    public void UnitManagementCharList2SeletCure()
    {
        characterList.PickOutCuringHunter(1 + (ManagementPageNum * 4));
        unitManagementCharListSelectCure[1].SetActive(false);
    }
    public void UnitManagementCharList3SeletCure()
    {
        characterList.PickOutCuringHunter(2 + (ManagementPageNum * 4));
        unitManagementCharListSelectCure[2].SetActive(false);
    }
    public void UnitManagementCharList4SeletCure()
    {
        characterList.PickOutCuringHunter(3 + (ManagementPageNum * 4));
        unitManagementCharListSelectCure[3].SetActive(false);
    }

    //헌터 관리창 닫기
    public void UnitManagementConcle()
    {
        isUManagementOpen = false;
        for (int d = 0; d < hunterList.Count; d++)
        {
            if (hunterList[d] != null)
                Destroy(hunterList[d].gameObject);
        }
        unitManagement.SetActive(false);
        charContractListButton = true;
        ManagementPageNum = 0;
    }

    //던전입장 버튼
    public void DungenButtonDown()
    {
        isDLOpen = true;
        dungeonLobbyCancle.SetActive(true);
        dungeonLobbyStop.SetActive(false);
        dungeonStart.SetActive(true);
        uiCamera.transform.position = new Vector3(0, 33, -10);
        upSide.SetActive(false);
        unitListNum.SetActive(false);
        mainLobby.SetActive(false);
        dungenLobby.SetActive(true);
        dungenLobbyUnitSelect.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            dungenLobbyCharname[i].text = "";
            dungenLobbyCharMaxHpText[i].text = "";
            dungenLobbyCharCurrentHpText[i].text = "";
            dungenLobbyCharLevelText[i].text = "";
        }
    }

    //던전로비에서 캐릭터창을 눌었을때
    public void DungenLobbyCharListButtonDown()
    {
        for (int d = 0;d < hunterSelected.Length; d++)
        {
            if(hunterSelected[d])
            {
                dungeonHunterList[d].gameObject.SetActive(false);
                dungeonHunterUnitList[d].gameObject.SetActive(false);
            }
        }
        dungenLobbyUnitSelect.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            HunterData myHunterData = characterList.GetDungenHunterData(i + (ManagementPageNum * 4));
            if (myHunterData == null)
            {

                dungenUnitSelectCharname[i].text = " ";
                dungenUnitSelectCharMaxHpText[i].text = " ";
                dungenUnitSelectCharCurrentHpText[i].text = " ";
                dungenUnitSelectCharLevelText[i].text = " ";
                dungenUnitSelectCharmoodText[i].text = " ";
                dungenUnitSelectCharContractDday[i].text = " ";

            }
            else
            {
                dungenUnitSelectCharname[i].text = myHunterData.name;
                dungenUnitSelectCharLevelText[i].text = myHunterData.level.ToString();
                dungenUnitSelectCharMaxHpText[i].text = myHunterData.maxHp.ToString();
                dungenUnitSelectCharCurrentHpText[i].text = myHunterData.currentHp.ToString();
                dungenUnitSelectCharContractDday[i].text = myHunterData.contractRenewal.ToString();
                dungenUnitSelectCharmoodText[i].text = myHunterData.mood.ToString();
                switch ((i + 1) % 4)
                {
                    case 1:
                        newHunterPosY = 35.8;
                        break;
                    case 2:
                        newHunterPosY = 32.4;
                        break;
                    case 3:
                        newHunterPosY = 29;
                        break;
                    case 0:
                        newHunterPosY = 25.6;
                        break;
                }
                hunterList.Add(Instantiate(myHunterData, new Vector3((float)-3.7, (float)newHunterPosY, 0f), new Quaternion(0, 180, 0, 0)));
            }
        }
        charContractListButton = true;
        for (int i = 0; i < 4; i++)
        {
            dungenLobbyUnitSelectCharListSelectHunter[i].SetActive(false);
        }
    }

    //던전로비에서 캐릭터창을 누른후 다운버튼
    public void DungenLobbyCharListDownButton()
    {

        charContractListButton = false;
        int curingHunterListPageMax = characterList.GetDungenHunterListLength() / 4;
        if (ManagementPageNum < curingHunterListPageMax)
        {
            charContractListButton = true;
            ManagementPageNum++;
        }
        else
        {
            charContractListButton = false;
        }
        if (charContractListButton == false)
        {
            return;
        }
        else if (charContractListButton == true)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            DungenLobbyCharListButtonDown();
            for (int i = 0; i < 4; i++)
            {
                dungenLobbyUnitSelectCharListSelectHunter[i].SetActive(false);
            }
        }
    }

    //던전로비에서 캐릭터창을 누른후 업버튼
    public void DungenLobbyCharListUpButton()
    {

        charContractListButton = true;
        int curingHunterListPageMax = characterList.GetDungenHunterListLength() / 4;
        if (ManagementPageNum <= curingHunterListPageMax && ManagementPageNum != 0)
        {
            charContractListButton = false;
            ManagementPageNum--;
        }
        else
        {
            charContractListButton = true;
        }
        if (charContractListButton == true)
        {
            return;
        }
        else if (charContractListButton == false)
        {
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            DungenLobbyCharListButtonDown();
            for (int i = 0; i < 4; i++)
            {
                dungenLobbyUnitSelectCharListSelectHunter[i].SetActive(false);
            }
        }
    }

    //던전 Charlist에서 캐릭터 선택
    public void DungenLobbyCharListCharList1SelectHunter()
    {
        HunterData myHunterData = characterList.GetDungenHunterData(0 + (ManagementPageNum * 4));
        if (myHunterData != null)
        {
            dungenLobbyUnitSelectCharListSelectHunter[0].SetActive(true);
        }     
    }
    public void DungenLobbyCharListCharList2SelectHunter()
    {
        HunterData myHunterData = characterList.GetDungenHunterData(1 + (ManagementPageNum * 4));
        if (myHunterData != null)
        {
            dungenLobbyUnitSelectCharListSelectHunter[1].SetActive(true);
        }
    }
    public void DungenLobbyCharListCharList3SelectHunter()
    {
        HunterData myHunterData = characterList.GetDungenHunterData(2 + (ManagementPageNum * 4));
        if (myHunterData != null)
        {
            dungenLobbyUnitSelectCharListSelectHunter[2].SetActive(true);
        }
    }
    public void DungenLobbyCharListCharList4SelectHunter()
    {
        HunterData myHunterData = characterList.GetDungenHunterData(3 + (ManagementPageNum * 4));
        if (myHunterData != null)
        {
            dungenLobbyUnitSelectCharListSelectHunter[3].SetActive(true);
        }
    }

    //던전 CharList에서 캐릭터 선택후 선택버튼 누름
    private void DungenLobbyCharListCharListSelectHunterSelectSet(int num,int getDungenHunterDataNum)
    {
        if (hunterSelected[num])
        {
            Destroy(dungeonHunterList[num].gameObject);
            Destroy(dungeonHunterUnitList[num].gameObject);
        }
        HunterData myHunterData = characterList.GetDungenHunterData(getDungenHunterDataNum + (ManagementPageNum * 4));
        if (myHunterData != null)
        {
            characterList.SelectedHunterGoToDungeon(myHunterData, num);
            dungenLobbyUnitSelect.SetActive(false);
            for (int i = 0; i < dungenLobbyUnitSelectCharListSelectHunter.Length; i++)
            {
                dungenLobbyUnitSelectCharListSelectHunter[i].SetActive(false);
            }
            switch(num)
                {
                case 0:                
                    dungeonHunterList[num] = Instantiate(myHunterData, new Vector3(-4, (float)33.3, 0), new Quaternion(0,180,0,0));
                    dungeonHunterList[num].gameObject.transform.localScale = new Vector3((float)2.2, (float)2.2, (float)2.2);
                    dungeonHunterUnitList[num] = Instantiate(myHunterData, new Vector3((float)-1, (float)36.5, 0f), new Quaternion(0, 180, 0, 0));
                    dungeonHunterUnitList[num].transform.localScale = new Vector3((float)2.5, (float)2.5, (float)2.5);
                    break;
                case 1:
                    dungeonHunterList[1] = Instantiate(myHunterData, new Vector3(-4, (float)30.73, 0), new Quaternion(0, 180, 0, 0));
                    dungeonHunterList[1].gameObject.transform.localScale = new Vector3((float)2.2, (float)2.2, (float)2.2);
                    dungeonHunterUnitList[1] = Instantiate(myHunterData, new Vector3((float)-2.3, (float)36.5, 0f), new Quaternion(0, 180, 0, 0));
                    dungeonHunterUnitList[1].transform.localScale = new Vector3((float)2.5, (float)2.5, (float)2.5);
                    break;
                case 2:
                    dungeonHunterList[2] = Instantiate(myHunterData, new Vector3(-4, (float)27.78, 0), new Quaternion(0, 180, 0, 0));
                    dungeonHunterList[2].gameObject.transform.localScale = new Vector3((float)2.2, (float)2.2, (float)2.2);
                    dungeonHunterUnitList[2] = Instantiate(myHunterData, new Vector3((float)-3.6, (float)36.5, 0f), new Quaternion(0, 180, 0, 0));
                    dungeonHunterUnitList[2].transform.localScale = new Vector3((float)2.5, (float)2.5, (float)2.5);
                    break;

                case 3:
                    dungeonHunterList[3] = Instantiate(myHunterData, new Vector3(-4, (float)24.99, 0), new Quaternion(0, 180, 0, 0));
                    dungeonHunterList[3].gameObject.transform.localScale = new Vector3((float)2.2, (float)2.2, (float)2.2);
                    dungeonHunterUnitList[3] = Instantiate(myHunterData, new Vector3((float)-4.9, (float)36.5, 0f),  new Quaternion(0,180,0,0));
                    dungeonHunterUnitList[3].transform.localScale = new Vector3((float)2.5, (float)2.5, (float)2.5);
                    break;

            }
            dungenLobbyCharname[num].text = myHunterData.name.ToString();
            dungenLobbyCharMaxHpText[num].text = myHunterData.maxHp.ToString();
            dungenLobbyCharCurrentHpText[num].text= myHunterData.currentHp.ToString();
            dungenLobbyCharLevelText[num].text = myHunterData.level.ToString();
            for (int d = 0; d < hunterList.Count; d++)
            {
                if (hunterList[d] != null)
                    Destroy(hunterList[d].gameObject);
            }
            for (int d = 0; d < hunterSelected.Length; d++)
            {
                if (hunterSelected[d])
                {
                    dungeonHunterList[d].gameObject.SetActive(true);
                    dungeonHunterUnitList[d].gameObject.SetActive(true);
                }
            }
            hunterSelected[num] = true;
            dungenLobbyUnitSelect.SetActive(false);

        }

    }






    //던전 로비에서 캐릭터 선택
    public void DungeonLobbyCharList1()
    {
        characterList.DungenHunterListReset();
        hunterSelectedNum = 0;
        DungenLobbyCharListButtonDown();
    }
    public void DungeonLobbyCharList2()
    {
        characterList.DungenHunterListReset();
        hunterSelectedNum = 1;
        DungenLobbyCharListButtonDown();
    }
    public void DungeonLobbyCharList3()
    {
        characterList.DungenHunterListReset();
        hunterSelectedNum = 2;
        DungenLobbyCharListButtonDown();
    }
    public void DungeonLobbyCharList4()
    {
        characterList.DungenHunterListReset();
        hunterSelectedNum = 3;
        DungenLobbyCharListButtonDown();
    }

    //던전 캐릭터리스트에서 캐릭터 선택 결정
    public void DungeonLobbyCharListCharList1SelectHunterSelect()
    {
        DungenLobbyCharListCharListSelectHunterSelectSet(hunterSelectedNum, 0);
    }

    public void DungeonLobbyCharListCharList2SelectHunterSelect()
    {
        DungenLobbyCharListCharListSelectHunterSelectSet(hunterSelectedNum, 1);
    }

    public void DungeonLobbyCharListCharList3SelectHunterSelect()
    {
        DungenLobbyCharListCharListSelectHunterSelectSet(hunterSelectedNum, 2);
    }

    public void DungeonLobbyCharListCharList4SelectHunterSelect()
    {
        DungenLobbyCharListCharListSelectHunterSelectSet(hunterSelectedNum, 3);
    }

    //던전 캐릭터리스트에서 캐릭터 선택 캔슬
    public void DungeonLobbyCharListCharList1SelectHunterCancle()
    {
        dungenLobbyUnitSelectCharListSelectHunter[0].SetActive(false);
    }

    public void DungeonLobbyCharListCharList2SelectHunterCancle()
    {
        dungenLobbyUnitSelectCharListSelectHunter[1].SetActive(false);
    }

    public void DungeonLobbyCharListCharList3SelectHunterCancle()
    {
        dungenLobbyUnitSelectCharListSelectHunter[2].SetActive(false);
 
    }

    public void DungeonLobbyCharListCharList4SelectHunterCancle()
    {
        dungenLobbyUnitSelectCharListSelectHunter[3].SetActive(false);
 
    }

    //던전로비에서 캐릭터창을 누른후 캔슬버튼
    public void DungeonLobbyCharListCharListCancle()
    {
        for (int d = 0; d < hunterSelected.Length; d++)
        {
            if (hunterSelected[d])
            {
                dungeonHunterList[d].gameObject.SetActive(true);
                dungeonHunterUnitList[d].gameObject.SetActive(true);
            }

            dungenLobbyUnitSelectCharListSelectHunter[d].SetActive(false);
        }
        for (int d = 0; d < hunterList.Count; d++)
        {
            if (hunterList[d] != null)
                Destroy(hunterList[d].gameObject);
        }
        dungenLobbyUnitSelect.SetActive(false);

    }


    //던전창에서 나가기
    public void DungeonCancleButtonDown()
    {
        isDLOpen = false;
        uiCamera.transform.position = new Vector3(0, 0, -10);
        upSide.SetActive(true);
        unitListNum.SetActive(true);
        mainLobby.SetActive(true);
        dungenLobby.SetActive(false);
        dungenLobbyUnitSelect.SetActive(true);
        selectedDungeonHunterListNum = characterList.ResetDungeonHunterSelected();
        ManagementPageNum = 0;

        for (int d = 0; d < hunterSelected.Length; d++)
        {
            if (hunterSelected[d])
            {
                if (dungeonHunterList[d] != null)
                {
                    Debug.Log("던전캐릭터삭제");
                    Destroy(dungeonHunterList[d].gameObject);
                }
                if (dungeonHunterUnitList[d] != null)
                {
                    Debug.Log("던전캐릭터삭제");
                    Destroy(dungeonHunterUnitList[d].gameObject);
                }
                hunterSelected[d] = false;
            }
        }

    }


    public void DungeonLobbyStart()
    {
        GetSelectedDungeonHunterListNum();
        if (selectedDungeonHunterListNum > 0)
        {
            가림판.SetActive(true);
            dungeonLobbyCancle.SetActive(false);
            dungeonLobbyStop.SetActive(true);
            dungeonStart.SetActive(false);
            monsterList.InstanciateMonster();

            Run();
            dungeon = true;
        }
    }
    public void GetSelectedDungeonHunterListNum()
    {
        selectedDungeonHunterListNum = characterList.DungeonHunterSelected();
    }

    public void EixtDungeon()
    {
        isDLOpen = false;
        가림판.SetActive(false);
        dungeonLobbyCancle.SetActive(true);
        dungeonLobbyStop.SetActive(false);
        dungeonStart.SetActive(true);
        DungeonCancleButtonDown();
        eixtDungeonButton.SetActive(false);
        victory.SetActive(false);
        lose.SetActive(false);
        ManagementPageNum = 0;
        for (int d = 0; d < hunterList.Count; d++)
        {
            if (hunterList[d] != null)
                Destroy(hunterList[d].gameObject);
            
        }
    }


    public void CalculationHunterHp(int dmg)
    {
        int calculationHunterHp = 0;
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            if (dungeonHunterUnitList[i].currentHp <= dmg)
            {
                dungeonHunterUnitList[i].currentHp -= dmg;
                dmg = -dungeonHunterUnitList[i].currentHp;
                dungeonHunterUnitList[i].currentHp = 0;
            }
            else
            {
                dungeonHunterUnitList[i].currentHp -= dmg;
                dmg = 0;
            }
            dungenLobbyCharCurrentHpText[i].text = dungeonHunterUnitList[i].currentHp.ToString();
        }
    }
    
    public int CalculationHunterHpAdd()
    {
        int addHp = 0;
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            addHp += dungeonHunterUnitList[i].currentHp;
        }
        return addHp;
    }


    public void Run()
    {
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            Debug.Log(i);
            for(int o = 0; o < CharacterList.selectedDungeonHunter.Length; o++)
            if (CharacterList.selectedDungeonHunter[o])
            {
                dungeonHunterUnitList[o].Run();
            }

        }
    }


    public void Attack()
    {
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            Debug.Log(i);
            for (int o = 0; o < CharacterList.selectedDungeonHunter.Length; o++)
                if (CharacterList.selectedDungeonHunter[o])
                {
                    dungeonHunterUnitList[o].Attack();
                }

        }
    }

    public void Idle()
    {
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            Debug.Log(i);
            for (int o = 0; o < CharacterList.selectedDungeonHunter.Length; o++)
                if (CharacterList.selectedDungeonHunter[o])
                {
                    dungeonHunterUnitList[o].idle();
                }

        }
    }

    public void Death()
    {
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            Debug.Log(i);
            for (int o = 0; o < CharacterList.selectedDungeonHunter.Length; o++)
                if (CharacterList.selectedDungeonHunter[o])
                {
                    dungeonHunterUnitList[o].Death();
                }
        }
    }

    public void SetPower()
    {
        power = 0;
        for (int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            if (dungeonHunterUnitList[i].currentHp > 0)
            {
                power += dungeonHunterUnitList[i].power;
            }
        }
    }
    public int GetPower()
    {
        SetPower();
        return power;
    }

    public void Calculate()
    {
        for (int i = 0; i < dungeonMonsterList.Length; i++)
        {
            money += dungeonMonsterList[i].Money;
            exp += dungeonMonsterList[i].exp;
        } 
        for(int i = 0; i < selectedDungeonHunterListNum; i++)
        {
            dungeonHunterUnitList[i].currentExp += exp;
            characterList.SetSelectedDungeonHunterList(dungeonHunterUnitList[i]);
        }

    }
    public void Lose()
    {
        lose.SetActive(true);
        eixtDungeonButton.SetActive(true);
        targetOn = false;
        dungeon = false;
        Death();
        monsterList.monsterWin = true;
        eixtDungeonButton.SetActive(true);
        monsterList.monsterNum = 0;
    }
           
    public void NextDay()
    {
        newDay++;
    }

}
