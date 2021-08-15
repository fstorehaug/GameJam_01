using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbow : MonoBehaviour
{
    MeshRenderer mesh;
    float hue;
    float sat = .9f;
    float val = .7f;
    float speed = 0.2f;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        hue = 0f;
    }
    private void Update()
    {
        hue += Time.deltaTime*speed;
        if (hue > 1)
        {
            hue = 0;
        }
        mesh.material.color = Color.HSVToRGB(hue, sat, val);
    }
}