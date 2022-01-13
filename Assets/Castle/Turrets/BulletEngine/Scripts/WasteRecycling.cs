using UnityEngine;

public class WasteRecycling : MonoBehaviour {

    //��������� ������� (�� ��������� �������)
    public int time = 1;

    //�������
    float timer = 0;

    void Update() {
        if (gameObject.name == "Explosion(Clone)") {
            //������ ����� � �������� ����������� ��������� ������� ����� �������� (����������)
            timer += Time.deltaTime;

            if (timer > 0.6f)
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }

            //������� �� ������� ��������� �� ��������� ���� ������ ������������� ����� (��� ������� ����� ��������� ������ �������� ������ �������)
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
            //�������� �������
            Destroy(gameObject);
        }
    
    }
}