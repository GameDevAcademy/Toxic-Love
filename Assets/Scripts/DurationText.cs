using UnityEngine;
using UnityEngine.UI;

/*
 * Responsible for displaying the duration text on the UI.
 */
public class DurationText : SoundSource
{
    public FloatReference levelDuration;

    private Text durationText;

    protected override void Start()
    {
        base.Start();
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
