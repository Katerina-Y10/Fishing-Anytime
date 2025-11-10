using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    public Button cast;
    //点击cast按钮后，需要先关掉自己，再打开横条。
    public GameObject hProgress;
    private void Start()
    {
        cast.onClick.AddListener(OnCastButtonDown);
    }

    private void OnCastButtonDown()
    {
        gameObject.SetActive(false);
        hProgress.SetActive(true);
    }
}
