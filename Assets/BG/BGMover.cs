using UnityEngine;

public class BGMover : MonoBehaviour
{
    public Transform level1;
    public Transform level2;
    public float Hlevel1;
    public float Wlevel1;
    public float Hlevel2;
    public float Wlevel2;
    float MouseW;
    float MouseH;
    Vector3 level1Pos;
    Vector3 level2Pos;

    private void Start()
    {
        level1Pos = level1.position;
        level2Pos = level2.position;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        MouseW = mousePos.x / Screen.width;
        MouseH = mousePos.y / Screen.height;
        
        if (MouseW >= 0 && MouseW <= 1 && MouseH >= 0 && MouseH <= 1)
        {
            level1.position = level1Pos + new Vector3(Wlevel1 / 2 - Wlevel1 * MouseW, Hlevel1 / 2 - Hlevel1 * MouseH, 0);
            level2.position = level2Pos + new Vector3(Wlevel2 / 2 - Wlevel2 * MouseW, Hlevel2 / 2 - Hlevel2 * MouseH, 0);
        }   
    }
}
