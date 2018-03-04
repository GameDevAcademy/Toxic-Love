using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Level Parameter")]
    public float levelDuration;
    public int flowers;

    [Header("Feedback")]
    public AudioClip collectSound;

    [Header("UI Elements")]
    public Text durationText;
    public Text flowersText;

    private AudioSource audioS;

    private void Start()
    {
        instance = this;
        audioS = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateDurationLeft();

    }

    private void UpdateDurationLeft()
    {
        //TODO: Play sounds at specific time stemps.
        int minutes = (int) levelDuration / 60;
        int seconds = (int) levelDuration % 60;

        durationText.text = minutes.ToString() + ":" + ((seconds < 10) ? ("0") : ("")) + seconds.ToString();

        levelDuration -= Time.deltaTime;
    }

    public void AddFlower()
    {
        //TODO: Play collecting sound.
        flowers++;

        flowersText.text = flowers.ToString();
    }

}
