using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMaker : MonoBehaviour {
    public Text waveText;
    public GameObject zmb;
    public GameObject giga;
    bool akt = false;
    int wave = 0;
    public CanvasGroup gameOver;
    public CanvasGroup gameOverBtn;
    public Text gameOverText;
    float waitWave = 2f;

    IEnumerator WaveText(string num, bool final = false)
    {
        if (!final)
        {
            waveText.text = "Wave " + num;
            for (double i = 0; i <= 1; i += Time.deltaTime)
            {
                waveText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, (float)(i / 1));
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(1);
            for (double i = 0; i <= 1; i += Time.deltaTime)
            {
                waveText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1f - (float)(i / 1));
                yield return new WaitForEndOfFrame();
            }
        } 
        else
        {
            waveText.text = "FINAL WAVE";
            for (double i = 0; i <= 1; i += Time.deltaTime)
            {
                waveText.color = new Color(0.6603774f, 0, 0, (float)(i / 1));
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(1);
            for (double i = 0; i <= 1; i += Time.deltaTime)
            {
                waveText.color = new Color(0.6603774f, 0, 0, 1f - (float)(i / 1));
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator Wave1(string num, int w)
    {
        akt = true;
        wave = 8;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave2(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave3(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.35f);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave4(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave5(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave6(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }

        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave7(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(3);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave8(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));
        yield return new WaitForSeconds(waitWave);

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(3);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
            yield return new WaitForSeconds(1);
            enemy = Instantiate(giga, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.8f);
            enemy = Instantiate(giga, transform.position, transform.rotation);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            enemy = Instantiate(zmb, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave9(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num, true));
        yield return new WaitForSeconds(waitWave);

        GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        enemy.GetComponent<ZumbieControl>().dmgValue = 40;
        enemy.GetComponent<ZumbieControl>().dmgReload = 2;
        enemy.GetComponent<ZumbieControl>().maxHp = 450;
        enemy.GetComponent<ZumbieControl>().speed = 0.4f;

        yield return new WaitForSeconds(5.5f);
        for (float i = 0; i < 10; i += Time.deltaTime)
        {
            Vector3 scale = enemy.GetComponent<Transform>().localScale;
                
            if (scale.x + scale.y + scale.z < 36*3)
            {
                enemy.GetComponent<Transform>().localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
            if (enemy.GetComponent<ZumbieControl>().yLimit < 4.4f)
            {
                enemy.GetComponent<ZumbieControl>().yLimit += 0.005f/2;
            }
            yield return new WaitForEndOfFrame();
        }
        akt = false;
    }

    IEnumerator Win()
    {
        akt = true;
        gameOverText.text = "You WIN";
        gameOverText.color = new Color(0, 0.1624248f, 0.8396226f, 1);
        gameOverText.fontSize = 255;
        PauseMenu.pause = true;
        gameOver.gameObject.SetActive(true);
        for (double t = 0; t <= 1.5; t += Time.deltaTime)
        {
            gameOver.alpha = (float)(t / 1.5);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
        for (double t = 0; t <= 1; t += Time.deltaTime)
        {
            gameOverBtn.alpha = (float)(t / 1);
            yield return new WaitForEndOfFrame();
        }
    }

    void Start() {
        StartCoroutine(Wave1("one", 1));
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("enemy") == null && !akt)
        {
            if (wave == 1)
            {
                StartCoroutine(Wave2("two", 2));
            }
            else if (wave == 2)
            {
                StartCoroutine(Wave3("three", 3));
            }
            else if (wave == 3)
            {
                StartCoroutine(Wave4("four", 4));
            }
            else if (wave == 4)
            {
                StartCoroutine(Wave5("five", 5));
            }
            else if (wave == 5)
            {
                StartCoroutine(Wave6("six", 6));
            }
            else if (wave == 6)
            {
                StartCoroutine(Wave7("seven", 7));
            }
            else if (wave == 7)
            {
                StartCoroutine(Wave8("eight", 8));
            }
            else if (wave == 8)
            {
                StartCoroutine(Wave9("nine", 9));
            }
            else if (wave == 9)
            {
                StartCoroutine(Win());
            }
        }
    }
}