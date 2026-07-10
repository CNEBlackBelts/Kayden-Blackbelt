using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync(2);
    }
    
    public void PlayGame2()
    {
        SceneManager.LoadScene(3);
    }

    //1:17:24
    




}
