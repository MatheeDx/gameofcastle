using UnityEngine;

public class BulletHit : MonoBehaviour {
    bool hasCollided = false;
    void OnCollisionEnter2D(Collision2D coll) {
        //урон юниту при касании со снарядом
        if (coll.gameObject.tag == "enemy") {
            if (hasCollided) return;
            hasCollided = true;
            coll.gameObject.GetComponent<ZumbieControl>().hp -= GetComponent<BulletRotation>().dmg;
        }
    }
}
