using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Slider mSlider;
    PlayerController mPlayerRef;
    [SerializeField] Image mItemImage;

    private void Start()
    {
        mSlider = GetComponentInChildren<Slider>();
        mPlayerRef = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        mSlider.value = mPlayerRef.mHealth.GetHealth();

    }

    public void SetItemImage(Sprite sprite)
    {

    }

}
