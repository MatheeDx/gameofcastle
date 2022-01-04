using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FMenuEngine : MonoBehaviour
{
    public Button fire;
    public Button exit;

    private void Update()
    {
        fire.onClick.AddListener(GetComponent<AppFun>().startGame);
        exit.onClick.AddListener(GetComponent<AppFun>().exitGame);
    }
}
