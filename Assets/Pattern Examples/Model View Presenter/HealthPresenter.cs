using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [Header("MVC References")]
    [SerializeField] private HealthModel model;
    [SerializeField] private HealthView view;

    [Header("Demo Controls")]
    [SerializeField] private int healAmount = 10;
    [SerializeField] private int damageAmount = 15;

    private void OnEnable()
    {
        if (model != null)
            model.HealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        // Push initial state to the view
        if (model != null) OnHealthChanged(model.CurrentHealth, model.MaxHealth);
    }

    private void OnDisable()
    {
        if (model != null)
            model.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int current, int max)
    {
        if (view != null)
            view.SetHealth(current, max);
    }

    // --- Public methods (wire these to UI Buttons) ---
    public void Heal()   => model?.Heal(healAmount);
    public void Damage() => model?.Damage(damageAmount);
    public void ResetHP()=> model?.Restore();

    // --- Optional: keyboard demo ---
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) Heal();
        if (Input.GetKeyDown(KeyCode.D)) Damage();
        if (Input.GetKeyDown(KeyCode.R)) ResetHP();
    }
}