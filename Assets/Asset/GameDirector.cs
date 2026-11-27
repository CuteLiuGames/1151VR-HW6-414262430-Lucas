using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;

    GameObject diffucultyText;

    public Light directionalLight;

    [SerializeField] private GameObject Banner;
    float time = 60.0f;
    int point = 0;
    int currentLevel = 0;
    GameObject generator;
    [SerializeField] private GameObject gameOver;
    int finalScore;

    [SerializeField] private TextMeshProUGUI ScoreText;

    bool isEnd = true;

    public void GetApple()
    {
        if (!this.isEnd)
        {
            this.point += 100;
        }
    }
    public void GetBomb()
    {
        if (!this.isEnd)
        {
            this.point /= 2;
        }
    }
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.diffucultyText = GameObject.Find("Difficulty");
        this.generator = GameObject.Find("ItemGenerator");
        
        this.isEnd = true;

        if (directionalLight == null)
            directionalLight = GetComponent<Light>();
    }


    public void StartGame(int level)
    {
        if(level > 0) currentLevel = level;
        time = 60.0f;
        point = 0;
        this.generator.GetComponent<ItemGenerator>().Reset();
        if (level == 4)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.4f, -0.06f, 6);
            directionalLight.color = Color.orangeRed;
        }
        if(level == 3)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.6f, -0.04f, 4);
            directionalLight.color = Color.white;
        }
        if (level == 2)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.8f, -0.03f, 3);
            directionalLight.color = Color.white;
        }
        if (level == 1)
        {
            this.generator.GetComponent<ItemGenerator>().SetDefault();
            directionalLight.color = Color.white;
        }
        StartCoroutine(GameBegin());
    }

    public void RestartGame()
    {
        int level = currentLevel;
        time = 60.0f;
        point = 0;
        this.generator.GetComponent<ItemGenerator>().Reset();
        if (level == 4)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.4f, -0.06f, 6);
            directionalLight.color = Color.orangeRed;
        }
        if (level == 3)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.6f, -0.04f, 4);
            directionalLight.color = Color.white;
        }
        if (level == 2)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.8f, -0.03f, 3);
            directionalLight.color = Color.white;
        }
        if (level == 1)
        {
            this.generator.GetComponent<ItemGenerator>().SetDefault();
            directionalLight.color = Color.white;
        }
        StartCoroutine(GameBegin());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            this.time -= Time.deltaTime;

            if (this.time < 0)
            {
                this.time = 0;
                if (!this.isEnd)
                {
                    Debug.Log("Time Up");
                    StartCoroutine(TimeUp());
                }

                this.generator.GetComponent<ItemGenerator>().setParameter(10000.0f, 0, 0);
            }
            
        }

            this.timerText.GetComponent<TextMeshProUGUI>().text = "Time: " + this.time.ToString("F1");
            this.pointText.GetComponent<TextMeshProUGUI>().text = "Score: " + this.point.ToString();
        if(currentLevel == 4)
        {
            this.diffucultyText.GetComponent<TextMeshProUGUI>().text = "EXTREME";
        }
        else if (currentLevel == 3)
        {
            this.diffucultyText.GetComponent<TextMeshProUGUI>().text = "Hard";
        }
        if (currentLevel == 2)
        {
            this.diffucultyText.GetComponent<TextMeshProUGUI>().text = "Medium";

        }
        else if (currentLevel == 1)
        {
            this.diffucultyText.GetComponent<TextMeshProUGUI>().text = "Easy";
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator GameBegin()
    {
        isEnd = true;
        this.generator.GetComponent<ItemGenerator>().SetState(false);
        Banner.GetComponent<EventBanner>().ShowBannerText("3");
        yield return new WaitForSecondsRealtime(1f);
        Banner.GetComponent<EventBanner>().ShowBannerText("2");
        yield return new WaitForSecondsRealtime(1f);
        Banner.GetComponent<EventBanner>().ShowBannerText("1");
        yield return new WaitForSecondsRealtime(1f);
        Banner.GetComponent<EventBanner>().ShowBannerText("GO");
        yield return new WaitForSecondsRealtime(1f);
        Banner.GetComponent<EventBanner>().HideBannerText();
        this.generator.GetComponent<ItemGenerator>().SetState(true);
        isEnd = false;
    }
    IEnumerator TimeUp()
    {
        this.isEnd = true;
        this.generator.GetComponent<ItemGenerator>().SetState(false);
        Banner.GetComponent<EventBanner>().ShowBannerText("TIME UP");
        yield return new WaitForSecondsRealtime(2f);
        Banner.GetComponent<EventBanner>().HideBannerText();
        finalScore = point;
        gameOver.SetActive(true);
        ScoreText.text = finalScore.ToString();
    }
}
