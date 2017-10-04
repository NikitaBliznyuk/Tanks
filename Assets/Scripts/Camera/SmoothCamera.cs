using System.Collections;
using System.Collections.Generic;
using Planet;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField]
    private Transform target;

    [Header("Settings")]
    [SerializeField]
    private float offset;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = (target.position - PlanetGravity.Instance.transform.position).normalized * offset;
        transform.position = desiredPosition;

        transform.rotation = Quaternion.LookRotation(-target.up);
    }
}
