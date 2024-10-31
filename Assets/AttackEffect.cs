using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject positionReference;
    public GameObject attackFXPrefab;

    public void PlayAttackFX()
    {
        if (attackFXPrefab != null && positionReference != null)
        {
            Vector3 spawnPosition = positionReference.transform.position;
            spawnPosition += positionReference.transform.forward * 1.0f;
            Instantiate(attackFXPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
