using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;


    public void FillImage(float amount)
    {
        healthBar.fillAmount = amount;
    }
}