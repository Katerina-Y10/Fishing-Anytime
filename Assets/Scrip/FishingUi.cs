using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingUi : MonoBehaviour
{
    public Button pullButton;
    public CaptureBar captureBar;

    //��������ʱ��������
    public GameObject captureProgressUI;
    //�����㹳������
    public GameObject fishHookProgressUI;
    private void Start()
    {
        pullButton.onClick.AddListener(OnPullButtonClick);
    }

    private void OnPullButtonClick()
    {
        //�ж����Ƿ��Ϲ�
        //�������ʱ������������

            if (captureBar.isEnter == true)
            {
                Debug.Log("ץס");
                captureProgressUI.SetActive(false);
                fishHookProgressUI.SetActive(true);
            }
            else
            {
                Debug.Log("����");
            }
        

    }
}
