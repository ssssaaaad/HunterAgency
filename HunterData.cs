using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterData : MonoBehaviour
{

    public Animator anim;
    public int jobCode;
    public int hunterId = 0;
    public string name = "";
    public int level = 0;
    public int maxHp = 0;
    public int currentHp = 0;
    public int power = 0;
    public int contractRenewal = 0;
    public int contractMoney = 0;
    public int expMax = 0;
    public int currentExp = 0;
    public int mood = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        switch(jobCode)
        {
            case 0:
                anim.SetFloat("AttackState", 0);
                break;
            case 1:
                anim.SetFloat("AttackState",(float) 0.5);
                break;
            case 2:
                anim.SetFloat("AttackState", (float)1);
                break;
            case 3:
                anim.SetFloat("AttackState", (float)1);
                break;
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
    }
    public void Walk()
    {
        anim.SetFloat("RunState", 1);
        anim.SetBool("Run", true);
    }

}
