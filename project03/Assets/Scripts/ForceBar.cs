using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
    public Image ImgForceBar;

    public float Max;
    public float Min;

    private float currentValue;

    private float currentPercentage;

    public void SetForce(float force)
    {
        if (force != currentValue)
        {
            if (Max - Min == 0)
            {
                currentValue = 0;
                currentPercentage = 0;
            }
            else
            {
                currentValue = force;
                currentPercentage = currentValue / (Max - Min);
            }
        }
        ImgForceBar.fillAmount = currentPercentage;
    }

    public void AddForce(float addForce)
    {
        SetForce((currentValue + addForce));
    }

    private void Start()
    {
        currentValue = 0;
    }

}
