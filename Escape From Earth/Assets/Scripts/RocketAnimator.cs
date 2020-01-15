using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketAnimator : MonoBehaviour
{

    [SerializeField] Sprite[] rocketOnFrames = {};
    [SerializeField] Sprite[] rocketOffFrames = {};
    [SerializeField] float framesPerSecond = 10f;
    [SerializeField] bool rocketOn = true;
    Image myImage;

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprite[] spritesToUse = rocketOn ? rocketOnFrames : rocketOffFrames;
        int frameIndex = Mathf.RoundToInt(Time.time * framesPerSecond) % spritesToUse.Length;
        myImage.overrideSprite = spritesToUse[frameIndex];
    }
}
