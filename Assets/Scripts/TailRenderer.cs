using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailRenderer : MonoBehaviour
{
    private TrailRenderer tailTrail;
    private EdgeCollider2D tailCollider;

    private void Awake()
    {
        tailTrail = GetComponent<TrailRenderer>();

        CreateTailColliderGameObject();
    }

    private void FixedUpdate()
    {
        SetColliderPointsFromTrail(tailTrail, tailCollider);
    }

    private void CreateTailColliderGameObject()
    {
        var tailColliderGameObject = new GameObject("TailCollider", typeof(EdgeCollider2D))
        {
            tag = "Tail"
        };
        tailCollider = tailColliderGameObject.GetComponent<EdgeCollider2D>();
        tailCollider.isTrigger = true;
    }

    private void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        if (trail.positionCount == 0)
        {
            points.Add(transform.position);
            points.Add(transform.position);
        }
        else for (int position = 0; position < trail.positionCount; position++)
            {
                points.Add(trail.GetPosition(position));
            }

        collider.SetPoints(points);
    }

    public void ProlongTail()
    {
        tailTrail.time += 0.5f;
    }

}
