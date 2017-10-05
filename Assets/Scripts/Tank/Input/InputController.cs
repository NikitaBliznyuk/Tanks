using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public Vector2 InputVector { get; protected set; }

    protected abstract void Update();

    public abstract bool GetFireKeyDown();
    public abstract bool GetFireKeyUp();
    public abstract bool GetFireKey();
}
