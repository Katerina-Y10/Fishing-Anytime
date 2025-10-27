using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PullSpace : MonoBehaviour
{
    //1:首先，点击开始后绿条随机一个位置。（这个位置需要有一个限制，最高是底条 -绿条自身，最低是0）
    //2：首先需要公开有一个底条，然后公开一个蓝条，绿条也要公开。私有的应该是绿条最高的位置。

    public RectTransform redRectTransform;
    public RectTransform blueRectTransform;
    public RectTransform greenRectTransform;
    private float greenHighest = 0;
    //蓝色条在不长按pull按钮时自动向下缩减，需要给蓝色条一个缩减的速度。
    public float blueDownSpeed = 50f;
    public float blueUpSpeed = 30f;
    public bool isPress = false;
    //绿色进度条的移动
    private float greenMoveRange = 50f;
    //添加一个bool，用来判断当前绿色进度条移动方向
    private bool isUp = true;
    //绿色进度条移动范围的最高点和最低点
    private float greenMoveRangeTop = 0;
    private float greenMoveRangeLow = 0;
    //绿色进度条移动速度
    public float greenMoveSpeed = 50f;
    public Text timeDown;
    private void OnEnable()
    {
        greenHighest = redRectTransform.rect.height - greenRectTransform.rect.height;
        //绿色的Y值应该在0到greenHighest之间任意取值
        float greenY = Random.Range(greenMoveRange, greenHighest-greenMoveRange);
        greenRectTransform.anchoredPosition = new Vector2(0, greenY);
        //给grennMoveRangeTop和Low赋值
        greenMoveRangeTop = greenMoveRange + greenY;
        greenMoveRangeLow = greenY - greenMoveRange;
        //以上为绿色进度条的随机位置。
        //蓝色进度条的高度在绿色进度条下面
        blueRectTransform.sizeDelta = new Vector2(blueRectTransform.rect.width, greenY);

        //每次打开都要重置移动方向
        isUp = true;
        StartCoroutine(EndTime());

    }
    private void Update()
    {
        //蓝色进度条的加减
     if(isPress == false)
        {
            blueRectTransform.sizeDelta -= new Vector2(0, blueDownSpeed * Time.deltaTime);
        }
        else
        {
            blueRectTransform.sizeDelta += new Vector2(0, blueUpSpeed * Time.deltaTime);
        }
       //绿色进度条的上下移动范围
       if (isUp == true)
        {
            greenRectTransform.anchoredPosition += new Vector2(0, greenMoveSpeed * Time.deltaTime);
            if(greenRectTransform.anchoredPosition.y >= greenMoveRangeTop)
            {
                isUp = false;
            }
        }
        else
        {
            greenRectTransform.anchoredPosition -= new Vector2(0, greenMoveSpeed * Time.deltaTime);
            if(greenRectTransform.anchoredPosition.y <= greenMoveRangeLow)
            {
                isUp = true;
            }
        }

    }
    private IEnumerator EndTime()
    {
        for (int i = 3; i >= 0; i--)
        {
            timeDown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("当前高度"+blueRectTransform.sizeDelta.y);
        Debug.Log("绿色底" + greenRectTransform.anchoredPosition.y);
        Debug.Log("绿色顶" + greenRectTransform.anchoredPosition.y + greenRectTransform.sizeDelta.y);
        if (blueRectTransform.sizeDelta.y >= greenRectTransform.anchoredPosition.y && blueRectTransform.sizeDelta.y <= greenRectTransform.anchoredPosition.y + greenRectTransform.sizeDelta.y)
        {
            timeDown.text = "grasp";
            Debug.Log("grasp");
        }
        else
        {
            Debug.Log("Run");
            timeDown.text = "Run";
        }
    }
}
