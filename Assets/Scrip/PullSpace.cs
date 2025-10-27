using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PullSpace : MonoBehaviour
{
    //1:���ȣ������ʼ���������һ��λ�á������λ����Ҫ��һ�����ƣ�����ǵ��� -�������������0��
    //2��������Ҫ������һ��������Ȼ�󹫿�һ������������ҲҪ������˽�е�Ӧ����������ߵ�λ�á�

    public RectTransform redRectTransform;
    public RectTransform blueRectTransform;
    public RectTransform greenRectTransform;
    private float greenHighest = 0;
    //��ɫ���ڲ�����pull��ťʱ�Զ�������������Ҫ����ɫ��һ���������ٶȡ�
    public float blueDownSpeed = 50f;
    public float blueUpSpeed = 30f;
    public bool isPress = false;
    //��ɫ���������ƶ�
    private float greenMoveRange = 50f;
    //���һ��bool�������жϵ�ǰ��ɫ�������ƶ�����
    private bool isUp = true;
    //��ɫ�������ƶ���Χ����ߵ����͵�
    private float greenMoveRangeTop = 0;
    private float greenMoveRangeLow = 0;
    //��ɫ�������ƶ��ٶ�
    public float greenMoveSpeed = 50f;
    public Text timeDown;
    private void OnEnable()
    {
        greenHighest = redRectTransform.rect.height - greenRectTransform.rect.height;
        //��ɫ��YֵӦ����0��greenHighest֮������ȡֵ
        float greenY = Random.Range(greenMoveRange, greenHighest-greenMoveRange);
        greenRectTransform.anchoredPosition = new Vector2(0, greenY);
        //��grennMoveRangeTop��Low��ֵ
        greenMoveRangeTop = greenMoveRange + greenY;
        greenMoveRangeLow = greenY - greenMoveRange;
        //����Ϊ��ɫ�����������λ�á�
        //��ɫ�������ĸ߶�����ɫ����������
        blueRectTransform.sizeDelta = new Vector2(blueRectTransform.rect.width, greenY);

        //ÿ�δ򿪶�Ҫ�����ƶ�����
        isUp = true;
        StartCoroutine(EndTime());

    }
    private void Update()
    {
        //��ɫ�������ļӼ�
     if(isPress == false)
        {
            blueRectTransform.sizeDelta -= new Vector2(0, blueDownSpeed * Time.deltaTime);
        }
        else
        {
            blueRectTransform.sizeDelta += new Vector2(0, blueUpSpeed * Time.deltaTime);
        }
       //��ɫ�������������ƶ���Χ
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
        Debug.Log("��ǰ�߶�"+blueRectTransform.sizeDelta.y);
        Debug.Log("��ɫ��" + greenRectTransform.anchoredPosition.y);
        Debug.Log("��ɫ��" + greenRectTransform.anchoredPosition.y + greenRectTransform.sizeDelta.y);
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
