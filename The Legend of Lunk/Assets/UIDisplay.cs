using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Slider mSlider;
    PlayerController playerRef;

    private void Start()
    {
        mSlider = GetComponentInChildren<Slider>();
        playerRef = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        mSlider.value = playerRef.mHealth.GetHealth();
    }

}
