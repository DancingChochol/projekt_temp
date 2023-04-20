using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int obecny=0;

    [SerializeField] private float predkosc = 2f;

    void Update()
    {
        if (Vector2.Distance(waypoints[obecny].transform.position, transform.position) < .1f) 
        {
            obecny++;
            if (obecny >= waypoints.Length)  
            {
                obecny = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[obecny].transform.position, Time.deltaTime * predkosc);
    }
}
