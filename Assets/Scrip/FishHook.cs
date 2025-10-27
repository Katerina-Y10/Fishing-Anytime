using UnityEngine;

public class FishHook : MonoBehaviour
{
    //�ƶ�һ����λ��
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
            Debug.Log("ץ������");
        }
    }
}
