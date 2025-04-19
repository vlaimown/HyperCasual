using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Store_window;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Стартуем");
        SceneManager.LoadScene("PlayerScene");
    }

    public void Store()
    {
        Store_window.SetActive(true);
    }

}
