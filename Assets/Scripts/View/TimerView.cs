using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(int seconds, int minutes)
    {
        StringBuilder stringBuilder = new StringBuilder(minutes.ToString());
        stringBuilder.Append(" : ");
        stringBuilder.Append(seconds.ToString());
        _timerText.text = stringBuilder.ToString();
    }
}
