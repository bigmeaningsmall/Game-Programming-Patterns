using UnityEngine;

public class MyPooledObject : MonoBehaviour
{
    public float lifetime = 2f; // number of seconds before recycling

    private float timer;
    private MyObjectPool pool;

    private void OnEnable()
    {
        timer = lifetime;
    }

    public void SetPool(MyObjectPool p)
    {
        pool = p;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (pool != null)
            {
                pool.ReturnObject(gameObject);
            }
            else
            {
                // fallback safety
                gameObject.SetActive(false);
            }
        }
    }
}