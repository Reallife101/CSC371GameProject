using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    public void SetMaxCooldown(float cooldown)
    {
        slider.maxValue = cooldown;
        slider.value = cooldown;
    }

    public void SetCooldown(float cooldown)
    {
        slider.value = cooldown;
    }

    public float GetCooldown()
    {
        return slider.value;
    }
}
