using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public float speed = 6;

    public Animator anim;

    public float HPEnemi=100f;

    public bool walk = false;
    public bool attack = false;


    public void Run()
    {
        walk = true;
        attack = false;
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);
    }

    public void Attacking()
    {
        walk = false;
        attack = true;
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);
    }

    public void Idle()
    {
        walk = false;
        anim.SetBool("Walk", walk);
        attack = false;
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);
    }

    public void Die()
    {
        walk = false;
        attack = false;
        
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health",HPEnemi);
    }



    void Update()
    {
        //anim.SetFloat("Health", HPEnemi);

        //if (HPEnemi != 0)
        //{

        //    if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        //    {
        //        Debug.Log("VIDIT");
        //        if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
        //        {
        //            Run();
        //        }

        //        else if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
        //        {
        //            Attacking();
        //        }
        //    }
        //    else
        //    {
        //        Idle();
        //    }
        //}
        //else
        //    Die();

    }
}
