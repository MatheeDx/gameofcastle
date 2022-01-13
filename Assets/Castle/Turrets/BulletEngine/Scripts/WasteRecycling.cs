using UnityEngine;

public class WasteRecycling : MonoBehaviour {

    //Установка таймера (по умолчанию секунда)
    public int time = 1;

    //Счетчик
    float timer = 0;

    void Update() {
        if (gameObject.name == "Explosion(Clone)") {
            //Каждый фрейм к счетчику добавляется временная разница между фреймами (секундомер)
            timer += Time.deltaTime;

            if (timer > 0.6f)
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }

            //Остатки от снаряда удаляются из игровогго мира спустя установленное время (дал секунду чтобы проиграла полная анимация взрыва снаряда)
            if (timer > time) {
                Destroy(gameObject);
            }
            if (timer > 0.5)
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }

    }

    void OnCollisionEnter2D(Collision2D obj) {
        if (obj.gameObject.tag != "missle" && gameObject.name == "PrefabBulletTurret(Clone)") {
            //Удаление снаряда
            Destroy(gameObject);
        }
    
    }
}