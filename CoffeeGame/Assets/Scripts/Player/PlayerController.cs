using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = true;
    public float moveSpeed = 5f;

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
        if (!canMove) return;
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
}
