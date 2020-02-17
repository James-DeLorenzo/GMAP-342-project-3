using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
    public Image ImgForceBar;

    public int Max;
    public int Min;

    private int currentValue;

    private float currentPercentage;

    public void SetForce(int force)
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
                currentPercentage = (float)currentValue / (float)(Max - Min);
            }
        }
        ImgForceBar.fillAmount = currentPercentage;
    }

    public void AddForce(int addForce)
    {
        SetForce((currentValue + addForce));
    }

    private void Start()
    {
        currentValue = 0;
    }

}
