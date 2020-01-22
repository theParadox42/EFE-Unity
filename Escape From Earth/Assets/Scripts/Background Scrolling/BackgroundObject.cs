using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{
    
    [SerializeField] float widthMultiplyer = 1f;
    SpriteRenderer myRenderer;

    void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public float GetWidth() {
        CheckRenderer();
        return myRenderer.bounds.size.x * widthMultiplyer;
    }

    public float GetHalfWidth() {
        CheckRenderer();
        return myRenderer.bounds.extents.x * widthMultiplyer;
    }

    void CheckRenderer() {
        if(myRenderer == null) {
            myRenderer = GetComponent<SpriteRenderer>();
        }
    }

}
