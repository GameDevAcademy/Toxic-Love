using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowersCounter : SoundSource
{
    public FloatReference flowersCount;

    private Text flowersText;

    protected override void Start()
    {
        base.Start();

        flowersText = GetComponent<Text>();
    }

    private void Update()
    {
        //TODO: Play sounds after collecting.

        flowersText.text = flowersCount.CurrentValue.ToString();
    }
}
