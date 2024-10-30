using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] GameObject Player;
    [SerializeField] int _healValue = 10;
    //public override void Use(PickUpItem pui)
    //{
    //    base.Use(pui);



    //}

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<EntityHealth>().TakeHealth(_healValue);
        Destroy(gameObject);
    }
}
