using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int _healValue = 10;

    protected override void Effect(GameObject player)
    {
        var playerHealth = player.GetComponent<EntityHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeHealth(_healValue);
        }

        Use(null);
    }
}
