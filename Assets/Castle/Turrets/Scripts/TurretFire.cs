using UnityEngine;

public class TurretFire : MonoBehaviour {
    float speed;
    bool hitFlag;
    public bool fire = true;
    TurretEngine Engine;
    ReloadScript Rld;
    RaycastHit2D hit;
    public PauseMenu pauseMenu;

    void Awake() {
        //����� �������� �� ������ TurretEngine
        Engine = GetComponent<TurretEngine>();
        Rld = GetComponent<ReloadScript>();
    }
    
    //����������� ������ ��� ��������� �� ������ ����������
    void FixedUpdate() { 
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit && hit.transform.name == "ButtonBG")
            hitFlag = false;
        else
            hitFlag = true;
    }

    void Update() {
        if (pauseMenu.pause)
        {
            return;
        }

        //���� �������� ��� �������
        speed = Engine.speedMissle;

        //�������� � ��������� ��������
        float spread = Engine.turretSpread;
        float rand = Random.value*spread;

        //��������� ������� ������� �� ������ TurretEngine
        Rigidbody2D Just_A_Bullet = Engine.sprite;

        //���� ����
        if (Input.GetButton("Fire1") && Rld.fire && hitFlag) {
            float angleTurret;
            //����������� ���� ������� ������� � ������ ������ �������
            if (transform.rotation.eulerAngles.z > 180)
                angleTurret = -(360 - transform.rotation.eulerAngles.z);
            else 
                angleTurret = transform.rotation.eulerAngles.z;

            //�������� �������
            Rigidbody2D bullet = Instantiate(Just_A_Bullet, transform.position + new Vector3(0, 0, (float) 0.1), Quaternion.AngleAxis( angleTurret - spread / 2 + rand, Vector3.forward));

            //����������� �������� ������ �� ������ TurretEngine �������
            bullet.GetComponent<BulletRotation>().dmg = Engine.turretDmg;

            //������� ������� �������
            bullet.velocity = bullet.transform.right * (speed);
            fire = false;
        } 
    }
}