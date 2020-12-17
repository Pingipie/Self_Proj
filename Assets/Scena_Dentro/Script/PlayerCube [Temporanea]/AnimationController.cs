using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private MoveInput input;
    private Transform transform;

    private void Awake()
    {
        input = GetComponent<MoveInput>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var verticalDot = Vector3.Dot(transform.forward, input.MoveDirection);
        var horizontalDot = Vector3.Dot(transform.right, input.MoveDirection);
    }
}
