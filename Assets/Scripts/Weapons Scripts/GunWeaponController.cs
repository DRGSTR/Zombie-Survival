using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_Shot;
    public GameObject fx_BulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_ColliderWait = new WaitForSeconds(0.02f);

    void Start()
    {
        if(!GamePlayController.instance.bullet_And_BulletFX_Created)
        {
            GamePlayController.instance.bullet_And_BulletFX_Created = true;

            if (nameWP != NameWeapon.FIRE && nameWP != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bulletPrefab, fx_BulletFall, 100);
            }
        }

        if(GamePlayController.instance.rocket_Bullet_created)
        {
            if(nameWP == NameWeapon.ROCKET)
            {
                GamePlayController.instance.rocket_Bullet_created = true;

                SmartPool.instance.CreateRocket(bulletPrefab, 100);
            }
        }
        
    }

    public override void ProcessAttack()
    {
       // base.ProcessAttack();

        switch (nameWP)
        {
            case NameWeapon.PISTOL:
                break;

            case NameWeapon.MP5:
                break;

            case NameWeapon.M3:
                break;

            case NameWeapon.AK:
                break;

            case NameWeapon.AWP:
                break;

            case NameWeapon.FIRE:
                break;

            case NameWeapon.ROCKET:
                break;
        } // switch and case
        
        // SPAWN BULLET

    } // PROCESS ATTACK

    IEnumerator WaitForShootEffect()
    {
        yield return wait_Time;
        fx_Shot.Play();
    }

    IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;

        yield  return fire_ColliderWait;

        fireCollider.enabled = false;
    }

} // class
