using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public string Name;
    public int price;
    public bool hasgoods;
    public bool repetition;
    public GameObject HookImage;
    public GameObject HookText;
    public GameObject PitchImage;
    public Shop shop;
    public Transform backpack;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        
    }
    private void OnEnable()
    {
        if(hasgoods == false)
        {
            HookImage.SetActive(false);
            HookText.SetActive(false);
        }
    }
    //1：确认是否有物品。2：点击后如果有物品打开选中框。关掉其他已经打开的选中框。
    private void OnClick()
    {
        for(int i = 0; i < 9; i++)
        {
            transform.parent.GetChild(i).GetComponent<Product>().TurnOff();
        }
     if(hasgoods == true)
        {
            PitchImage.SetActive(true);
            shop.product = this;
        }  
    }
    public void TurnOff()
    {
        PitchImage.SetActive(false);
    }

    public void Buy()
    {
        if(repetition == false)
        {
            HookImage.SetActive(false);
            HookText.SetActive(false);
        }
        for(int i =0; i<9; i++)
        {
            
            if(backpack.GetChild(i).GetComponent<Backpsack>().myName == Name)
            {
                backpack.GetChild(i).GetComponent<Backpsack>().number++;
            }
        }
    }
}
