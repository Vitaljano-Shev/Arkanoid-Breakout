using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float offsetY = 0.5f;
    Transform parentPosition;
    void Start()
    {
        CreateBall();
    }

    void CreateBall()
    {
        Instantiate(ball, new Vector3(transform.position.x,transform.position.y + offsetY), Quaternion.identity,transform);
    }
}
