using System;
using UnityEngine;

public class TurretEngine : MonoBehaviour {
    //�������� ������� � ������� (����� �������������� � ������ ��������)
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

        //����������� ���� ������� ������� � ������ ������ �������
        if (transform.rotation.eulerAngles.z > 180)
            angleTurret = -(360 - transform.rotation.eulerAngles.z);
        else 
            angleTurret = transform.rotation.eulerAngles.z;

        //������� �������
        Vector3 turret_pos = new Vector3(transform.position.x, transform.position.y, -10);

        //������� ����
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //���� �� ������� ���� ��������� ����� (������������ ������� ����)
        float sight = Vector3.Angle(mouse_pos - turret_pos, Vector3.right);

        //��������� ������������� �������������� ����
        if (mouse_pos.y < turret_pos.y) {
            sight = -sight;
        }

        //������ � ����� ������� ������������ �����
        if (sight > angleTurret) {

            //����������� �������� �� ������� �������
            if (angleUp > angleTurret) {

                //������ ���������� ��������� ������ ������ ��� ����������� � ��������� ����
                if (Math.Abs(sight - angleTurret) > speedRot) {
                    transform.Rotate(0, 0, speedRot);
                } else 
                    transform.rotation = Quaternion.AngleAxis(sight, Vector3.forward);
            }
        } else {

            //����������� �������� �� ������ �������
            if (angleDown < angleTurret) {
                if (Math.Abs(sight - angleTurret) > speedRot) {
                    transform.Rotate(0, 0, -speedRot);
                } else 
                    transform.rotation = Quaternion.AngleAxis(sight, Vector3.forward);
            }
        }
    }
}