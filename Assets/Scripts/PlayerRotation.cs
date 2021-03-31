using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private bool isRotating;
    private Vector3 originRot, targetRot;
    private float timeToRotate = 0.2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && !isRotating)
            StartCoroutine(RotatePlayer(-1));

        if (Input.GetKey(KeyCode.E) && !isRotating)
            StartCoroutine(RotatePlayer(1));
    }

    private IEnumerator RotatePlayer(float direction)
    {
        isRotating = true;
        float elapsedTime = 0;

        transform.Rotate(90 * direction * Vector3.forward);

        while (elapsedTime < timeToRotate)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRotating = false;
    }
}