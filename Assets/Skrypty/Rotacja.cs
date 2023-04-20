using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacja : MonoBehaviour
{

    [SerializeField] private float predkosc = 2f;

    private void Update()
    {
        transform.Rotate(0f, 0f, 360 * predkosc * Time.deltaTime);
    }
}
