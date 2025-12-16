using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = true;
    public bool canDash = true;
    public float moveSpeed = 5f;
    public float dashDistance = 5f;

    private bool isDashing = false;

    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Animation")]
    public Animator animator;

    private PlayerControls controls;

    [ProgressBar("currentHealth", "maxHealth", EColor.Red)]
    public float currentHealth;
    public float maxHealth = 100f;


    public event Action<float, float> OnHealthChanged;

    [SerializeField]
    private PlayerInventory inventory;

    private void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();

        // Subscribes to the Move action
        controls.Gameplay.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movement = Vector2.zero;
        controls.Gameplay.Pause.performed += ctx => GameManager.Instance.TogglePause();
        controls.Gameplay.Dash.performed += ctx => Dash();
        controls.Gameplay.Use.performed += ctx => UseItem();
        controls.Gameplay.Interact.performed += ctx => Interact();
        controls.Gameplay.Interact.performed += ctx => Attack();
    }
    void Start()
    {
        GameManager.Instance.RegisterPlayer(this, inventory);
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    private void FixedUpdate()
    {
        if (!canMove || isDashing) return;
        // Updates potion based on input
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (animator != null)
        {
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    [Button]
    public void TakeDamage()
    {
        TakeDamage(45);
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
    private void Dash()
    {
        if (isDashing || movement == Vector2.zero) return;

        StartCoroutine(DashCoroutine());
    }
    private void UseItem()
    {

    }
    private void Interact()
    {

    }
    private void Attack()
    {

    }
    private IEnumerator DashCoroutine()
    {
        isDashing = true;

        Vector2 startPos = rb.position;
        Vector2 targetPos = startPos + movement.normalized * dashDistance;

        float dashTime = 0.15f; // Duration of the dash
        float elapsed = 0f;

        while (elapsed < dashTime)
        {
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsed / dashTime));
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(targetPos);
        isDashing = false;
        
    }

}
