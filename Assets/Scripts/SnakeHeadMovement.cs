using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHeadMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;

    [SerializeField]
    private float rotationOffset = 2;

    [SerializeField]
    private Vector3 rotationPoint;

    [SerializeField]
    private TailRenderer tailRenderer;

    private float wrappingOffset = 0.2f;
    private float trailTimeBuffer;

    private void Awake()
    {
        rotationPoint = transform.TransformPoint(new Vector3(0, rotationOffset, 0));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CalculateRotationPoint();
        }
    }

    private void FixedUpdate()
    {
        transform.RotateAround(rotationPoint, Vector3.forward, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tail"))
        {
            Reset();
        }

        if(collision.CompareTag("Food"))
        {
            tailRenderer.ProlongTail();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Field"))
        {
            Wrap();
        }
    }

    private void CalculateRotationPoint()
    {
        transform.Rotate(180 * Vector3.right, Space.Self);
        rotationPoint = transform.TransformPoint(new Vector3(0, rotationOffset, 0));
        speed = -speed;
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        rotationPoint = transform.TransformPoint(new Vector3(0, rotationOffset, 0));
    }

    private void Wrap()
    {
        transform.position = Vector3.Scale(transform.position, new Vector3(1, -1, 1));
        rotationPoint = transform.TransformPoint(new Vector3(0, rotationOffset, 0));
        transform.position.Scale(new Vector3(wrappingOffset, wrappingOffset, 1));
    }
}
