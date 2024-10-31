using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] int _currentLife;
    [SerializeField] int _maxLife;
    [SerializeField] Slider _healthSlide;

    void Awake()
    {
        _currentLife = _maxLife;
        _text.text = $"{_currentLife} / {_maxLife}";
    }

    void Start()
    {
        _healthSlide.maxValue = _maxLife;
        _healthSlide.value = _healthSlide.maxValue;
    }

    void Update()
    {
        _healthSlide.value = _currentLife;

        if (Input.GetKeyDown(KeyCode.E) && _currentLife > 0)
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (_currentLife > 0)
        {
            _currentLife -= damageAmount;
            _text.text = $"{_currentLife} / {_maxLife}";
            if (_currentLife < 0)
            {
                _currentLife = 0;
                _text.text = $"{_currentLife} / {_maxLife}";
            }
        }

        else
        {
            Debug.Log("Player est mort");
        }
    }

    public void TakeHealth(int healthAmount)
    {
        if (_currentLife > 0 &&  _currentLife < _maxLife)
        {
            _currentLife += healthAmount;
            _text.text = $"{_currentLife} / {_maxLife}";
            if (_currentLife > _maxLife)
            {
                _currentLife = _maxLife;
            }
        }

        else
        {
            Debug.Log("Player est déjà full life");
        }
    }

    private void OnValidate()
    {
        if (_maxLife <= 0)
        {
            Debug.Log("Pas possible de mettre la maxLife < ou = à 0");
            _maxLife = 100;
        }
    }
}
