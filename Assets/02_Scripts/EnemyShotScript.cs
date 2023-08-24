using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    public float speed = 4.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
