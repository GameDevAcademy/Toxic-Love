using UnityEngine;

/*
 * Responsible for creating an audioSource on the gameobject.
 */

public class SoundSource : MonoBehaviour
{
    [Header("Sound")]
    [Tooltip("Order in sound priority queue.")] [SerializeField]
    private int priority;
    protected AudioSource audioS;

    protected virtual void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>();

        //TODO: Take volume from player prefs.
        audioS.priority = priority;
    }

}
