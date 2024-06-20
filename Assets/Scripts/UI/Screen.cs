using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public CanvasGroup CanvasGroup => _canvasGroup;

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    public abstract void Open();
    public abstract void Close();

    protected abstract void Enable();
    protected abstract void Disable();
}
