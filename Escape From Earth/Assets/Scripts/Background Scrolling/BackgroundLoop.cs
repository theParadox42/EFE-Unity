using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    [SerializeField] BackgroundObject[] backgroundObjects;
    Camera mainCamera;
    Vector2 screenBounds;
    [SerializeField] float choke;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (BackgroundObject obj in backgroundObjects) {
            LoadChildObject(obj);
        }
    }

    void LoadChildObject(BackgroundObject obj) {
        float objectWidth = obj.GetWidth();
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth) + 1;
        BackgroundObject clone = Instantiate(obj) as BackgroundObject;
        for(int i = 0; i < childsNeeded; i ++){
            BackgroundObject c = Instantiate(clone) as BackgroundObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i + obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone.gameObject);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void RepositionChildObjects(BackgroundObject obj) {
        BackgroundObject[] children = obj.GetComponentsInChildren<BackgroundObject>();
        if(children.Length > 1) {
            BackgroundObject firstChild = children[1];
            BackgroundObject lastChild = children[children.Length - 1];
            float halfObjectWidth = lastChild.GetHalfWidth();
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            } else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) { 
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate() {
        foreach (BackgroundObject obj in backgroundObjects)
        {
            RepositionChildObjects(obj);
        }
    }
}
