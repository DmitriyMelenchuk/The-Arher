using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int _maxValue = 59;

    private int _deltaTime = 1;
    private int _seconds;
    private int _minutes;

    public int RunnigTime { private set; get; }

    public event Action<int, int> TimeChanged;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (enabled)
        {
            if (_seconds == _maxValue)
            {
                _minutes++;
                _seconds = -_deltaTime;
                TimeChanged?.Invoke(_seconds, _minutes);
            }

            RunnigTime += _deltaTime;
            _seconds += _deltaTime;
            TimeChanged?.Invoke(_seconds, _minutes);
            yield return new WaitForSeconds(_deltaTime);
        }
    }
}
