using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMaker : MonoBehaviour {
    public Text waveText;
    public GameObject soldier;
    public GameObject giga;
    bool akt = false;

    IEnumerator WaveText(string num)
    {
        waveText.text = "Wave " + num;
        for (double i = 0; i <= 1; i += Time.deltaTime)
        {
            waveText.color = new Color(0, 0, 0, (float)(i / 1));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1);
        for (double i = 0; i <= 1; i += Time.deltaTime)
        {
            waveText.color = new Color(0, 0, 0, (float)1 - (float)(i / 1));
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator Wave1()
    {
        StartCoroutine(WaveText("one"));

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            GameObject enemy = Instantiate(soldier, transform.position, transform.rotation);
        }

        akt = false;
        while (true)
        {
        if (akt)
            {
                StartCoroutine(Wave2());
                break;
            }
        }
        
    }

    public IEnumerator Wave2()
    {
        StartCoroutine(WaveText("two"));
 
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(2);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }
    }

    void Start() {
        StartCoroutine(Wave1());
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            akt = true;
        }
        Debug.Log(akt);
    }
}