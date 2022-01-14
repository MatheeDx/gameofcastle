using UnityEngine;
public class BulletBoom : MonoBehaviour {

    //��������� �������� ������
    public GameObject explosion;
    bool hasCollided = false;

    //������������ � ������������ ��������
    void OnCollisionEnter2D(Collision2D obj) {
        if (hasCollided) return;
        hasCollided = true;
        if (obj.gameObject.tag != "missle")
        {
            //�������� ������� "������"
            GameObject boom = Instantiate(explosion, transform.position, transform.rotation);

            //�������� �������
            Destroy(gameObject);
        }
        
    }
}