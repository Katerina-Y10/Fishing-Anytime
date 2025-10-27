using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingUi : MonoBehaviour
{
    public Button pullButton;
    public CaptureBar captureBar;

    //公开捕获时机进度条
    public GameObject captureProgressUI;
    //公开鱼钩进度条
    public GameObject fishHookProgressUI;
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
}
