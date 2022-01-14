using UnityEngine;

//������ ��� ������������� �������� �������
public class BulletRotation : MonoBehaviour {
    void Update() {
        //���� ����� OX � ������������ �������� (������ �������������)
        float angle = Vector2.Angle(Vector2.right, GetComponent<Rigidbody2D>().velocity);

        //��������� ������������� ������������� �����
        if (GetComponent<Rigidbody2D>().velocity.y < 0) angle = -angle;

        //���� ������� = ���� ���������� ��������
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}