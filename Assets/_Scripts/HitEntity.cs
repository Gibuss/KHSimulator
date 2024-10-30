using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] int zoneDamage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        { 
            Player.GetComponent<EntityHealth>().TakeDamage(zoneDamage);
        }
    }
}
