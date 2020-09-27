using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	#region SIngleton:Game

	public static Game Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	#endregion

	public Text[] allCoinsUIText;

	//int Coins;
	
	

	void Start ()
	{
		//PlayerPrefs.SetInt("Coins", 5000);
		//Coins = PlayerPrefs.GetInt("Coins");
		//UpdateAllCoinsUIText ();

		for (int i = 0; i < allCoinsUIText.Length; i++)
		{
			allCoinsUIText[i].text = PlayerPrefs.GetInt("Coins").ToString();
		}
	}

	public void UseCoins (int amount)
	{
		PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins") - amount);
		//PlayerPrefs.SetInt("Coins", Coins);
		PlayerPrefs.Save();
		
	}

	public bool HasEnoughCoins (int amount) //Было достаточно монет
	{
		return (PlayerPrefs.GetInt("Coins") >= amount);
	}

	public void UpdateAllCoinsUIText ()
	{
		for (int i = 0; i < allCoinsUIText.Length; i++) {
			allCoinsUIText [i].text = PlayerPrefs.GetInt("Coins").ToString ();
		}
	}

}
