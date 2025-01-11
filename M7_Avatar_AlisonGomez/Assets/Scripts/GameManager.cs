using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText, OrbText;
    public static GameManager gameManager;
    public int Orbs = 0, Coins = 0;
    public List<Image> items;
    // Start is called before the first frame update
    
    public void ItemCollected(Sprite sprite, int id)
    {
        items[id].sprite = sprite;
    }

    private void Awake()
    {
        if(GameManager.gameManager != null && GameManager.gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        CoinText.text = "Coins: " + Coins;
        OrbText.text = "Orbs: " + Orbs;
    }

    public void OrbCollected()
    {
        Orbs++;
        OrbText.text = "Orbs:" + Orbs;
    }

    public void CoinCollected(int i)
    {
        Coins+= i;
        CoinText.text = "Coins:" + Coins;
    }
    
    public void GetItem(Sprite image, int v)
    {
        throw new NotImplementedException();
    }
}

