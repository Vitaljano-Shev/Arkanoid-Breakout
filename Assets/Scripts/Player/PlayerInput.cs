using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> OnMove;

    Vector2 startPosition = Vector2.zero;
    float direction = 0f;
    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxis("Horizontal"));
#endif
#if UNITY_ANDROID
        TouchInput();
#endif

    }

    void TouchInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                //case TouchPhase.Began:
                //    break;
                case TouchPhase.Moved:
                    direction = touch.position.x > startPosition.x ? 1f : -1f;
                    break;
                //case TouchPhase.Stationary:
                //    break;
                //case TouchPhase.Ended:
                //    break;
                //case TouchPhase.Canceled:
                //break;
                default:
                    startPosition = touch.position;
                    direction = 0f;
                    break;
            }
            OnMove?.Invoke(direction);
        }
    }
}
