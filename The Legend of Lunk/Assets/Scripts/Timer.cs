using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   
    private float goalTime = 0f;
    private float currentTime = 0f;
    private bool isCounting = false;
    
    void SetTimer(float time)
    {
        goalTime = time;
    }
    void StartTimer()
    {
        StartCoroutine("Counting");
    }
    void StopTimer()
    {
        isCounting = false;
    }
    IEnumerator Counting()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= goalTime)
        {
            StopTimer();
            StopCoroutine("Counting");
        }
        yield return null;
    }
    
    
}
