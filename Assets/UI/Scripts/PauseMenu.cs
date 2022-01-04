using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Button restart;
    public Button options;
    public Button mainMenu;
    public Button exit;
    public bool pause = false;


    
    void Update()
    {
        restart.onClick.AddListener(GetComponent<AppFun>().startGame);
        mainMenu.onClick.AddListener(GetComponent <AppFun>().mainMenu);
        exit.onClick.AddListener (GetComponent<AppFun>().exitGame);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pause = false;
                GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1;
            } 
            else 
            {
                pause = true;
                GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}
