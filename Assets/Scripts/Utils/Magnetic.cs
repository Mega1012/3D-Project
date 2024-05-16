using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float dist = .2f;
    public float coinSpeed = 3f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) > dist)
        {
            coinSpeed++;
            transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position, Time.deltaTime * coinSpeed);
        }    
    }
}
