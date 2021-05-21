using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clownHealth : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public clownDamage script;
    private void Start()
    {
        slider.maxValue = script.health;
        slider.value = script.health;

        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        slider.value = script.health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }





}

