using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //дистанция от которой он начинает видеть игрока
    public float seeDistance = 10f;
    //дистанция до атаки
    public float attackDistance = 1f;
    //скорость енеми
    public float speed = 6;
    //игрок
    public Transform target;

    public Animator anim;

    public float HPEnemi=100f;

    public bool walk = false;
    public bool attack = false;


    void Run()
    {
        walk = true;
        attack = false;
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);
        transform.LookAt(target.transform);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    void Attacking()
    {
        walk = false;
        attack = true;
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);

        transform.LookAt(target.transform);
    }

    void Idle()
    {
        walk = false;
        anim.SetBool("Walk", walk);
        attack = false;
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health", HPEnemi);
    }

    void Die()
    {
        walk = false;
        attack = false;
        
        anim.SetBool("Walk", walk);
        anim.SetBool("Attack", attack);
        anim.SetFloat("Health",HPEnemi);
    }


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        walk = false;
        attack = false;
    }



    void Update()
    {
        anim.SetFloat("Health", HPEnemi);

        if (HPEnemi != 0)
        {

            if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
            {
                Debug.Log("VIDIT");
                if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
                {
                    Run();
                }

                else if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
                {
                    Attacking();
                }
            }
            else
            {
                Idle();
            }
        }
        else
            Die();
        
    }
}
