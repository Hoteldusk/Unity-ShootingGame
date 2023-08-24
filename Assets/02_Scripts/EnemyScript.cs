using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 1;
    public float speed = 1;
    public int EnemyType;
    public float coin = 0;
    public float shotDelay = 0;
    float shotDelayMax = 1;
    public float shotspeed = 0;
    public GameObject EnemyShot;

    void Start()
    {
        switch (EnemyType)
        {
            case 0:
                hp = 10;
                speed = 1.5f;
                coin = 2;
                shotDelayMax = 1.5f;
                shotspeed = 3;
                break;
            case 1:
                hp = 20;
                speed = 1.4f;
                coin = 3;
                shotDelayMax = 2.5f;
                shotspeed = 4;
                break;
            case 2:
                hp = 50;
                speed = 2f;
                coin = 10;
                shotDelayMax = 3.5f;
                shotspeed = 5;
                break;
        }
    }

    void Update()
    {
        shotDelay += Time.deltaTime;
        transform.position += Vector3.left * Time.deltaTime * speed;
        Vector3 vec = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
        if (shotDelay > shotDelayMax)
        {
            GameObject EnemyShotObj = Instantiate(EnemyShot, vec, Quaternion.identity);
            EnemyShotScript enemyshotscript = EnemyShotObj.transform.GetComponent<EnemyShotScript>();
            enemyshotscript.speed = shotspeed;
            shotDelay = 0;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
