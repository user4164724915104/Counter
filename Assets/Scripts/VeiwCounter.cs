using TMPro;
using UnityEngine;

public class VeiwCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += DisplayCountdown;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayCountdown;
    }

    private void DisplayCountdown()
    {
        int count = _counter.Count;
        _text.text = count.ToString("");
    }
}
