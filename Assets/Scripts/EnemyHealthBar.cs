using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public EnemyHealth player;

    
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.currentHealth / player.maxHealth, 0, 1f);
    }
}
