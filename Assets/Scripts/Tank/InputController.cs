using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public Vector2 InputVector { get; protected set; }

    protected abstract void Update();
}
