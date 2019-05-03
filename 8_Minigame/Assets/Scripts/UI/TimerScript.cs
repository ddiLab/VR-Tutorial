using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float m_Timer;

    private float timer;
    private bool canCount = false;
    private bool doOnce = true;

    // Runtime GameObject vars
    private GameObject m_Pointer;
    private GameObject m_Restart;
    private GameObject m_Exit;
    private ScoreScript m_Score;
    private Text m_Text;
    private Text m_Total;

    // Runtime GameObject References
    private void Awake()
    {
        m_Pointer = GameObject.Find("/Player/SteamVRObjects/RightHand/VRPointer");
        m_Text = GameObject.Find("/Player/SteamVRObjects/VRCamera/FollowHead/Canvas/Time").GetComponent<Text>();
        m_Total = GameObject.Find("/Player/SteamVRObjects/VRCamera/FollowHead/Canvas/Points").GetComponent<Text>();
        m_Restart = GameObject.Find("Player/SteamVRObjects/VRCamera/FollowHead/Canvas/Restart");
        m_Exit = GameObject.Find("Player/SteamVRObjects/VRCamera/FollowHead/Canvas/Exit");
        m_Score = GameObject.Find("/TimerController").GetComponent<ScoreScript>();

        // Set Timer
        timer = m_Timer;
        m_Text.text = timer.ToString("F");
    }

    // Updates timer
    private void Update()
    {
        // Count down until timer hits zero
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            m_Text.text = timer.ToString("F");
            m_Total.text = m_Score.GetTotal().ToString();
        }
        else if(timer <= 0.0f && !doOnce) // Ends Minigame, enables UI and Pointer
        {
            canCount = false;
            doOnce = true;
            m_Text.text = "0.00";
            timer = 0.0f;
            m_Pointer.SetActive(true);
            m_Restart.SetActive(true); m_Exit.SetActive(true);
        }
    }

    // Minigame start function
    public void StartTimer()
    {
        // Reset Score
        m_Score.ResetScore();

        // Disable UI
        m_Pointer.SetActive(false);
        m_Restart.SetActive(false); m_Exit.SetActive(false);

        // Reset Game
        timer = m_Timer;
        canCount = true;
        doOnce = false;
    }
}
