using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public int price;
    public bool hasgoods;
    public bool repetition;
    public GameObject HookImage;
    public GameObject HookText;
    public GameObject PitchImage;
    public Shop shop;
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
    //1��ȷ���Ƿ�����Ʒ��2��������������Ʒ��ѡ�п򡣹ص������Ѿ��򿪵�ѡ�п�
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
    }
}
