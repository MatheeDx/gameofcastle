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
        //���� ��
        hp = maxHp;

        //������� �����
        enem = GetComponent<Transform>();
        enemRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "missle") {
            //��������� ����� �������� ����� ������� �������
            if (hp < maxHp) {
                hpBar.fillAmount = hp / maxHp;
                hpBack.fillAmount = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "boom") {
            //����� �� ������
            float dmg = 7f;
            hp -= dmg;
            
            //��������� ����� ��������
            hpBar.fillAmount = (float)hp / maxHp;
            hpBack.fillAmount = 1;
        }
    }

    void Update() {
        //����� �������� ���� �� ��������� ����� horzLimit
        if (enem.position.x > horzLimit)
            enemRb.velocity = new Vector3( -speed, 0, 0);
        else 
            enemRb.velocity = Vector3.zero;

        //�� ���� ����� ���������
        enem.rotation = new Quaternion(0, 0, 0, 0);

        //����� ����� �� ����� ������
        enem.transform.position -= new Vector3(0, transform.position.y - yLimit, 0);

        //����� ��������� ���� ��� ��������
        if (hp <= 0)
            Destroy(gameObject);
    }
}