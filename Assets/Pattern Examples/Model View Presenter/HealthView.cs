using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider healthSlider;        // set max to 1 (normalized) or use maxValue below
    [SerializeField] private TextMeshProUGUI label;      // optional "75 / 100"

    // Call from Presenter
    public void SetHealth(int current, int max)
    {
        if (max <= 0){
            max = 1;
        }
        if (healthSlider)
        {
            // Option A: normalized [0..1]
            healthSlider.value = (float)current / max;

            // Option B: if you prefer absolute values, uncomment:
            // healthSlider.maxValue = max;
            // healthSlider.value = current;
        }

        if (label){
            label.text = $"{current} / {max}";
        }
    }
}