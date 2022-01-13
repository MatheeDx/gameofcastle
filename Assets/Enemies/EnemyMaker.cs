using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMaker : MonoBehaviour {
    public Text waveText;
    public GameObject zmb;
    public GameObject giga;
    bool akt = false;
    int wave = 0;
    public PauseMenu pauseMenu;
    public CanvasGroup gameOver;
    public CanvasGroup gameOverBtn;
    public Text gameOverText;

    IEnumerator WaveText(string num)
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
            waveText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, (float)1 - (float)(i / 1));
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator Wave1(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));

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

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Wave5(string num, int w)
    {
        akt = true;
        wave = w;
        StartCoroutine(WaveText(num));

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            GameObject enemy = Instantiate(zmb, transform.position, transform.rotation);
        }

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(2);
            GameObject enemy = Instantiate(giga, transform.position, transform.rotation);
        }
        akt = false;
    }

    IEnumerator Win()
    {
        akt = true;
        gameOverText.text = "Win";
        gameOverText.color = new Color(0, 0.1624248f, 0.8396226f, 1);
        gameOverText.fontSize = 255;
        pauseMenu.pause = true;
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
                StartCoroutine(Win());
            }
        }
    }
}