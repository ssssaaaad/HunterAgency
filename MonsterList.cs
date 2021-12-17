using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterList : MonoBehaviour
{
    public GameManager gameManager;

    public Monster[] monstersList;
    public Monster[] fightMonsters = new Monster[1];
    public Monster[] InstanciateMonsterList = new Monster[1];
    public bool targetOn = false;
    public bool gameStart = false;
    public float attackCoolTime = 0;
    public bool monsterWin = false;

    int hunterPower = 0;
    int monsterHp;
    int monsterPower;
    public int monsterNum = 0;

    private void Update()
    { 
        if (!gameStart)
        {
 
        }
        if (gameStart)
        {

            targetOn = InstanciateMonsterList[0].targetOn;
            InstanciateMonsterList[0].move = true;

        }
        if(targetOn)
        {
            attackCoolTime =+ Time.deltaTime;
            if (attackCoolTime < 3)
            {
                hunterPower=gameManager.GetPower();
                if (InstanciateMonsterList[0].currentHp > 0)
                {
                    InstanciateMonsterList[0].Attack();
                }
                attackCoolTime = 0;
                Debug.Log("hunterPower = "+ hunterPower);
                InstanciateMonsterList[0].currentHp -= hunterPower;
                Debug.Log(InstanciateMonsterList[0].currentHp);
                if (InstanciateMonsterList[0].currentHp <= 0)
                {
                    targetOn = false;
                    InstanciateMonsterList[0].Death();
                    DestroyMonster();                
                    monsterNum++;
                    if(monsterNum >=3)
                    {
                        gameStart = false;
                        InstanciateMonsterList[0].move = false;
                    }
                    else
                    {
                        InstanciateMonster();
                    }
                }
                if (monsterWin)
                {
                    DestroyMonster();
                    monsterWin = false;
                    gameStart = false;
                    targetOn = false;
                }
            }
           
        }
    }

    public Monster GetMonsterData()
    {
        return InstanciateMonsterList[0];
    }

    public int GetMonsterPower()
    {
        return InstanciateMonsterList[0].power;
    }
   
    

    public void InstanciateMonster()
    {
        int ran = Random.Range(0, monstersList.Length - 1);
        fightMonsters[0] = monstersList[ran];
        InstanciateMonsterList[0] = Instantiate(fightMonsters[0], new Vector3((float)24.7, (float)36.54, 0), transform.rotation);
        gameStart = true;

    }
    public void DestroyMonster()
    {
        Destroy(InstanciateMonsterList[0].gameObject,4f);
    }

}
