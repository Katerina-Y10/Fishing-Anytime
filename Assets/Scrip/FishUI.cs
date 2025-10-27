using UnityEngine;

public class FishUI : MonoBehaviour
{
    private RectTransform rectTransform;
    public float speedFishUI = 300f;
    public float endY = 687f;
    //鱼在100到270之间随机位置出现
    //给鱼一个速度，让鱼向上移动。
    //如果鱼跑出进度条的高度后，鱼UI消失。打印鱼跑了。
    private void OnEnable()
    {
        float fishY = Random.Range(100, 270);
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        rectTransform.anchoredPosition = new Vector2(0, fishY);
    }
    private void Update()
    {
     if (rectTransform.anchoredPosition.y< endY)
        {
            rectTransform.anchoredPosition += new Vector2(0, speedFishUI * Time.deltaTime);
        }
        else
        {
            Debug.Log("鱼跑掉了");
        }
    }
}
