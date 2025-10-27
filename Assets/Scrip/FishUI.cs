using UnityEngine;

public class FishUI : MonoBehaviour
{
    private RectTransform rectTransform;
    public float speedFishUI = 300f;
    public float endY = 687f;
    //����100��270֮�����λ�ó���
    //����һ���ٶȣ����������ƶ���
    //������ܳ��������ĸ߶Ⱥ���UI��ʧ����ӡ�����ˡ�
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
            Debug.Log("���ܵ���");
        }
    }
}
