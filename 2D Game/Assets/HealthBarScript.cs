using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;

    public void SetHealth(float h)
    {
        slider.value = h;
    }

    public void SetMaxHealth(float h)
    {
        slider.maxValue = h;
        slider.value = h;
    }
}
