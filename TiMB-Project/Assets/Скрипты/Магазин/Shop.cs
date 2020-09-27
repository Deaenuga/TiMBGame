﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion
	
	[System.Serializable] public class ShopItem
	{
		public Sprite Image;
		public int    Price;
		public bool   IsPurchased = false;
	}

	public List<ShopItem> ShopItemsList;
	[SerializeField] Animator NoCoinsAnim;
 

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform  ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	Button buyBtn;

	void Start ()
	{

		Debug.Log(PlayerPrefs.GetInt("Coins").ToString());
		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (0).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
			g.transform.GetChild (1).GetChild (0).GetComponent <Text> ().text = ShopItemsList [i].Price.ToString ();
			buyBtn = g.transform.GetChild (2).GetComponent <Button> ();
			
			if (ShopItemsList [i].IsPurchased) {
				
				DisableBuyButton ();

			}
			buyBtn.AddEventListener (i, OnShopItemBtnClicked);
		}
	}

	void OnShopItemBtnClicked (int itemIndex)
	{
		if (Game.Instance.HasEnoughCoins (ShopItemsList [itemIndex].Price)) {
			Game.Instance.UseCoins (ShopItemsList [itemIndex].Price);
			//purchase Item
			ShopItemsList [itemIndex].IsPurchased = true; //если куплен то true

			//disable the button
			buyBtn = ShopScrollView.GetChild (itemIndex).GetChild (2).GetComponent <Button> ();
			DisableBuyButton ();

			//change UI text: coins
			Game.Instance.UpdateAllCoinsUIText ();



			//add avatar
			Profile.Instance.AddAvatar (ShopItemsList [itemIndex].Image);

		} else {
			NoCoinsAnim.SetTrigger ("NoCoins");
			Debug.Log ("Не хватает монет для покупки!!");
		}
	}

	void DisableBuyButton ()
	{
		buyBtn.interactable = false;
		buyBtn.transform.GetChild (0).GetComponent <Text> ().text = "КУПЛЕНО";
	}
	/*---------------------Open & Close shop--------------------------*/
	public void OpenShop ()
	{
		ShopPanel.SetActive (true);
	}

	public void CloseShop ()
	{
		ShopPanel.SetActive (false);
	}

	public void GoToMenu() //Метод отвечающий за переход со сцены Shop на сцену Menu
	{
		SceneManager.LoadScene("Menu");

	}

}
