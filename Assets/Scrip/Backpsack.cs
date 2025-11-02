using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpsack : MonoBehaviour
{
    public string myName;
    public int number;
    public GameObject goods;
    public GameObject backPackItems;
    public GameObject numberText;
    public GameObject selectBox;
    public bool isHook = true;
    public Pack pack;
    //当玩家点击后，需要知道点击的物品是鱼钩还是鱼饵。
    //打开选中框
    //把其他相同种类的物品关掉
    //需要告诉背包，谁被选中了

    private void OnEnable()
    {
        //当打开背包时，如果物品的数量不等于0，就把物品打开。
        //否则就关掉。
        if(number > 0)
        {
            goods.SetActive(true);
            backPackItems.SetActive(true);
            numberText.SetActive(true);
            numberText.GetComponent<Text>().text = number.ToString();
        }
        else
        {
            goods.SetActive(false);
            backPackItems.SetActive(false);
            numberText.SetActive(false);
        }
    }
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if(number == 0)
        {
            return;
        }
        if(isHook == true)
        {
           
            for(int i = 0; i<9; i++)
            {
               if(transform.parent.GetChild(i).GetComponent<Backpsack>().isHook == true)
                {
                    transform.parent.GetChild(i).GetComponent<Backpsack>().CloseSelectBox();
                }
            }
            selectBox.SetActive(true);
            pack.hook = this;
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (transform.parent.GetChild(i).GetComponent<Backpsack>().isHook == false)
                {
                    transform.parent.GetChild(i).GetComponent<Backpsack>().CloseSelectBox();
                }
            }
            selectBox.SetActive(true);
            pack.bait = this;
        }
      
      
    }
    public void CloseSelectBox()
    {
        selectBox.SetActive(false);
    }
}
