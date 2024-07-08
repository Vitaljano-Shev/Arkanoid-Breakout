using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] const float sizeX = 1920.0f;
    [SerializeField] const float sizeY = 1080.0f;

    float defaultSizeX, defaultSizeY;
    const float halfSize = 200.0f;
    [SerializeField] bool isHorizontal;

    private void Awake()
    {
        defaultSizeX = isHorizontal ? sizeX : sizeY;
        defaultSizeY = isHorizontal ? sizeY : sizeX;
    }

    void ResizeCamera()
    {
        float currentScreenRatio = (float)Screen.width / (float)Screen.height;
        float defaultScreenRatio = defaultSizeX / defaultSizeY;

        if(currentScreenRatio >= defaultScreenRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = defaultScreenRatio / currentScreenRatio;
            Resize(differentSize);
        }

        void Resize(float differentSize = 1.0f)
        {
            Camera.main.orthographicSize = defaultSizeY / halfSize * differentSize;
        }
    }
}
