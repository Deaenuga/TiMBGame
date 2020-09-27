//using UnityEngine;
//using UnityEngine.UI;

//public class Game : MonoBehaviour
//{
//	#region SIngleton:Game


//	//public int Coins;

//	void Awake ()
//	{
//		//if (Instance == null)
//		//{
//		//	Instance = this;
//		//	DontDestroyOnLoad (gameObject);
//		//}
//		//else
//		//{
//		//	Destroy(gameObject);
//		//}


//		//DontDestroyOnLoad(gameObject);
//	}

//	public static Game Instance;
//	public Text[] allCoinsUIText;

//	#endregion




//	void Start ()
//	{

//		DontDestroyOnLoad(gameObject);

//		PlayerPrefs.SetInt("Coins", 5000);
//		//Coins = PlayerPrefs.GetInt("Coins");
//		UpdateAllCoinsUIText ();
//	}

//	public void UseCoins (int amount)
//	{
//		//Coins -= amount;
//		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-amount);
//		PlayerPrefs.Save();
		
//	}

//	public bool HasEnoughCoins (int amount)
//	{
//		return (PlayerPrefs.GetInt("Coins") >= amount);
//	}

//	public void UpdateAllCoinsUIText ()
//	{
//		for (int i = 0; i < allCoinsUIText.Length; i++) {
//			allCoinsUIText [i].text = PlayerPrefs.GetInt("Coins").ToString();
//		}
//	}

//}
