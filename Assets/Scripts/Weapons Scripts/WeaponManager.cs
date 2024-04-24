using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weapons_Unlocked;
    public WeaponController[] total_Weapons;

    [HideInInspector]
    public WeaponController current_Weapon;
    private int current_weapon_index;

    private TypeControlAttack current_type_control;

    private PlayerArmController[] arm_controller;

    private PlayerAnimations playerAnims;

    private bool isShooting;

    void Awake()
    {
        playerAnims = GetComponent<PlayerAnimations>();

        LoadActiveWeapons();

        current_weapon_index = 1;
    }

    void Start()
    {
        arm_controller = GetComponentsInChildren <PlayerArmController>();

        ChangeWeapon(weapons_Unlocked[1]);

        playerAnims.SwitchWeaponAnimation((int)weapons_Unlocked[current_weapon_index].defaultConfig.typeWeapon);
    }

    void LoadActiveWeapons()
    {
        weapons_Unlocked.Add(total_Weapons[0]);

        for (int i = 1; i < total_Weapons.Length;  i++)
        {
            weapons_Unlocked.Add(total_Weapons[i]);
        }
    }

    public void SwitchWeapons()
    {
        current_weapon_index++;

        current_weapon_index = (current_weapon_index >= weapons_Unlocked.Count) ? 0 : current_weapon_index;

        playerAnims.SwitchWeaponAnimation((int)weapons_Unlocked[current_weapon_index].defaultConfig.typeWeapon);

        ChangeWeapon(weapons_Unlocked[current_weapon_index]);
    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if(current_Weapon)
            current_Weapon.gameObject.SetActive(false);

        current_Weapon = newWeapon;
        current_type_control = newWeapon.defaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

        if (newWeapon.defaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {

            for (int i = 0; i < arm_controller.Length; i++)
            {
                arm_controller[i].ChangeToTwoHand();
            }

        }
        else
        {

            for (int i = 0; i < arm_controller.Length; i++)
            {
                arm_controller[i].ChangeToOneHand();
            }
        }
    }

} // class
