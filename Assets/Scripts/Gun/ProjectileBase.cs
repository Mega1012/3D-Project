using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float TimeToDestroy = 20f;
    public int damageAmount = 1;
    public float speed = 50f;
    public List<string> tagsToHit;

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
        foreach (var t in tagsToHit)
        {
            if (collision.transform.CompareTag(t))
            {
                var damageable = collision.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(damageAmount);
                }

                if (collision.transform.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                }

                if (collision.transform.CompareTag("Player"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

