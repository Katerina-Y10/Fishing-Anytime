using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARManagenment : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject fishHole;
    public Button castAgain;
    public ARSession session;

    private void Start()
    {
        planeManager.planesChanged += OnPlaneChange;
        castAgain.onClick.AddListener(ResetAR);
    }
    public void OnPlaneChange(ARPlanesChangedEventArgs args)
    {
        
        if(args.added != null && args.added.Count> 0)
        {
            planeManager.enabled = false;
            Vector3 average = Vector3.zero;
            int count = 0;
            foreach (var plane in planeManager.trackables)
            {
                count++;
                average += plane.center;
            }
            average /= count;
            fishHole.transform.position = average;
            fishHole.SetActive(true);
            Debug.Log(fishHole.transform.position);
        }    
    }
    public void ResetAR()
    {
        session.Reset();
        planeManager.enabled = true;
        fishHole.SetActive(false);
    }
}
