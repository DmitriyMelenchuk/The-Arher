using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    protected abstract void Enable();
    protected abstract void Disable();

    public abstract void Open();
    public abstract void Close();
}
