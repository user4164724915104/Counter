using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private Coroutine _countingCoroutine;
    public event UnityAction CountChanged;
    public int Count { get { return _count; } }

    private void OnMouseDown()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
        else
        {
            _countingCoroutine = StartCoroutine(Countdown(_delay));
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _count++;
            CountChanged?.Invoke();
            yield return wait;
        }
    }
}
