using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float TimeToDestroy = 2f;

    public int damageAmount = 1;
    public float speed = 50f;

    private void Awake()
    {
        Destroy(gameObject, TimeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}