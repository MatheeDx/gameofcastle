using UnityEngine.UI;
using UnityEngine;

public class SwitchTurretScript : MonoBehaviour {
    public Button CannonBtn;
    public Button TurretBtn;
    public Transform actBtn;
    public string Flag = "Cannon";
    public PauseMenu pauseMenu;

    //Устанавливаем функцию, которая по входным аргументам отключает или включает определенную туррель
    void SwitchTurret (string name, bool value) {
        var obj = GameObject.Find(name);
        TurretEngine x = obj.GetComponent<TurretEngine>();
        x.enabled = value;
        TurretFire y = obj.GetComponent<TurretFire>();
        y.enabled = value;
        if (value && name == "Turret" && Flag == "Cannon")
        {
            Transform act = Instantiate(actBtn, GameObject.Find("TurretButton").transform.position, transform.rotation);
            act.SetParent(GameObject.Find("TurretButton").transform);
            Destroy(GameObject.Find("CannonButton/ActiveBtn(Clone)"));
            Flag = "Turret";
        }
        else if (value && name == "Cannon" && Flag == "Turret")
        {
            Transform act = Instantiate(actBtn, GameObject.Find("CannonButton").transform.position, transform.rotation);
            act.SetParent(GameObject.Find("CannonButton").transform);
            Destroy(GameObject.Find("TurretButton/ActiveBtn(Clone)"));
            Flag = "Cannon";
        } 
    }

    //Меняем туррели по нажатии кнопок
    public void TurretOn() {
        SwitchTurret("Cannon", false);
        SwitchTurret("Turret", true);
        
    }

    public void CannonOn() {
        SwitchTurret("Cannon", true);
        SwitchTurret("Turret", false);
    }

    void Start()
    {
        SwitchTurret("Turret", true);
    }

    void Update() {
        if (pauseMenu.pause)
        {
            return;
        }
        TurretBtn.onClick.AddListener(TurretOn);
        CannonBtn.onClick.AddListener(CannonOn);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTurret("Cannon", false);
            SwitchTurret("Turret", true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTurret("Cannon", true);
            SwitchTurret("Turret", false);
        }
    }  
}