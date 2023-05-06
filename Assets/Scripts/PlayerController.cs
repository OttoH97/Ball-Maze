using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI timerObject;
    public Button retryBtn;
    public Button quitBtn;

    private int count;
    private float timer;

    private void Start()
    {
        Time.timeScale = 1;
        count = 0;
        timer = 0.0f;
        SetCountText();
        winTextObject.SetActive(false);
        retryBtn.enabled = false;
        quitBtn.enabled = false;
        retryBtn.gameObject.SetActive(false);
        quitBtn.gameObject.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        string seconds = timer.ToString("##.##");
        timerObject.text = $"Time: {seconds}";

        if (Time.timeScale == 0)
        {
            retryBtn.gameObject.SetActive(true);
            quitBtn.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            Time.timeScale = 0;
            retryBtn.enabled = true;
            quitBtn.enabled = true;
            retryBtn.gameObject.SetActive(true);
            quitBtn.gameObject.SetActive(true);
            retryBtn.onClick.AddListener(RetryGame);
            quitBtn.onClick.AddListener(QuitGame);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 16)
        {
            winTextObject.SetActive(true);
            Time.timeScale = 0;
            retryBtn.enabled = true;
            quitBtn.enabled = true;
            retryBtn.gameObject.SetActive(true);
            quitBtn.gameObject.SetActive(true);
            retryBtn.onClick.AddListener(RetryGame);
            quitBtn.onClick.AddListener(QuitGame);
        }
    }

    public void RetryGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

