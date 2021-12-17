using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterList : MonoBehaviour
{

    Animator animation;
    public HunterData[] tankerList;
    public HunterData[] archerList;
    public HunterData[] healerList;
    public HunterData[] magicionList;
    public String[] hunterName = new String[] {"철수","덕수","만수","민수","진수","한수","준수","종수","중수"};

    public static HunterData[] myHunterList = new HunterData[100];
    public static HunterData[] newHunterList = new HunterData[8];
    public static HunterData[] lowHunterHpList = new HunterData[100];
    public static HunterData[] curingHunterList = new HunterData[100];
    public HunterData[] curingHunterList2 = new HunterData[100];
    public static HunterData[] dungenHunterList = new HunterData[100];
    public static HunterData[] selectedDungeonHunterList = new HunterData[4];
    public static bool[] selectedDungeonHunter = new bool[4] { false, false, false, false };
    public static HunterData[] haveWentTodungenHunterList;

    public static int selectedDungeonHunterListNum = 0;
    public static int dungenHunterListNum = 0;
    public static int hunterNum = 0;
    public static int hunterId = 1;
    public static int curingHunterListNum = 0;
    public static int lowHpHunterNum = 0;
    public static int haveWentTodungenHunterNum = 0;



    public static int hunterListMaxNum = 20;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }


    public void SettingHunterCurrentNum()
    {
        for (int i = 0; i < hunterNum; i++)
        {
            myHunterList[i].contractRenewal = myHunterList[i].contractRenewal - 1;
            Debug.Log(myHunterList[i].name + " contractRenewal = " + myHunterList[i].contractRenewal);
            if (myHunterList[i].contractRenewal < 0)
            {
                for (int d = i; d < hunterNum - 1; d++)
                {
                    myHunterList[d] = myHunterList[d + 1];

                }
                Array.Clear(myHunterList, hunterNum, myHunterList.Length);
                hunterNum--;
            }
        }
    }

