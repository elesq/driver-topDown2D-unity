using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.25f;

    SpriteRenderer spriteRenderer;

    bool hasPackage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            // mark the package as collected and destroy the
            // gameObject so that can only be collected once

            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up");
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            // mark the package as collected and destroy the
            // customer gameObject meaning that delivery can
            // only occur once. 

            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package dropped off");
        }
    }
}
