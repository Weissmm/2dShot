using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinMenu : MonoBehaviour
{
    public GameObject finalMenuUI;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            finalMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