//계약가능한 헌터 숫자
public int GetHunterListMaxNum()
    {
        return hunterListMaxNum;
    }

    //계약한 헌터 숫자
    public int GetHunterListcurrentNum()
    {
        return hunterNum;
    }

    //새로운 헌터 영입관련

    //새로운 헌터 능력치 설정
    public HunterData SetNewHunterState(int jobNum)
    {
        string name;
        int level;
        int maxHp;
        int currentHp;
        int power;
        int contractRenewal;
        int contractMoney;
        int expMax;
        int currentExp;
        int mood;
        HunterData newHunter = new HunterData();
        switch(jobNum)
        {
            case 1:
                newHunter.name = hunterName[(int)UnityEngine.Random.Range(0,hunterName.Length-1)];
                newHunter.level = UnityEngine.Random.Range(hunterListMaxNum - 19, hunterListMaxNum);
                newHunter.maxHp = newHunter.level * 3;
                newHunter.currentHp = newHunter.maxHp;
                newHunter.power = (int)math.ceil(newHunter.level * 1.5);
                newHunter.contractRenewal = 50;
                newHunter.expMax = newHunter.level * 10;
                newHunter.mood = 4;
                newHunter.contractMoney = newHunter.level * 100;
                break;
            case 2:
                newHunter.name = hunterName[(int)UnityEngine.Random.Range(0, hunterName.Length - 1)];
                newHunter.level = UnityEngine.Random.Range(hunterListMaxNum - 19, hunterListMaxNum);
                newHunter.maxHp = newHunter.level * 2;
                newHunter.currentHp = newHunter.maxHp;
                newHunter.power = (int)math.ceil(newHunter.level * 2.5);
                newHunter.contractRenewal = 50;
                newHunter.expMax = newHunter.level * 10;
                newHunter.mood = 4;
                newHunter.contractMoney = newHunter.level * 100;
                break;
            case 3:
                newHunter.name = hunterName[(int)UnityEngine.Random.Range(0, hunterName.Length - 1)];
                newHunter.level = UnityEngine.Random.Range(hunterListMaxNum - 19, hunterListMaxNum);
                newHunter.maxHp = (int)math.ceil(newHunter.level * 2);
                newHunter.currentHp = newHunter.maxHp;
                newHunter.power = (int)math.ceil(newHunter.level * 1);
                newHunter.contractRenewal = 50;
                newHunter.expMax = newHunter.level * 10;
                newHunter.mood = 4;
                newHunter.contractMoney = newHunter.level * 100;
                break;
            case 4:
                newHunter.name = hunterName[(int)UnityEngine.Random.Range(0, hunterName.Length - 1)];
                newHunter.level = UnityEngine.Random.Range(hunterListMaxNum - 19, hunterListMaxNum);
                newHunter.maxHp = (int)math.ceil(newHunter.level * 1.5);
                newHunter.currentHp = newHunter.maxHp;
                newHunter.power = (int)math.ceil(newHunter.level * 3);
                newHunter.contractRenewal = 50;
                newHunter.expMax = newHunter.level * 10;
                newHunter.mood = 4;
                newHunter.contractMoney = newHunter.level * 100;
                break;
        }
        return newHunter;
    }


    //헌터영입 리스트 초기화
    public void CreateNewHunterList()
    {
        haveWentTodungenHunterNum = 0;
        HunterData newHunterData = new HunterData();
        int charNum;
        for (int i = 0; i < newHunterList.Length; i++)
        {
            int jobNum = (int)UnityEngine.Random.Range(1, 4);
            switch (jobNum)
            {
                case 1:
                    charNum = (int)UnityEngine.Random.Range(0, tankerList.Length-1);
                    newHunterList[i] = tankerList[charNum];
                    newHunterData = SetNewHunterState(jobNum);
                    newHunterList[i].name = newHunterData.name;
                    newHunterList[i].level = newHunterData.level;
                    newHunterList[i].maxHp = newHunterData.maxHp;
                    newHunterList[i].currentHp = newHunterData.currentHp;
                    newHunterList[i].power = newHunterData.power;
                    newHunterList[i].contractRenewal = newHunterData.contractRenewal;
                    newHunterList[i].expMax = newHunterData.expMax;
                    newHunterList[i].mood = newHunterData.mood;
                    newHunterList[i].contractMoney = newHunterData.contractMoney;
                    break;
                case 2:
                    charNum = (int)UnityEngine.Random.Range(0, archerList.Length-1);
                    newHunterList[i] = archerList[charNum];
                    newHunterData = SetNewHunterState(jobNum);
                    newHunterList[i].name = newHunterData.name;
                    newHunterList[i].level = newHunterData.level;
                    newHunterList[i].maxHp = newHunterData.maxHp;
                    newHunterList[i].currentHp = newHunterData.currentHp;
                    newHunterList[i].power = newHunterData.power;
                    newHunterList[i].contractRenewal = newHunterData.contractRenewal;
                    newHunterList[i].expMax = newHunterData.expMax;
                    newHunterList[i].mood = newHunterData.mood;
                    newHunterList[i].contractMoney = newHunterData.contractMoney;
                    break;
                case 3:
                    charNum = (int)UnityEngine.Random.Range(0, healerList.Length-1);
                    newHunterList[i] = healerList[charNum];
                    newHunterData = SetNewHunterState(jobNum);
                    newHunterList[i].name = newHunterData.name;
                    newHunterList[i].level = newHunterData.level;
                    newHunterList[i].maxHp = newHunterData.maxHp;
                    newHunterList[i].currentHp = newHunterData.currentHp;
                    newHunterList[i].power = newHunterData.power;
                    newHunterList[i].contractRenewal = newHunterData.contractRenewal;
                    newHunterList[i].expMax = newHunterData.expMax;
                    newHunterList[i].mood = newHunterData.mood;
                    newHunterList[i].contractMoney = newHunterData.contractMoney;
                    break;
                case 4:
                    charNum = (int)UnityEngine.Random.Range(0, magicionList.Length-1);
                    newHunterList[i] = magicionList[charNum];
                    newHunterData = SetNewHunterState(jobNum);
                    newHunterList[i].name = newHunterData.name;
                    newHunterList[i].level = newHunterData.level;
                    newHunterList[i].maxHp = newHunterData.maxHp;
                    newHunterList[i].currentHp = newHunterData.currentHp;
                    newHunterList[i].power = newHunterData.power;
                    newHunterList[i].contractRenewal = newHunterData.contractRenewal;
                    newHunterList[i].expMax = newHunterData.expMax;
                    newHunterList[i].mood = newHunterData.mood;
                    newHunterList[i].contractMoney = newHunterData.contractMoney;
                    break;
            }
        }
    }

    //새로운 헌터 영입
    public void SelectNewHunter(int charNum)
    {
        myHunterList[hunterNum] = newHunterList[charNum];
        myHunterList[hunterNum].hunterId = hunterId;
        hunterNum++;
        hunterId++;
    }

    //새로운 헌터 데이터 보내주기
    public HunterData GetNewHunterData(int charNum)
    {
        return newHunterList[charNum];
    }



    //유닛 치료 관련

    //치료중인 헌터 데이터 보내주기
    public HunterData GetCuringHunterData(int charNum)
    {
        if(curingHunterListNum<=charNum)
        {
            return null;
        }
        return curingHunterList[charNum];
    }

    //치료중인 헌터 리스트 길이 보내주기
    public int GetCuringHunterListLength()
    {
        return curingHunterList.Length;
    }

    //체력이 풀이아닌 헌터 골라내기
    public void PickOutHunterHp()
    {
        int lowHpHunterNum1 = 0;
        Array.Clear(lowHunterHpList, 0, lowHunterHpList.Length);

        for (int i = 0; i<hunterNum; i++)
        {
            if (myHunterList[i].maxHp > myHunterList[i].currentHp)
            {
                lowHunterHpList[lowHpHunterNum1] = myHunterList[i];
                lowHpHunterNum1++;
            }
        }
        lowHpHunterNum = lowHpHunterNum1;
    }

    //lowHunterList에서 치료 선택
    public void PickOutCuringHunter(int hunterNum)
    {
        curingHunterList[curingHunterListNum] = myHunterList[hunterNum];
        curingHunterListNum++;
    }



    //UnitCare에서 헌터 치료 
    public void HillingUnit()
    {
        int curingHunterNum = 0;

        for(int i = 0; i < curingHunterListNum; i++)
        {
            int hillingHp = curingHunterList[i].maxHp / 4;
            curingHunterList[i].currentHp += hillingHp;
            if(curingHunterList[i].maxHp <= curingHunterList[i].currentHp)
            {
                curingHunterList[i].currentHp = curingHunterList[i].maxHp;
                
                for(int a = 0; a < hunterNum; a++)
                {
                    if(curingHunterList[i].hunterId == myHunterList[a].hunterId)
                    {
                        myHunterList[a] = curingHunterList[i];
                        curingHunterListNum--;
                    }
                }
            }
            else
            {
                curingHunterList2[curingHunterNum] = curingHunterList[i];
                curingHunterNum++;
            }
        }
        Array.Clear(curingHunterList, 0, curingHunterList.Length);
        for(int b = 0; b < curingHunterNum; b++)
        {
            curingHunterList[b] = curingHunterList2[b];
        }
        Array.Clear(curingHunterList2, 0, curingHunterList2.Length);
        curingHunterListNum = curingHunterNum;
    }

    //UnitCare에서 헌터치료 취소
    public void StopHillingUnit(int num)
    {
        int curingHunterNum = 0;

        for (int i = 0; i < curingHunterListNum; i++)
        {
            if(curingHunterList[i].hunterId != curingHunterList[num].hunterId)
            {
                curingHunterList2[curingHunterNum] = curingHunterList[i];
                curingHunterNum++;
                
            }
        }
        curingHunterListNum -= curingHunterNum;

        Array.Clear(curingHunterList, 0, curingHunterList.Length);
        for (int b = 0; b < curingHunterNum; b++)
        {
            curingHunterList[b] = curingHunterList2[b];
        }
        Array.Clear(curingHunterList2, 0, curingHunterList2.Length);

    }


    //유닛 관리 관련

    public HunterData GetMyHunterData(int charNum)
    {
        if (hunterNum <= charNum)
        {
            return null;
        }
        return myHunterList[charNum];
    }

    // 풀피가 아닌 캐릭터만 치료창으로 보낼수 있게
    public int UnitManagementCharListButtonDown(int charNum)
    {
        PickOutHunterHp();
        for (int i = 0; i< lowHpHunterNum; i++)
        {
            if(lowHunterHpList[i].hunterId==myHunterList[charNum].hunterId)
            {
                if (curingHunterListNum != 0)
                {
                    for (int o = 0; o < curingHunterListNum; o++)
                    {
                        if (curingHunterList[o].hunterId != myHunterList[charNum].hunterId)
                        {
                            return 2;
                        }
                    }
                }
                return 1;
            }
        }
        return 0;
    }

    //던전 관련
    public void DungenHunterListReset()
    {
        int s = 0;
        dungenHunterListNum = 0;
        HunterData[] excludedlist = new HunterData[100];
        int excludedlistNum = 0;
         for (int i = 0; i < selectedDungeonHunter.Length; i++)
        {
            if (selectedDungeonHunter[i])
            {
                Debug.Log(selectedDungeonHunter[i] + " " + selectedDungeonHunterList[i].hunterId);
                excludedlist[excludedlistNum] = selectedDungeonHunterList[i];
                excludedlistNum++;
            }

        }
        for (int i = 0; i < haveWentTodungenHunterNum; i++)
        {
     
            excludedlist[excludedlistNum] = haveWentTodungenHunterList[i];
            excludedlistNum++;
        }
        for (int i = 0; i < curingHunterListNum; i++)
        {

            excludedlist[excludedlistNum] = curingHunterList[i];
            excludedlistNum++;
        }
        for (int i = 0; i < hunterNum; i++)
        {
            if(myHunterList[i].currentHp<=0)
            {
                excludedlist[excludedlistNum] = curingHunterList[i];
                excludedlistNum++;
            }
        }
        for(int i = 0; i < hunterNum; i++)
        {
            if (excludedlistNum <= 0)
            {
                dungenHunterList[dungenHunterListNum] = myHunterList[i];
                dungenHunterListNum++;
            }
            else
            {
                for(int e = 0; e < excludedlistNum; e++)
                {
                    if(myHunterList[i] != excludedlist[e])
                    {
                        s++;
                        if(s == excludedlistNum)
                        {
                            dungenHunterList[dungenHunterListNum] = myHunterList[i];
                            dungenHunterListNum++;
                        }
                    }
                }
                s = 0;
            }
        }
        
    }




            //던전헌터리스트 데이터 보내기
    public HunterData GetDungenHunterData(int charNum)
    {
        if(dungenHunterListNum <= charNum)
        {
            return null;
        }
        return dungenHunterList[charNum];
    }

    //던전헌터리스트 길이 보내기
    public int GetDungenHunterListLength()
    {
        return dungenHunterListNum;
    }

    //던전에 갈 헌터 선택
    public void SelectedHunterGoToDungeon(HunterData hunterData, int num)
    { 
        selectedDungeonHunterList[num] = hunterData;
        selectedDungeonHunter[num] = true;
    }

    //던전에 갈 헌터 숫자
    public int DungeonHunterSelected()
    {
        for(int i = 0; i< selectedDungeonHunter.Length; i++)
        {
            if(selectedDungeonHunter[i])
            {
                selectedDungeonHunterListNum++;
            }

        }
        return selectedDungeonHunterListNum;
    }
    
    //던전에 갈 헌터 숫자 초기화
    public int ResetDungeonHunterSelected()
    {
        for (int i = 0; i < selectedDungeonHunter.Length; i++)
        {
            selectedDungeonHunter[i] = false;
        }
        selectedDungeonHunterListNum = 0;
        return selectedDungeonHunterListNum;
    }



    public void SetSelectedDungeonHunterList(HunterData hunterData)
    {
        for(int m = 0; m < hunterNum; m++)
        {
            if(myHunterList[m].hunterId==hunterData.hunterId)
            {
                Debug.Log("myHunterList[m].name" + myHunterList[m].name);
                Debug.Log("hunterData.name " + hunterData.name);
                Debug.Log("myHunterList[m].lv" + myHunterList[m].level);
                Debug.Log("hunterData.lv "+hunterData.level);
                myHunterList[m] = hunterData;
            }
        }

        selectedDungeonHunterList[haveWentTodungenHunterNum] = hunterData;
        haveWentTodungenHunterNum++;

    }





}
