using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitEntity : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] int _baseDamage = 10;
    private int _originalDamage;
    private bool _isInRange = false;
    public InputActionReference _baseAttack;

    [SerializeField] GameObject animatorContainer;

    private bool _isAttacking = false;

    private void Awake()
    {
        _originalDamage = _baseDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            _isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            _isInRange = false;
        }
    }

    void OnEnable()
    {
        _baseAttack.action.performed += OnAttackPerformed;
    }

    void OnDisable()
    {
        _baseAttack.action.performed -= OnAttackPerformed;
    }

    public void OnAttackPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_isInRange && !_isAttacking)
            {
                string pressedKey = context.control.name;
                TriggerAttackAnimation();
                Player.GetComponent<EntityHealth>().TakeDamage(_baseDamage);
            }
        }
    }

    private void TriggerAttackAnimation()
    {
        Animator animator = animatorContainer.GetComponent<Animator>();

        if (animator != null)
        {
            _isAttacking = true;
            animator.SetBool("Attack", true);
            StartCoroutine(ResetAttackAnimation(animator));
        }
    }

    private IEnumerator ResetAttackAnimation(Animator animator)
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Attack", false);
        _isAttacking = false;
    }

    public void ModifyBaseDamage(float multiplier)
    {
        _baseDamage = Mathf.RoundToInt(_baseDamage * multiplier);
    }

    public void ResetBaseDamage()
    {
        _baseDamage = _originalDamage;
    }
}
