using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    private List<GameObject> bullet_Fall_FX = new List<GameObject>();
    private List<GameObject> bullet_Prefabs = new List<GameObject>();
    private List<GameObject> rocket_Bullet_Prefabs = new List<GameObject>();

    void Awake()
    {
        MakeInstance();
    }

    void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateBulletAndBulletFall(GameObject bullet, GameObject bulletFall, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject temp_Bullet = Instantiate(bullet);
            GameObject temp_Bullet_Fall = Instantiate(bulletFall);

            bullet_Prefabs.Add(temp_Bullet);
            bullet_Fall_FX.Add(temp_Bullet_Fall);

            bullet_Prefabs[i].SetActive(false);
            bullet_Fall_FX[i].SetActive(false);
        }
    }

    public void CreateRocket(GameObject rocket, int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject temp_Rocket_bullet = Instantiate(rocket);

            rocket_Bullet_Prefabs.Add(temp_Rocket_bullet);

            rocket_Bullet_Prefabs[i].SetActive(false);
        }
    }    

    public GameObject SpawnBulletFallFX(Vector3 position, Quaternion rotation)
    {
        for(int i = 0; i < bullet_Fall_FX.Count; i++)
        {
            if (!bullet_Fall_FX[i].activeInHierarchy)
            {
                bullet_Fall_FX[i].SetActive(true);
                bullet_Fall_FX[i].transform.position = position;
                bullet_Fall_FX[i].transform.rotation = rotation;

                return bullet_Fall_FX[i];
            }
        }
        return null;
    }

    public void SpawnBullet(Vector3 position,Vector3 direction, Quaternion rotation, NameWeapon weaponName)
    {
        if(weaponName != NameWeapon.ROCKET)
        {
            for (int i = 0; i < bullet_Prefabs.Count; i++)
            {
                if (!bullet_Prefabs[i].activeInHierarchy)
                {
                    bullet_Prefabs[i].SetActive(true);
                    bullet_Prefabs[i].transform.position = position;
                    bullet_Prefabs[i].transform.rotation = rotation;

                    // GET THE BULLET SCRIPT    

                    // SET BULLET DAMAGE

                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < rocket_Bullet_Prefabs.Count; i++)
            {
                if (!rocket_Bullet_Prefabs[i].activeInHierarchy)
                {
                    rocket_Bullet_Prefabs[i].SetActive(true);
                    rocket_Bullet_Prefabs[i].transform.position = position;
                    rocket_Bullet_Prefabs[i].transform.rotation = rotation;

                    // GET THE BULLET SCRIPT

                    // SET BULLET DAMAGE

                    break;
                }
            }
        }
    }

} // class
