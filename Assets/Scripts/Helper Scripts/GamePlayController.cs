using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [HideInInspector]
    public bool bullet_And_BulletFX_Created, rocket_Bullet_created;
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
}
