using UnityEngine;

public class SaveController : MonoBehaviour
{
    public DataSerialisationManager dataManager;

    private void Awake()
    {
        // Try to auto find the manager if it was not assigned in the Inspector
        if (dataManager == null)
        {
            dataManager = FindObjectOfType<DataSerialisationManager>();

            if (dataManager == null)
            {
                Debug.LogError("[SaveController] No DataSerialisationManager found in the scene.");
            }
        }
    }

    private void Update()
    {
        if (dataManager == null)
        {
            // Do nothing if we still do not have a reference
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            dataManager.Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dataManager.Load();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dataManager.DeleteSave();
        }
    }
}