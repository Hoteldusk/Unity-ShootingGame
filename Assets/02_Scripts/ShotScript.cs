using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float speed = 10;
    public GameObject shotEffect;
    public GameObject Coin;
    public GameObject explosion;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OntriggerEnter2D "+collision.tag);
        if (collision.gameObject.tag == "Asteroid")
        {
            AsteroidScript asteroidScript = collision.gameObject.GetComponent<AsteroidScript>();
            asteroidScript.hp -= 3;
            Destroy(gameObject);
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            if (asteroidScript.hp <= 0)
            {
                Instantiate(explosion, collision.transform.position, Quaternion.identity);
                Vector3 RandomPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                GameObject AstCoinObj = Instantiate(Coin, transform.position + RandomPos, Quaternion.identity);
                CoinScript AstCoinSize = AstCoinObj.GetComponent<CoinScript>();
                AstCoinSize.coinSize = asteroidScript.coin;
                Destroy(collision.gameObject);
            }

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.hp -= 5;
            Instantiate(shotEffect, collision.transform.position, Quaternion.identity);
            if (enemyScript.hp <= 0)
            {
                Instantiate(explosion, collision.transform.position, Quaternion.identity);
                Vector3 RandomPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                GameObject EnemyCoinObj = Instantiate(Coin, transform.position + RandomPos, Quaternion.identity);
                CoinScript EnemyCoinSize = EnemyCoinObj.GetComponent<CoinScript>();
                EnemyCoinSize.coinSize = enemyScript.coin;
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
