using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MovementController movementController;
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StopPlayer()
    {
        movementController.StopMoving();
    }

    public void ResumePlayer()
    {
        movementController.ResumeMoving();
    }

    public void RestartGame()
    {
        movementController.MovePlayerAtStartOfLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
