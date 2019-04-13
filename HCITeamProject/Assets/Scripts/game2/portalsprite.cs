using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalsprite : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(-Vector3.forward * 720f * Time.deltaTime);
    }
}
