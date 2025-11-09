using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishingUi : MonoBehaviour
{
    public Button pullButton;
    public CaptureBar captureBar;

    //公开捕获时机进度条
    public GameObject captureProgressUI;
    //公开鱼钩进度条
    public GameObject fishHookProgressUI;
   
    public FishData[] fishData;
    private void Start()
    {
        pullButton.onClick.AddListener(OnPullButtonClick);
    }

    private void OnPullButtonClick()
    {
        //判断鱼是否上钩
        //如果捕获时机进度条开启

            if (captureBar.isEnter == true)
            {
                Debug.Log("抓住");
            
                captureProgressUI.SetActive(false);
                fishHookProgressUI.SetActive(true);
            }
            else
            {
                Debug.Log("跑了");
            }
        

    }
    //1:抓到鱼之后
    //a:第几个鱼钩抓到的这条鱼
    //一共6个物品，最好的鱼一条，普通的鱼3条，垃圾两个，
    //假如没有鱼钩，可以得到6个物品中的任意一个。
    //无鱼钩概率：得到最好的鱼概率是0.1；得到普通的鱼的概率0.3；得到垃圾的概率是0.6；
    //普通鱼钩概率：得到最好的鱼的概率为0，普通的鱼概率为1，垃圾概率为0，
    //高级鱼钩概率：得到最好的鱼概率为0.4，普通鱼概率0.6，垃圾概率为0，

    //无鱼钩noFishhook，普通鱼钩generalFishhook，好鱼钩goodFishhook

    //-----------------------------------------------------------------------------------------------------------------------------------------------------
    public Grade grade;
    public void FishingResults(string fishHookType)
    {
        float percent = Random.Range(0f, 1f);
     if(fishHookType == "noFishhook")
        {
            if (percent >= 0f && percent < 0.1f)
            {
                Debug.Log("抓到好鱼");
                grade.fishClass.sprite = fishData[0].fishClassSprite;
                grade.fishName.text = fishData[0].fishName;
                grade.glodText.text = fishData[0].fishPrice.ToString();
                fishData[0].fishObj.SetActive(true);
                grade.gameObject.SetActive(true);
            }
        else if(percent>=0.1f && percent < 0.4f)
            {
                
            int fishClass = Random.Range(1, 4);
            Debug.Log("抓到普通鱼"+ fishClass);
                grade.fishClass.sprite = fishData[fishClass].fishClassSprite;
                grade.fishName.text = fishData[fishClass].fishName;
                grade.glodText.text = fishData[fishClass].fishPrice.ToString();
                fishData[fishClass].fishObj.SetActive(true);
                grade.gameObject.SetActive(true);
            }
         else if(percent >= 0.4f)
            {
                int fishClass = Random.Range(4, 6);
                Debug.Log("垃圾" + fishClass);
                grade.fishClass.sprite = fishData[fishClass].fishClassSprite;
                grade.fishName.text = fishData[fishClass].fishName;
                grade.glodText.text = fishData[fishClass].fishPrice.ToString();
                fishData[fishClass].fishObj.SetActive(true);
                grade.gameObject.SetActive(true);
            }
        }
     else if(fishHookType == "generalFishhook")
        {
            int fishClass = Random.Range(1, 4);
            Debug.Log("普通鱼"+ fishClass);
            grade.fishClass.sprite = fishData[fishClass].fishClassSprite;
            grade.fishName.text = fishData[fishClass].fishName;
            grade.glodText.text = fishData[fishClass].fishPrice.ToString();
            fishData[fishClass].fishObj.SetActive(true);
            grade.gameObject.SetActive(true);
        }
     else if(fishHookType == "goodFishhook")
        {
         if(percent >= 0f && percent< 0.4f)
            {
                Debug.Log("好鱼");
                grade.fishClass.sprite = fishData[0].fishClassSprite;
                grade.fishName.text = fishData[0].fishName;
                grade.glodText.text = fishData[0].fishPrice.ToString();
                fishData[0].fishObj.SetActive(true);
                grade.gameObject.SetActive(true);

            }
         else if(percent >= 0.4f && percent < 1f)
            {
                int fishClass = Random.Range(1, 4);
                Debug.Log("普通鱼"+ fishClass);
                grade.fishClass.sprite = fishData[fishClass].fishClassSprite;
                grade.fishName.text = fishData[fishClass].fishName;
                grade.glodText.text = fishData[fishClass].fishPrice.ToString();
                fishData[fishClass].fishObj.SetActive(true);
                grade.gameObject.SetActive(true);
            }
        }
    }

}
