using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        mainCamera.transform.localScale = Vector3.one;
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        UpdateBounds();
    }

    private void UpdateBounds()
    {
        var ySize = mainCamera.orthographicSize * 2;
        boxCollider.size = new Vector2(ySize * mainCamera.aspect, ySize);
    }
}
