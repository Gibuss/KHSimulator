using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] float _powerUpValue = 1.5f;
    [SerializeField] float _basePowerUpValue = 1f;
    [SerializeField] GameObject _hitScriptParent;
    [SerializeField] int _timerBoost;
    private bool _isBonus = false;

    protected override void Effect(GameObject player)
    {
        var playerPowerUp = player.GetComponent<HitEntity>();

        if (playerPowerUp != null && !_isBonus) 
        {
            _isBonus = true;
            playerPowerUp.ModifyBaseDamage(_powerUpValue); 
            StartCoroutine(ActivateBonus(playerPowerUp));
        }
    }

    public IEnumerator ActivateBonus(HitEntity playerPowerUp)
    {
        yield return new WaitForSeconds(_timerBoost);

        playerPowerUp.ResetBaseDamage();
        _isBonus = false;
        Use(null);
    }
}
