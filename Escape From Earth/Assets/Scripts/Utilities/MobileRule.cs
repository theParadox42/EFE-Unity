using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the state of the children
public class MobileRule: MonoBehaviour
{   

    [SerializeField] bool destroyIfMobile = false;

    DetectMobile detector = new DetectMobile();
    bool currentlyActive = true;

    void Update()
    {
        UpdateActiveness();
    }

    // Update whether object is "active"
    void UpdateActiveness() {
        bool isMobile = detector.CheckMobile();
        bool shouldChangeActiveness = (destroyIfMobile && isMobile == currentlyActive) || (!destroyIfMobile && isMobile != currentlyActive);
        if(shouldChangeActiveness) {
            currentlyActive = !currentlyActive;

            foreach (Transform child in transform) {
                child.gameObject.SetActive(currentlyActive);
            }
        }
    }

}
