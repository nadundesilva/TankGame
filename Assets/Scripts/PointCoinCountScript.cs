﻿using UnityEngine;
using System.Collections;
using Assets.Game;
using UnityEngine.UI;

public class PointCoinCountScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        int playerNumber = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1));

        GameObject player = GameObject.Find(gameObject.name + "/PlayerNumber");
        int playerNumberValue = GameManager.Instance.GameEngine.Tanks[playerNumber - 1].PlayerNumber;
        player.GetComponent<Text>().text = "0" + playerNumberValue.ToString();

        GameObject point = GameObject.Find(gameObject.name + "/Point");
        int pointsValue = GameManager.Instance.GameEngine.Tanks[playerNumber - 1].Points;
        point.GetComponent<Text>().text = pointsValue.ToString();

        GameObject coin = GameObject.Find(gameObject.name + "/Coin");
        int coinsValue = GameManager.Instance.GameEngine.Tanks[playerNumber - 1].Coins;
        coin.GetComponent<Text>().text = coinsValue.ToString();
    }
}
