using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Button exit;
    public Button restart;

    private void Update()
    {
        restart.onClick.AddListener(GetComponent<AppFun>().startGame);
        exit.onClick.AddListener(GetComponent<AppFun>().exitGame);
    }
}
