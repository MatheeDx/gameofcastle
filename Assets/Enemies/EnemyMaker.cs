using UnityEngine;

public class EnemyMaker : MonoBehaviour {
    public GameObject soldier;
    void Update() {
        //��� ������� �� ������ ���������� �����
        if (Input.GetButtonDown("Jump"))
        {
            GameObject enemy = Instantiate(soldier, transform.position, transform.rotation);
        }
    }
}