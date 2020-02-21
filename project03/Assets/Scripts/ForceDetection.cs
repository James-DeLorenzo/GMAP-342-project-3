using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceDetection : MonoBehaviour
{
    #region Force Detection Vars
    private static float ForcePerClick = 10f;

    [SerializeField]
    private KeyCode Forcebutton = KeyCode.F;
    [SerializeField]
    private float TotalForce = 0;
    [SerializeField]
    [Range(0, 1)]
    private float ForceReductionPerUpdate = .5f;
    private Rigidbody2D rb;

    [SerializeField]
    private bool Player2 = false;
    #endregion
    #region Force Bar Vars
    public Image ImgForceBar;

    public float Max;
    public float Min;

    private float currentValue;

    private float currentPercentage;
    #endregion
    #region Global Functions
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentValue = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(Forcebutton))
        {
            TotalForce += ForcePerClick;
        }
        if (TotalForce > 0)
        {
            TotalForce -= ForceReductionPerUpdate;
            if (TotalForce < 0)
            {
                TotalForce = 0;
            }
        }
        SetForce(TotalForce);
    }
    #endregion
    #region Force Detection Functions
    public void AddForce()
    {
        rb.AddForce(new Vector2(TotalForce * (Player2 ? -1 : 1), 0), ForceMode2D.Impulse);
    }

    public float GetTotalForce()
    {
        return TotalForce;
    }
    #endregion
    #region Force Bar Functions
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
    #endregion
}
