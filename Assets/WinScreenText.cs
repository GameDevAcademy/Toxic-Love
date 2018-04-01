using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenText : MonoBehaviour
{
    public FloatReference flowersCollected;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "I will forgive you because you've collected:" + flowersCollected.CurrentValue + " roses for me. But I am still mad !";
    }

}
