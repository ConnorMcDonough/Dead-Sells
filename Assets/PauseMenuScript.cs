using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    [SerializeField]  private AudioSource playerSound;
    
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

    public void PauseGame() {
        Time.timeScale = 0;
    }
    void ActivateMenu() 
    {
        PauseGame();
        playerSound.Pause();
        pauseMenuUI.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        playerSound.Play();
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
