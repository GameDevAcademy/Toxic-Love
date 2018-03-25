using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatReference levelDuration;
    private AudioSource audioS;

    private void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        levelDuration.CurrentValue -= Time.deltaTime;
    }
}
