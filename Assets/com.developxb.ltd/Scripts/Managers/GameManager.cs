using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;

    private void Start() => Init();

    private void Init()
    {
        game.SetActive(false);
        pause.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);
    }

    public void StartGame()
    {
        result.SetActive(false);
        menu.SetActive(false);
        game.SetActive(true);

        score = 0;
        scoreText.text = finalScoreText.text = $"SCORE {score}";
    }

    public void Pause(bool IsPause)
    {
        game.SetActive(!IsPause);
        pause.SetActive(IsPause);
    }

    public void OpenMenu()
    {
        result.SetActive(false);
        pause.SetActive(false);

        menu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
