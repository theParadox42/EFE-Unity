using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileRule: MonoBehaviour
{   

    [SerializeField] bool destroyIfMobile = false;

    DetectMobile detector = new DetectMobile();

    // Start is called before the first frame update
    void Start()
    {
        if(detector.CheckMobile() == destroyIfMobile) {
            Destroy(gameObject);
        }
    }

}
