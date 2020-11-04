using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameSCript : MonoBehaviour
{
    [SerializeField] private GameObject EndGameMenu;
    [SerializeField] private bool isGameOver;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Transform HPCheck;
    [SerializeField] private Text textBox;

    [SerializeField] private HeadCounter hc;
    void ActivateMenu()
    {
        PauseMenuScript ps = new PauseMenuScript();
        ps.PauseGame();
        //AudioListener.pause = true;
        EndGameMenu.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] collidersHP = Physics2D.OverlapCircleAll(HPCheck.position, .1f, whatIsPlayer);
        for (int i = 0; i < collidersHP.Length; i++)
        {
            if (collidersHP[i].gameObject != gameObject)
            {
                EndGame();
            }
        }
    }

    void EndGame() {
        isGameOver = true;
        textBox.text=hc.getHeadCount()+" heads";
        ActivateMenu();
    }
}
