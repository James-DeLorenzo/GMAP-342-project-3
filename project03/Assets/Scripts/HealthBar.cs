using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image ImgEnergyBar;

    public int Max;
    public int Min;

    private int currentValue;

    private float currentPercentage;

    public void SetHealth(int damage)
    {
        if (damage != currentValue)
        {
            if (Max - Min == 0)
            {
                currentValue = 0;
                currentPercentage = 0;
            }
            else
            {
                currentValue = damage;
                currentPercentage = (float)currentValue / (float)(Max - Min);
            }
        }
        ImgEnergyBar.fillAmount = currentPercentage;
    }

    private void Start()
    {
        currentValue = 100;
    }

    //checks for hit and applies damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<ForceDetection>().GetTotalForce() < collision.gameObject.GetComponent<ForceDetection>().GetTotalForce())
            {
                SetHealth(currentValue - 25); //removes 1/4 of player's health
            }
        }
    }

    public float GetCurrentHealth()
    {
        return currentValue;
    }

}
