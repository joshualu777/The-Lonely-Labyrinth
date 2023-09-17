using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorCycleController : MonoBehaviour
{
    public float[] startColor = new float[3];
    public float transitionSpeed;

    Text component;
    float[] movement = { 0.01f, -0.01f, -0.01f };
    int currentIndex = 2;
    float time = 0.0f;
    float[] currentColor = new float[3];

    float diff = 0.0001f;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            currentColor[i] = startColor[i];
        }
        component = GetComponent<Text>();
        component.color = new Color(startColor[0], startColor[1], startColor[2]);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > transitionSpeed)
        {
            time = 0.0f;
            currentColor[currentIndex] += movement[currentIndex];
            component.color = new Color(currentColor[0], currentColor[1], currentColor[2]);

            if (Math.Abs(currentColor[currentIndex] - 0.0f) < diff || 
                Math.Abs(currentColor[currentIndex] - 1.0f) < diff)
            {
                movement[currentIndex++] *= -1;
                currentIndex %= 3;
            }
        }
    }
}
