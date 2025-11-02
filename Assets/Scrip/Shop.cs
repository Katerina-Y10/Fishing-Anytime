using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button buy;
    public int money = 1000;
    public Text shopMoneyText;
    public Product product;
    public Button shopClose;

    private void OnEnable()
    {
        product = null;
    }
    private void Start()
    {
        buy.onClick.AddListener(OnClick);
        shopClose.onClick.AddListener(ShopCloseDown);
        shopMoneyText.text = money.ToString();
    }

    private void ShopCloseDown()
    {
        gameObject.SetActive(false);
    }

    //购买的时候需要知道购买的是那个Product;
    private void OnClick()
    {
        //如果选择的Product是空的，就return。
        //如果选择的Product有东西，获取这个东西的价格
        //把价格和拥有的钱比较，如果不够就return。如果够就执行Product里的Buy，并且减去钱数。
        if(product == null)
        {
            return;
        }
        int price = product.price;
        if(price > money)
        {
            return;
        }
        else
        {
            product.Buy();
            money = money - price;
            shopMoneyText.text = money.ToString();

        }
    }
}
