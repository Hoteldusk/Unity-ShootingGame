using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject shot;
    public float speed = 5;
    Vector3 min, max;
    Vector2 colSize;
    Vector2 chrSize;
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        //min = new Vector3(-8, -4.5f, 0);
        print(min);

        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        //max = new Vector3(8, 4.5f, 0);
        print(max);
        colSize = GetComponent<BoxCollider2D>().size;
        chrSize = new Vector2(colSize.x / 2, colSize.y / 2);
    }

    void Update()
    {
        Move();
        PlayerShot();

    }

    public float shotMax = 0.25f;
    public float shotDelay = 0;
    void PlayerShot()
    {
        
        shotDelay += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (shotDelay > shotMax)
            {
                Vector3 vec = new Vector3(transform.position.x + 1.0f, transform.position.y - 0.22f, transform.position.z);
                Instantiate(shot, vec, Quaternion.identity);
                shotDelay = 0;
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position = transform.position + dir * Time.deltaTime * speed;

        float newX = transform.position.x;
        float newY = transform.position.y;

        /*
        if (newX < min.x + chrSize.x)
            newX = min.x + chrSize.x;
        if (newY < min.y + chrSize.y)
            newY = min.y + chrSize.y;
        if (newX > max.x - chrSize.x)
            newX = max.x - chrSize.x;
        if (newY > max.y - chrSize.y)
            newY = max.y - chrSize.y;
        */
        newX = Mathf.Clamp(newX, min.x + chrSize.x, max.x - chrSize.x);
        newY = Mathf.Clamp(newY, min.y + chrSize.y, max.y - chrSize.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OntriggerEnter2D " + collision.tag);
        if (collision.gameObject.tag == "Item")
        {
            CoinScript coinScript = collision.gameObject.GetComponent<CoinScript>();
            GameManager.instance.coinIngame += coinScript.coinSize;
            GameDataScript.instance.AddCoin(coinScript.coinSize);
            //datascript로 수정해야함
            //GameManager.instance.coinText.text = GameManager.instance.coin.ToString();
            GameManager.instance.coinText.text = GameDataScript.instance.GetCoin().ToString();
            print("Get Coin! : " + coinScript.coinSize + " Total Coin in Game : " + GameManager.instance.coinIngame);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Asteroid" ||
                 collision.gameObject.tag == "EnemyShot" || 
                 collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
