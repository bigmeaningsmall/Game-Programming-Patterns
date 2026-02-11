using UnityEngine;

public class MyPoolTester : MonoBehaviour
{
    public MyObjectPool pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.GetObject();

            if (obj != null)
            {
                obj.transform.position = new Vector3(
                    Random.Range(-5f, 5f),
                    1f,
                    Random.Range(-5f, 5f)
                );

                // Tell the object which pool it belongs to
                obj.GetComponent<MyPooledObject>().SetPool(pool);

                obj.SetActive(true);
            }
            else
            {
                Debug.Log("Pool empty");
            }
        }
    }
}