using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            ActivateMenu();
        }
        else if (!isPaused)
        {
            DeactivateMenu();
        }
        
    }

    void ActivateMenu() 
    {
        Time.timeScale = 0;
      //  AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
       // AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    public void QuitGame() 
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }





}
