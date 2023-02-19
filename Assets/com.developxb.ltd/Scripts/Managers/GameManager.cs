using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int health;
    private int score;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject rules;
    [SerializeField] GameObject record;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;

    private void Awake()
    {
        Ball.OnBallPressed += (IsEnemy) =>
        {
            if(IsEnemy)
            {
                health--;
                if(health <=0)
                {
                    GameOver();
                    return;
                }
            }
            else
            {
                score += Random.Range(10, 25);
                scoreText.text = finalScoreText.text = $"SCORE {score}";
            }
        };
    }

    private void Start() => Init();

    private void Init()
    {
        rules.SetActive(false);
        record.SetActive(false);
        game.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    private void GameOver()
    {
        StopCoroutine(nameof(Spawning));
        foreach (Ball b in FindObjectsOfType<Ball>())
        {
            Destroy(b.gameObject);
        }

        game.SetActive(false);
        result.SetActive(true);
    }

    public void OpenRules()
    {
        menu.SetActive(false);
        rules.SetActive(true);
    }

    public void OpenRecord()
    {
        menu.SetActive(false);
        record.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(nameof(Spawning));

        result.SetActive(false);
        menu.SetActive(false);
        game.SetActive(true);

        score = 0;
        health = 3;

        scoreText.text = finalScoreText.text = $"SCORE {score}";
    }

    public void OpenMenu()
    {
        StopCoroutine(nameof(Spawning));
        foreach (Ball b in FindObjectsOfType<Ball>())
        {
            Destroy(b.gameObject);
        }

        result.SetActive(false);
        rules.SetActive(false);
        record.SetActive(false);

        menu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator Spawning()
    {
        Transform parent = GameObject.Find("Environment").transform;
        GameObject[] balls = Resources.LoadAll<GameObject>("balls");

        while(true)
        {
            Instantiate(balls[Random.Range(0, balls.Length)], parent);
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        }
    }
}
