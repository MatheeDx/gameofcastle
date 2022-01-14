using UnityEngine;

public class BulletHit : MonoBehaviour {
    bool hasCollided = false;
    public float dmg;

    void OnCollisionEnter2D(Collision2D coll) {
        //���� ����� ��� ������� �� ��������
        if (coll.gameObject.tag == "enemy") {
            if (hasCollided) return;
            hasCollided = true;
            coll.gameObject.GetComponent<ZumbieControl>().hp -= dmg;
        }
    }
}
