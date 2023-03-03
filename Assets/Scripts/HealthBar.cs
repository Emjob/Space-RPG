using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Health cHealth;
    public Stats Health;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(cHealth.currentHealth / Health.maxHealth, 0, 1f);
    }
}
