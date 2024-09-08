using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    bool isActive = false;
    float lastPressTime = 0f;

    [SerializeField] float force = 300f, doublePressTime = 0.1f;
    [SerializeField] float offset;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Start()
    {
        offset = UnityEngine.Random.Range(-100f, 100f);
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        //if(Input.GetKeyDown(KeyCode.Space) && !isActive) BallActivate();
        if(Keyboard.current.spaceKey.wasReleasedThisFrame && !isActive) DetectDoublePress();
#elif UNITY_ANDROID
        if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame && !isActive) DetectDoublePress();        
#endif
    }

    void BallActivate()
    {
        isActive = true;
        transform.SetParent(null);
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.AddForce(new Vector2(offset, force));
        
    }

    private void DetectDoublePress()
    {
        if (Time.time - lastPressTime <= doublePressTime) BallActivate();
        lastPressTime = Time.time;
    }
}
