/** This allows us to control pausing within the game and freezing of gametime when the game is paused
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    //when it's time to add in reset or whatever, import scene management and add in 


    public bool GameIsPaused;
    public GameObject pauseMenuUI;

    public VariableCount varCount;

    void Start()
    {
        GameIsPaused = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                GameIsPaused = false;
                Resume();
            }

            else
            {
                GameIsPaused = true;
                Pause();
            }
        }

        
    }

    public void Resume()
    {
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        varCount.setPause(GameIsPaused);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        varCount.setPause(GameIsPaused);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has quit");
    }
}
