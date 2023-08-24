using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataScript : MonoBehaviour
{
    public static GameDataScript instance;
    public float coin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public float GetCoin()
    {
        this.coin = PlayerPrefs.GetFloat("TotalCoin", 0);
        return this.coin;
    }
    public void AddCoin(float coin)
    {
        this.coin += coin;
        PlayerPrefs.SetFloat("TotalCoin", this.coin);
    }
}
