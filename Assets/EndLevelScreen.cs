using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndLevelScreen : MonoBehaviour
{
    public GameObject adsDialog;
    public GameObject buttonAds;
    public GameObject buttonCancel;
    public GameObject textAds;

    public string mainSceneName;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadLevel()
    {
        Debug.Log("перезагрузка сцены");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Debug.Log("переход в главное меню");
        hideDiaolog();
        SceneManager.LoadScene(mainSceneName);
    }

    public void NextLevel()
    {
        Debug.Log("переход на следующий уровень");
        SceneManager.LoadScene(sceneName);
    }

    public void showDiaolog()
    {
        gameObject.SetActive(true);
        buttonAds.SetActive(true);
    }

    public void hideDiaolog()
    {
        gameObject.SetActive(false);
    }

    public void showAds()
    {
        StartCoroutine(ShowDialogForSeconds());
        buttonAds.SetActive(false);
    }

    private IEnumerator ShowDialogForSeconds()
    {
        TMP_Text text = textAds.GetComponent<TMP_Text>();
        adsDialog.SetActive(true);
        buttonCancel.SetActive(false);
        for (int i = 3; i >= 0; i--) 
        {
            text.text = i + "s"; 
            yield return new WaitForSeconds(1f);
        }
        textAds.SetActive(false);
        buttonCancel.SetActive(true);
    }

    public void onClickCancelAdsButton()
    {
        adsDialog.SetActive(false);
    }
}
