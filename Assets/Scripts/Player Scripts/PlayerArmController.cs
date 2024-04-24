using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{
    public Sprite one_hand_Sprite, two_hand_Sprite;

    private SpriteRenderer sr;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOneHand()
    {
        sr.sprite = one_hand_Sprite;
    }

    public void ChangeToTwoHand()
    {
        sr.sprite = two_hand_Sprite;
    }

} // class
