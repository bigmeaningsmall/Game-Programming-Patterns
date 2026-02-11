using TMPro;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    private static bool isShuttingDown = false;

    public static Singleton Instance
    {
        get
        {
            if (isShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance already destroyed. Returning null.");
                return null;
            }

            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Handle duplicates
        if (instance != null && instance != this)
        {
            Debug.LogWarning("[Singleton] Duplicate found – destroying extra copy.");
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private static void SetupInstance()
    {
        instance = FindObjectOfType<Singleton>();

        if (instance == null)
        {
            GameObject go = new GameObject("Singleton");
            instance = go.AddComponent<Singleton>();
            DontDestroyOnLoad(go);
            Debug.Log("[Singleton] Created new instance at runtime.");
        }
        else
        {
            Debug.Log("[Singleton] Using existing scene instance.");
        }
    }

    private void OnApplicationQuit()
    {
        isShuttingDown = true;
    }

    private void OnDestroy()
    {
        if (instance == this)
            isShuttingDown = true;
    }

    // --- Example data & UI display ---
    public int counter = 0;
    [SerializeField] private TextMeshProUGUI counterText;

    public void IncrementCounter()
    {
        counter++;
        Debug.Log($"[Singleton] Counter = {counter}");

        if (counterText != null)
        {
            counterText.text = $"Counter: {counter}";
        }
    }
}