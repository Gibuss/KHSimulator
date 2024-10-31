using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] UnityEvent _destroyFeedback;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _Player) 
            Debug.Log("blabla");
        {
            Effect(other.gameObject); 
        }
    }

    protected virtual void Effect(GameObject player) 
    {
    }

    public virtual void Use(PickUpItem pui)
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.enabled = false; 
        }

        _destroyFeedback?.Invoke();
        Destroy(gameObject, 3f);
    }
}
