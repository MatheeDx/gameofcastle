using UnityEngine;

public class ZumbieHit : MonoBehaviour 
{
    float castleHp;
    float dmg;
    float dmgRel;
    float timer = 0;

    private void Awake()
    {
        dmg = GetComponent<ZumbieControl>().dmgValue;
        dmgRel = GetComponent<ZumbieControl>().dmgReload;
    }

    private void OnCollisionStay2D ( Collision2D target ) 
    {
        if (target.gameObject.tag == "Castle" && timer >= dmgRel) 
        {
            target.gameObject.GetComponent<CastleScript>().hp -= dmg;
            timer = 0;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}