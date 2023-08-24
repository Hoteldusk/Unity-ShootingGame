using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed = 2.0f;
    public float coinSize = 1;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
