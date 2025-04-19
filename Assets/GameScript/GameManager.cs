using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;

    private void Start()
    {
        SwipeDetection.OnSwipeTriggered += DeleteStartText;
    }

    private void DeleteStartText()
    {
        Destroy(_startText);
        SwipeDetection.OnSwipeTriggered -= DeleteStartText;
    }
}