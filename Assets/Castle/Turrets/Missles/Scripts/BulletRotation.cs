using UnityEngine;

//Скрипт для реалистичного движения снаряда
public class BulletRotation : MonoBehaviour {
    void Update() {
        //Угол между OX и направлением движения (всегда положительный)
        float angle = Vector2.Angle(Vector2.right, GetComponent<Rigidbody2D>().velocity);

        //Добавляем существование отрицательных углов
        if (GetComponent<Rigidbody2D>().velocity.y < 0) angle = -angle;

        //Угол снаряда = углу напраления движения
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}