using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(140,13,0,255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 0, 255);
    bool hasPackage; 
    [SerializeField] float destroyDelay = 0.5f;   

    SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package is picked up!");
        }
        
        if (other.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package is delivered!");
        }
    }
}
