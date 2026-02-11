using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventListener_WithParams : MonoBehaviour
{
    [Header("Optional UI references")]
    public Slider slider;
    public GameObject box;
    public TextMeshProUGUI textBox;

    public void OnFloatReceived(float value)
    {
        Debug.Log($"Listener: Float received ({value})");
        if (slider) slider.value = value;
    }

    public void OnIntReceived(int value)
    {
        Debug.Log($"Listener: Int received ({value})");
        if (textBox) textBox.text = $"Count: {value}";
    }

    public void OnBoolReceived(bool value)
    {
        Debug.Log($"Listener: Bool received ({value})");
        if (box) box.SetActive(value);
    }

    public void OnStringReceived(string message)
    {
        Debug.Log($"Listener: String received ({message})");
        if (textBox) textBox.text = message;
    }
}