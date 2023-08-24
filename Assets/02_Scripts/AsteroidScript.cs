using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 6;
    public float rotSpeed = 40;
    public float hp = 6;
    public float coin = 1;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
