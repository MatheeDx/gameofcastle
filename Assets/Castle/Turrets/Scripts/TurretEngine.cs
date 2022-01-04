using System;
using UnityEngine;

public class TurretEngine : MonoBehaviour {
    //Свойства туррели и снаряда (будут использоваться в других скриптах)
    public float speedRot;
    public float speedMissle;
    public float turretDmg;
    public float turretRldTime;
    public float turretSpread;
    public float angleUp;
    public float angleDown;
    public Rigidbody2D sprite;
    public PauseMenu pauseMenu;


    void Update() {
        if (pauseMenu.pause)
        {
            return;
        }
        float angleTurret;

        //Высчитываем угол наклона туррели в данный момент времени
        if (transform.rotation.eulerAngles.z > 180)
            angleTurret = -(360 - transform.rotation.eulerAngles.z);
        else 
            angleTurret = transform.rotation.eulerAngles.z;

        //Позиция туррели
        Vector3 turret_pos = new Vector3(transform.position.x, transform.position.y, -10);

        //Позиция мыши
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Угол на который надо повернуть пушку (относительно позиции мыши)
        float sight = Vector3.Angle(mouse_pos - turret_pos, Vector3.right);

        //Добавляет существование отрицательного угла
        if (mouse_pos.y < turret_pos.y) {
            sight = -sight;
        }

        //Решаем в какую сторону поворачивать пушку
        if (sight > angleTurret) {

            //Ограничение поворота по верхней границе
            if (angleUp > angleTurret) {

                //Данная реализация позволяет убрать тряски при приближении к конечному углу
                if (Math.Abs(sight - angleTurret) > speedRot) {
                    transform.Rotate(0, 0, speedRot);
                } else 
                    transform.rotation = Quaternion.AngleAxis(sight, Vector3.forward);
            }
        } else {

            //Ограничение поворота по нижней границе
            if (angleDown < angleTurret) {
                if (Math.Abs(sight - angleTurret) > speedRot) {
                    transform.Rotate(0, 0, -speedRot);
                } else 
                    transform.rotation = Quaternion.AngleAxis(sight, Vector3.forward);
            }
        }
    }
}