using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator anim;
    public int jobCode = 0;
    public string name = "";
    public int maxHp = 200;
    public int currentHp = 200;
    public int power = 10;
    public int Money = 100;
    public int exp = 10;
    public int moveSpeed = 3;
    public bool targetOn = false;
    public MonsterList monsterList;
    public bool move = true;

    private void Start()
    {

        name = "";
        maxHp = 200;
        currentHp = 200;
        power = 1;
        Money = 100;
        exp = 10;
        anim = GetComponent<Animator>();
        switch (jobCode)
        {
            case 0:
                anim.SetFloat("AttackState", 0);
                break;
            case 1:
                anim.SetFloat("AttackState", (float)0.5);
                break;
            case 2:
                anim.SetFloat("AttackState", (float)1);
                break;
            case 3:
                anim.SetFloat("AttackState", (float)1);
                break;
        }
    }

    private void Update()
    {
        Debug.DrawRay(this.transform.position,new Vector3(-1,0,0)* 4,new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, new Vector3(-1, 0, 0), 4f, LayerMask.GetMask("Hunter"));;
        Debug.Log(rayHit.collider);
        if (rayHit.collider == null && currentHp > 0)
        {
            Run();
            if(move)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(rayHit.collider != null && currentHp > 0)
        {
            monsterList.targetOn = true;
            targetOn = true;
            //Attack();
        }
        else if(currentHp <= 0)
        {
            targetOn = false;
            Death();
            if (move)
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }




    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void Run()
    {
        anim.SetFloat("RunState", (float)0.3);
        anim.SetBool("Run", true);
    }
    public void idle()
    {
        anim.SetFloat("RunState", 0);
        anim.SetBool("Run", true);
    }
    public void Death()
    {
        anim.SetTrigger("Die");
        targetOn = false;
    }
}
