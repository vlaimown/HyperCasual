using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Character character;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _adsScreen;

    private void Start()
    {
        SwipeDetection.OnSwipeTriggered += DeleteStartText;
        Coin.OnCollectCoin += SetCoinText;
        FinishPoint.OnPlayerFinished += ShowWinScreen;
        Character.OnCharacterDeath += ShowLoseScreen;
    }

    private void DeleteStartText()
    {
        Destroy(_startText);
        SwipeDetection.OnSwipeTriggered -= DeleteStartText;
    }

    private void SetCoinText()
    {
        _coinText.text = $"{character.Coins}";
    }

    private void ShowWinScreen()
    {
        _winScreen.SetActive(true);
    }

    private void ShowLoseScreen()
    {
        _loseScreen.SetActive(true);
    }
    
    public void ShowAdsScreen()
    {
        _adsScreen.SetActive(true);
    }
}