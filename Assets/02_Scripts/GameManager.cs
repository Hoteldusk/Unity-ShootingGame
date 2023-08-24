using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Text coinText;
    public GameObject asteroid;
    public float time = 0;
    public float Maxtime = 2;
    public List<GameObject> enemies;
    public static GameManager instance;
    public float coinIngame;
    public float maxRight;

    private void Awake()
    {
        instance = this;
    }

    public void PauseAction()
    { 
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        print("Pause Action");
    }

    public void ResumeAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        print("Resume Action");
    }

    public void MainMenuAction()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
        print("MainMenu Action");
    }

    void Start()
    {
        coinIngame = 0;
        //전체코인으로 수정해야함 coinText.text = coin.ToString();
        coinText.text = GameDataScript.instance.GetCoin().ToString();
        maxRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        print("maxRight : " + maxRight);
    }

    void Update()
    {
        //적 생성
        time += Time.deltaTime;
        if (time >= Maxtime)
        {
            int SpawnType = Random.Range(0, 2);
            
            if (SpawnType == 0)
            { 
                Instantiate(asteroid, new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
            }
            else
            {
                int EnemyType = Random.Range(0, 3);
                switch(EnemyType)
                {
                    case 0:
                        Instantiate(enemies[0], new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(enemies[1], new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(enemies[2], new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                        break;
                }    
            }
            time = 0;
        }
    }
}
