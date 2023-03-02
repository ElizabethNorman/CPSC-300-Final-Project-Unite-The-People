/** The main menu script allows for functionality of the main menu buttons 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame()
    {
        //this dummy loop allows the click sound effect to play before the next scene is loaded
        for (int i = 0; i < 1000; i ++)
        {

        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



    }

    public void OptionsMenu()
    {

        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        
    }


    public void ExitOptionsMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        
    }



    public void QuitGame()
    {
       // Debug.Log("Game is exiting");
        Application.Quit();
    }



}
