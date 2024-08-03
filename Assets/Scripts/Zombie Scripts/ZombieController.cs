using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private ZombieAnimation zombie_Animation;
    private ZombieMovement zombie_Movement;

    private Transform targetTransform;
    private bool canAttack;
    private bool zombieAlive;

    public GameObject damageCollider;

    public int zombieHealth = 10;
    public GameObject[] fxDead;

    private float timerAttack;

    private int fireDamage = 10;

    public GameObject coinCollectible;

    void Start()
    {
        zombie_Animation = GetComponent<ZombieAnimation>();
        zombie_Movement = GetComponent<ZombieMovement>();

        zombieAlive = true;

        targetTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    void Update()
    {
        if (zombieAlive)
        {
            CheckDistance();
        }
    }

    void CheckDistance()
    {
        if (targetTransform)
        {
            if (Vector3.Distance(targetTransform.position, transform.position) > 1.5f)
            {
                zombie_Movement.Move(targetTransform);
            }
            else
            {
                if (canAttack)
                {
                    zombie_Animation.Attack();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.PLAYER_HEALTH_TAG || target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.FENCE_TAG)
        {
            canAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == TagManager.PLAYER_HEALTH_TAG || target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.FENCE_TAG)
        {
            canAttack = false;
        }
    }

} // class
