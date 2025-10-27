using UnityEngine;

public class CaptureBar : MonoBehaviour
{
    public bool isEnter = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        isEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + "*");
        isEnter = false;
    }
}
