using UnityEngine;

public class BulletHit : MonoBehaviour {
    bool hasCollided = false;
    public float dmg;

    void OnCollisionEnter2D(Collision2D coll) {
        //урон юниту при касании со снарядом
        if (coll.gameObject.tag == "enemy") {
            if (hasCollided) return;
            hasCollided = true;
            coll.gameObject.GetComponent<ZumbieControl>().hp -= dmg;
        }
    }
}
