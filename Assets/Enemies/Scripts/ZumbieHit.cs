using UnityEngine;

public class ZumbieHit : MonoBehaviour 
{
    float dmg;
    float dmgRel;
    float timer = 0;

    private void OnCollisionStay2D ( Collision2D target ) 
    {
        if (target.gameObject.tag == "Castle" && timer >= GetComponent<ZumbieControl>().dmgReload) 
        {
            target.gameObject.GetComponent<CastleScript>().hp -= GetComponent<ZumbieControl>().dmgValue;
            timer = 0;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}