using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    private float delay = 0.5f;
    private int start = 0;
    private bool isCounting = false;
    private Coroutine countingCoroutine;

    private void OnMouseDown()
    {
        if (isCounting)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void StartCounting()
    {
        isCounting = true;
        countingCoroutine = StartCoroutine(Countdown(delay));
    }

    private void StopCounting()
    {
        isCounting = false;
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);
        while (isCounting)
        {
            start++;
            DisplayCountdown(start);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
