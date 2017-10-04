using Planet;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField]
    private Transform target;

    [Header("Settings")]
    [SerializeField]
    private float offset = 23.0f;

    [SerializeField]
    private float lerpSpeed = 10.0f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = (target.position - PlanetGravity.Instance.transform.position).normalized * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * lerpSpeed);

        Quaternion desiredRotation = target.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.fixedDeltaTime * lerpSpeed);
    }
}
