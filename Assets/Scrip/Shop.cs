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

    private void OnEnable()
    {
        product = null;
    }
    private void Start()
    {
        buy.onClick.AddListener(OnClick);
        shopMoneyText.text = money.ToString();
    }
    //�����ʱ����Ҫ֪����������Ǹ�Product;
    private void OnClick()
    {
        //���ѡ���Product�ǿյģ���return��
        //���ѡ���Product�ж�������ȡ��������ļ۸�
        //�Ѽ۸��ӵ�е�Ǯ�Ƚϣ����������return���������ִ��Product���Buy�����Ҽ�ȥǮ����
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
