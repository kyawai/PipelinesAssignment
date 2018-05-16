using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }
    void Update()
    {
        float speed = 1.0f;
        float distance = 5.0f;
        var x = Mathf.Sin(Time.time * speed) * distance;
        transform.position = originalPos + new Vector3(x, 0.0f, 0.0f);
    }
}