using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileRule : DetectMobile
{   

    [SerializeField] bool destroyIfMobile = false;

    // Start is called before the first frame update
    void Start()
    {
        if(CheckMobile() == destroyIfMobile) {
            Destroy(gameObject);
        }
    }

}
