using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Health player;
    public Stats Health;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.currentHealth / Health.maxHealth, 0, 1f);
    }
}