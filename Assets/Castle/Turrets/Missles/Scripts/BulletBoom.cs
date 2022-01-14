using UnityEngine;
public class BulletBoom : MonoBehaviour {

    //Добавляем анимацию взрыва
    public GameObject explosion;
    bool hasCollided = false;

    //Столкновение с коллайдерами объектов
    void OnCollisionEnter2D(Collision2D obj) {
        if (hasCollided) return;
        hasCollided = true;
        if (obj.gameObject.tag != "missle")
        {
            //Создание объекта "Взрыва"
            GameObject boom = Instantiate(explosion, transform.position, transform.rotation);

            //Удаление снаряда
            Destroy(gameObject);
        }
        
    }
}