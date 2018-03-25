using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public FloatReference MaxHp;
    public FloatVariable currentHp;


    private Image healthImage;

    private void Update()
    {
        healthImage.fillAmount = playerHealth;
    }

}
