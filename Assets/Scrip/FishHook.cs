using UnityEngine;

public class FishHook : MonoBehaviour
{
    //移动一定的位置
    private float speedFishHook = 50f;
    private RectTransform rectTransform;
    public RectTransform fishRectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void FishHookMove()
    {
        rectTransform.anchoredPosition += new Vector2(0, speedFishHook);
    }
    private void Update()
    {
        if(rectTransform.anchoredPosition.y >= fishRectTransform.anchoredPosition.y)
        {
            Debug.Log("抓到鱼了");
        }
    }
}
