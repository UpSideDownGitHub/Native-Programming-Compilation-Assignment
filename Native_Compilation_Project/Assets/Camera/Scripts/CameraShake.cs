using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraShake : MonoBehaviour
{
    public Camera cam;
    public bool alreadyShaking;
    public Vector3 initPosition;
    public float timeToWait;

    public void Start()
    {
        cam = Camera.main;
    }

    public void cameraShake(float length, float hardness)
    {
        if (!alreadyShaking)
        {
            StartCoroutine(_ShakingCamera(length, hardness));
        }
    }

    private IEnumerator _ShakingCamera(float length, float hardness)
    {
        alreadyShaking = true;
        initPosition = cam.transform.position;

        float time = 0f;
        while (time < length)
        {
            cam.transform.localPosition = initPosition + (Vector3)Random.insideUnitCircle * hardness;
            time += timeToWait;
            yield return new WaitForSeconds(timeToWait);
        }

        cam.transform.position = initPosition;
        alreadyShaking = false;
    }
}
