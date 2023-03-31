using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public TMP_Text healthText;
    public Health cHealth;
    public Stats Health;

    private void Update()
    {
        healthText.SetText(cHealth.currentHealth + "/" + Health.maxHealth);
    }
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(cHealth.currentHealth / Health.maxHealth, 0, 1f);
        
    }
}
