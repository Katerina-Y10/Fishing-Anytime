using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject fishingAnytime;
    public Button gameStart;
    public GameObject scan;
    
    public void GameButton()
    {
        fishingAnytime.SetActive(false);
        scan.SetActive(true);
        
    }
    private void Start()
    {
        gameStart.onClick.AddListener(GameButton);
    }
}
