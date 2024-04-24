using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private WeaponManager weaponManager;

    [HideInInspector]
    public bool canShoot;

    private bool isHoldAttack;
    void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            weaponManager.SwitchWeapons();        
        }
    }
} // class
