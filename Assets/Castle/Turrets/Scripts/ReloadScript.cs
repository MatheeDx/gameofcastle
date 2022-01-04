using UnityEngine.UI;
using UnityEngine;

public class ReloadScript : MonoBehaviour
{
    float reloadTime;
    TurretEngine Engine;
    TurretFire TFire;
    float timer = 0;
    public bool fire = true;

    public Image Btn;

    void Awake()
    {

        //Берем свойства из класса TurretEngine
        Engine = GetComponent<TurretEngine>();
        TFire = GetComponent<TurretFire>();
    }

    void Update()
    {
        //Сила импульса для снаряда
        reloadTime = Engine.turretRldTime;

        //Таймер
        timer += Time.deltaTime;

        //Клик мыши
        if (!TFire.fire && fire)
        {
            Btn.fillAmount = 0;
            timer = 0;
            fire = false;
            TFire.fire = true;
        }
        if (timer <= reloadTime)
        {
            Btn.fillAmount = timer / reloadTime;
        }
        if (timer > reloadTime)
        {
            Btn.fillAmount = 1;
            fire = true;
        }
    }
}
