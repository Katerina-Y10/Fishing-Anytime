using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//强制显示公开的内容 序列化
public class FishData
{
    public GameObject fishObj;
    public Sprite fishClassSprite;
    public int fishPrice;
    public string fishName;
}
