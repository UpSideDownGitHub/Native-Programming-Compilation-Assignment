using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ColourShift : MonoBehaviour
{
    public Gradient colorGradient;
    public float gradientDuration = 10f;
    public float intensity;
    private float currentTime;

    public void Start()
    {
        
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > gradientDuration)
        {
            currentTime = 0f;
        }
        //GetComponent<MeshRenderer>().material.color = colorGradient.Evaluate(currentTime / gradientDuration);
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colorGradient.Evaluate(currentTime / gradientDuration) * intensity);
    }

    
}
