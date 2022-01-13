using UnityEngine;
using UnityEngine.UI;

public class ZumbieControl : MonoBehaviour {
    public Image hpBar;
    public Image hpBack;
    public float maxHp = 10;
    public float yLimit;
    public float speed;
    public float horzLimit;
    public float dmgReload;
    public float dmgValue;
    [HideInInspector] public float hp;

    Transform enem;
    Rigidbody2D enemRb;

    void Start() {
        //даем хп
        hp = maxHp;

        //Объекты зомби
        enem = GetComponent<Transform>();
        enemRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "missle") {
            //Изменения шкалы здоровья после касания снаряда
            if (hp < maxHp) {
                hpBar.fillAmount = hp / maxHp;
                hpBack.fillAmount = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "boom") {
            //дамаг от сплэша
            float dmg = 7f;
            hp -= dmg;
            
            //Изменение шкалы здоровья
            hpBar.fillAmount = (float)hp / maxHp;
            hpBack.fillAmount = 1;
        }
    }

    void Update() {
        //зомби движется пока не достигнет точки horzLimit
        if (enem.position.x > horzLimit)
            enemRb.velocity = new Vector3( -speed, 0, 0);
        else 
            enemRb.velocity = Vector3.zero;

        //Не даем зомби крутиться
        enem.rotation = new Quaternion(0, 0, 0, 0);

        //зомби вечно на одном уровне
        enem.transform.position -= new Vector3(0, transform.position.y - yLimit, 0);

        //Зомби пропадает если нет здоровья
        if (hp <= 0)
            Destroy(gameObject);
    }
}