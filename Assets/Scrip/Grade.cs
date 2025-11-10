
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grade : MonoBehaviour
{
    public Image fishClass;
    public Text glodText;
    public Text fishName;
    public Shop shop;
    //1.获取鱼的钱是多少 2. 钱直接加进商店里 3. 关掉当前界面 
    //4.1 横着的进度条需要重置
    //4.2 竖着的进度条需要重置
    //4.3 。。。
    public Button sellButton;
    public Button saveButton;
    public GameObject hProgress;
    public GameObject[] fish;

    private void Start()
    {
        sellButton.onClick.AddListener(OnSellButtonDown);
    }

    private void OnSellButtonDown()
    {
        //int.Parse(glodText.text);
        shop.money += int.Parse(glodText.text);
        gameObject.SetActive(false);
        hProgress.SetActive(true);
        for(int i = 0; i < fish.Length; i++)
        {
            fish[i].gameObject.SetActive(false);
        }
    }
}
