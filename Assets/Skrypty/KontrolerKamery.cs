using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerKamery : MonoBehaviour
{
    [SerializeField] private Transform gracz;

    private void Update()
    {
        transform.position = new Vector3(gracz.position.x, gracz.position.y, transform.position.z);
    }
}
