using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Holds all the backgrounds and moves the according the main camera movement.
 */

public class Parralax : MonoBehaviour
{
    #region Parralax Paramters
    [Tooltip("All the backgrounds shown in the game.")]
    public Transform backgroundsParent;
    private float[] parralaxScales;

    [Tooltip("Smoothing of the parralax effect.")]
    public float smoothing = .5f;

    public float depth = 2f;

    #endregion

    #region Camera
    private Transform cam;
    private Vector3 lastCamPos;
    #endregion

    #region Setup
    private void Start()
    {
        // Sets Camera information
        cam = Camera.main.transform;

        lastCamPos = cam.position;

        if (backgroundsParent == null)
            backgroundsParent = transform;

        // Sets the backgrounds informations.
        parralaxScales = new float[backgroundsParent.childCount];

        for (int i = 0; i < backgroundsParent.childCount; i++)
        {
            parralaxScales[i] = depth * -1;
        }
    }
    #endregion

    #region Parralax Effect
    private void LateUpdate()
    {
        for (int i = 0; i < backgroundsParent.childCount; i++)
        {
            // Calculate parallax amount from camera movement.
            float parralax = (lastCamPos.x - cam.position.x) * parralaxScales[i];

            // Calculate the new X position of the current element.
            float backgroundTargetX = backgroundsParent.GetChild(i).position.x + parralax;

            // Calculate the new position vector of the current element.
            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetX, backgroundsParent.GetChild(i).position.y, backgroundsParent.GetChild(i).position.z);

            // Lerping the current element to the new position.
            backgroundsParent.GetChild(i).position = Vector3.Lerp(backgroundsParent.GetChild(i).position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

        lastCamPos = cam.position;
    }
    #endregion
}