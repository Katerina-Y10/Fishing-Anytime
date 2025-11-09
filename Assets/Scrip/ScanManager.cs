using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanManager : MonoBehaviour
{
    public ARManagenment aRManagenment;
    public Button scanButton;
    public Button scratch;
    public GameObject hole;
    public GameObject fishingUI;
    public GameObject fishRod;
    private void Start()
    {
        scanButton.onClick.AddListener(OnScanButtonDown);
        scratch.onClick.AddListener(OnScratchButtonDown);
    }
    private void OnScanButtonDown()
    {
        aRManagenment.ResetAR();
        scanButton.gameObject.SetActive(false);
        hole.GetComponent<Animator>().SetBool("play", false);
        hole.GetComponent<Animator>().SetBool("stop", true);
        scratch.transform.parent.gameObject.SetActive(true);

    }
 
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //点击scaratch播放洞穴模型的动画
    //洞穴的物体上
private void OnScratchButtonDown()
    {
        hole.GetComponent<Animator>().SetBool("play", true);
        hole.GetComponent<Animator>().SetBool("stop", false);
        scratch.transform.parent.gameObject.SetActive(false);
        StartCoroutine(AnimationEnd());
    }
    
    private IEnumerator AnimationEnd()
    {
        yield return new WaitForSeconds(10);
        fishingUI.SetActive(true);
        fishRod.SetActive(true);
        gameObject.SetActive(false);
    }
}
