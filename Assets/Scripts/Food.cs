using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    [SerializeField] private EventTrigger.TriggerEvent foodTrigger;

    void Awake()
    {
        getCameraSize();
    }

    private void Start()
    {
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            RandomizePosition();

            foodTrigger.Invoke(new BaseEventData(EventSystem.current));
        }
    }

    private void RandomizePosition()
    {
        var currentX = Random.Range(minX, maxX);
        var currentY = Random.Range(minY, maxY);

        transform.position = new Vector3(currentX, currentY, 1);
    }

    private void getCameraSize()
    {
        var cam = Camera.main;
        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        minX = screenBottomLeft.x;
        maxX = screenTopRight.x;

        minY = screenBottomLeft.y;
        maxY = screenTopRight.y;
    }
}
