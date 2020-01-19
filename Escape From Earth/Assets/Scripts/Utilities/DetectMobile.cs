using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public bool CheckMobile()
{
        bool isMobile = false;
#if UNITY_IOS
        isMobile = true;
#elif UNITY_ANDROID
        isMobile = true;
# elif UNITY_EDITOR
        if (UnityEditor.EditorApplication.isRemoteConnected) {
                isMobile = true;
        }
#endif
        return isMobile;
}
