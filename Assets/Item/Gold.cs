using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] private int goldValue = 15; 
    [SerializeField] private GoldManager goldManager;

    protected override void Effect(GameObject player)
    {
        if (goldManager != null) 
        {
            goldManager.AddGold(goldValue); 
        }
        else
        {
            Debug.LogWarning("GoldManager reference is not set in " + gameObject.name);
        }

        Use(null); 
    }
}
