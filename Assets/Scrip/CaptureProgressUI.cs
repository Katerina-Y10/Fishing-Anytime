using UnityEngine;

public class CaptureProgressUI : MonoBehaviour
{
    //1.����Ҫ֪���������೤
    private float progressWidth = 0f;
    private float progressHeight = 0f;
    //��ɫ�Ľ��������
    private float greenProgressWidth = 0f;
    //��ɫ�������ƶ����յ�
    private float greenProgressEndX = 0f;
    //��ɫ���˶�����ʹ��bool�����ж�
    private bool isRight = true;
    private float greenSpeed = 100f;
    public Transform redProgress;
    public Transform greenProgress;
    private void OnEnable()
    {
    //���progressWidth = 0f,����Ҫ��ȡһ�������ȡ�
     if(progressWidth == 0f)
        {
            progressWidth = transform.GetComponent<RectTransform>().rect.width;
            progressHeight = transform.GetComponent<RectTransform>().rect.height;
            //��ȡ��ɫ�������Ŀ�ȣ�����ȷ����ɫ�������������ɫ�������ڻ�����λ�á�
            greenProgressWidth = greenProgress.GetComponent<RectTransform>().rect.width;
            //������ɫ���������˶��յ� ��ɫ���������� - ��ɫ����������
            greenProgressEndX = progressWidth - greenProgressWidth;
        }

        //����
        InitRedProgress(0.5f);
    }
    private void InitRedProgress(float redProgressPercent)
    {
        Vector2 vector2 = new Vector2(progressWidth * redProgressPercent, progressHeight);
        redProgress.GetComponent<RectTransform>().sizeDelta = vector2;
        //��ӿ����齨�󣬽����������size��С���ɫ�������ĳߴ��С��ƥ�䡣
        redProgress.GetComponent<BoxCollider2D>().size = vector2;//(50,10)
        //���Ŀ��������λ��ʹ��ƥ��ÿ�κ�ɫ�������ĳߴ�
        redProgress.GetComponent<BoxCollider2D>().offset = new Vector2(vector2.x / 2, 0);
        //���λ��
        float endX = progressWidth - vector2.x;
        float posX = Random.Range(0, endX);
        redProgress.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);
    }
    private void Update()
    {
     if (isRight == true)
        {
            greenProgress.GetComponent<RectTransform>().anchoredPosition += new Vector2(greenSpeed * Time.deltaTime, 0);
            if(greenProgress.GetComponent<RectTransform>().anchoredPosition.x > greenProgressEndX)
            {
                isRight = false;
            }
        }
        else
        {
            greenProgress.GetComponent<RectTransform>().anchoredPosition -= new Vector2(greenSpeed * Time.deltaTime, 0);
            if(greenProgress.GetComponent<RectTransform>().anchoredPosition.x < 0)
            {
                isRight = true;
            }
        }
    }


}
