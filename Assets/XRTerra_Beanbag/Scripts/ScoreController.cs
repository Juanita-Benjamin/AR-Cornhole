using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;

    public static ScoreController _instance;
    
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI winText;

    public static ScoreController Instance => _instance;

    [SerializeField] private float countDown;
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        countDown = 3;
    }

    public void HitHole()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        
        if (score == 21)
        {
            winText.gameObject.SetActive(true);
            countDown -= 1 * Time.deltaTime;
        }

        if (countDown <= 0)
        {
            winText.gameObject.SetActive(false);
        }
    }
}
