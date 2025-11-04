using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pack : MonoBehaviour
{
    public Text moneyText;
    public Shop shop;
    public Button backButton;
    public Button packSelect;
   //----------------------------------------------------------------------------------------------------------------------------
    public Backpsack hook;
    public Backpsack bait;
    private void OnEnable()
    {
        moneyText.text = shop.money.ToString();
    }

    private void Start()
    {
        backButton.onClick.AddListener(BackButtonDown);
    }

    private void BackButtonDown()
    {
        gameObject.SetActive(false);
    }
}
