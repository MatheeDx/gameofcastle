using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CastleScript : MonoBehaviour
{
    public Image hpBar;
    public Image hpBack;
    public float maxHp;
    public CanvasGroup gameOverText;
    public CanvasGroup gameOverBtn;
    [HideInInspector]public float hp;
    bool f = false;
    public PauseMenu pauseMenu;

    public IEnumerator gameOver()
    {
        pauseMenu.pause = true;
        gameOverText.gameObject.SetActive(true);
        for (double i = 0; i <= 1.5; i += Time.deltaTime)
        {
            gameOverText.alpha = (float) (i / 1.5);
            Debug.Log(i);
            yield return new WaitForEndOfFrame();
        }
        for (double i = 0; i <= 0.5; i += Time.deltaTime) { yield return new WaitForEndOfFrame(); }
        for (double i = 0; i <= 1; i += Time.deltaTime)
        {
            gameOverBtn.alpha = (float) (i / 1);
            yield return new WaitForEndOfFrame();
        }
    }

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if (hp < maxHp)
        {
            hpBack.fillAmount = 1;
            hpBar.fillAmount = hp/maxHp;
        }
        if (hp <= 0 && !f)
        {
            StartCoroutine(gameOver());
            f = true;
        }
    }
}
