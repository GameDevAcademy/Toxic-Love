using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationText : MonoBehaviour
{
    public FloatReference levelDuration;

    private Text durationText;

    private void Start()
    {
        durationText = GetComponent<Text>();
    }

    private void Update()
    {
        //TODO: Play sounds at specific time stemps.
        int minutes = (int)levelDuration / 60;
        int seconds = (int)levelDuration % 60;

        durationText.text = minutes.ToString() + ":" + ((seconds < 10) ? ("0") : ("")) + seconds.ToString();
    }
}
