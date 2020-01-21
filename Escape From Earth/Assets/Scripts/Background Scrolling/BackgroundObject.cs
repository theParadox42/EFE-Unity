using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{
    
    [SerializeField] float widthMultiplyer = 1f;
    SpriteRenderer myRenderer;

    private void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public float GetWidth() {
        return myRenderer.bounds.size.x * widthMultiplyer;
    }

    public float GetHalfWidth() {
        return myRenderer.bounds.extents.x * widthMultiplyer;
    }

}
