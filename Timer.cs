using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 10f;
    public float timeLeft;
    private bool m_StartTransition = true;

    void Start()
    {
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft==0)
        {
            Time.timeScale = 0;
            if (MatchManager.Instance.DidWin())
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                if (m_StartTransition)
                {
                    GameObject gameObject = GameObject.Find("FadePanel");
                    gameObject.GetComponent<Animator>().Play("FadeOutMatchGame");
                    m_StartTransition = false;
                }
            }
        }
    }
}


  
