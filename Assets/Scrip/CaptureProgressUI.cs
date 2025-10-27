using UnityEngine;

public class CaptureProgressUI : MonoBehaviour
{
    //1.我需要知道进度条多长
    private float progressWidth = 0f;
    private float progressHeight = 0f;
    //绿色的进度条宽度
    private float greenProgressWidth = 0f;
    //绿色进度条移动的终点
    private float greenProgressEndX = 0f;
    //绿色的运动方向使用bool进行判定
    private bool isRight = true;
    private float greenSpeed = 100f;
    public Transform redProgress;
    public Transform greenProgress;
    private void OnEnable()
    {
    //如果progressWidth = 0f,就需要获取一下整体宽度。
     if(progressWidth == 0f)
        {
            progressWidth = transform.GetComponent<RectTransform>().rect.width;
            progressHeight = transform.GetComponent<RectTransform>().rect.height;
            //获取绿色进度条的宽度，用于确定绿色进度条在整体灰色进度条内滑动的位置。
            greenProgressWidth = greenProgress.GetComponent<RectTransform>().rect.width;
            //计算绿色进度条的运动终点 灰色进度条长度 - 绿色进度条长度
            greenProgressEndX = progressWidth - greenProgressWidth;
        }

        //测试
        InitRedProgress(0.5f);
    }
    private void InitRedProgress(float redProgressPercent)
    {
        Vector2 vector2 = new Vector2(progressWidth * redProgressPercent, progressHeight);
        redProgress.GetComponent<RectTransform>().sizeDelta = vector2;
        //添加控制组建后，将控制组件的size大小与红色进度条的尺寸大小相匹配。
        redProgress.GetComponent<BoxCollider2D>().size = vector2;//(50,10)
        //更改控制组件的位置使其匹配每次红色进度条的尺寸
        redProgress.GetComponent<BoxCollider2D>().offset = new Vector2(vector2.x / 2, 0);
        //随机位置
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
