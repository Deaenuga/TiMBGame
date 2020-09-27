using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	#region SIngleton:Game

	public static Game Instance;
	public Text[] allCoinsUIText;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			//DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}


	}

	#endregion

	[SerializeField] Text[] allCoinsUIText;

	int Coins;
	
	

	void Start ()
	{
		//PlayerPrefs.SetInt("Coins", 5000);
		Coins = PlayerPrefs.GetInt("Coins");
		UpdateAllCoinsUIText ();
	}

	public void UseCoins (int amount)
	{
		Coins -= amount;
		PlayerPrefs.SetInt("Coins", Coins);
		PlayerPrefs.Save();
		
	}

	public bool HasEnoughCoins (int amount)
	{
		return (Coins >= amount);
	}

	public void UpdateAllCoinsUIText ()
	{
		for (int i = 0; i < allCoinsUIText.Length; i++) {
			allCoinsUIText [i].text = Coins.ToString ();
		}
	}

}
