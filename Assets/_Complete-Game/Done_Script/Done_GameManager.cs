using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Done_GameManager : MonoBehaviour {

	//玩家
	public GameObject mPlayer;
	public Text goldCoin;
	public Text distance;


	void Start () 
	{

	}

	void Update () 
	{
		goldCoin.text="金币:" + mPlayer.GetComponent<Done_Player> ().mCoinCount;
		distance.text= "距离:" + mPlayer.GetComponent<Done_Player> ().mLength;
	}
}
