using UnityEngine.SceneManagement;
using UnityEngine;

public class AppFun : MonoBehaviour
{
    public void exitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
        GetComponent<PauseMenu>().pause = false;
        Time.timeScale = 1;
    }

    public void startGameGV()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("FirstMenu");
    }
}
