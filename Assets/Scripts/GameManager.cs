using UnityEngine;

/*
 * Responsible for handling and holding all the rules of the level.
 */

public class GameManager : SoundSource
{
    public FloatReference levelDuration;

    private void Update()
    {
        // Updates the level Duration.
        levelDuration.CurrentValue -= Time.deltaTime;
    }
}
