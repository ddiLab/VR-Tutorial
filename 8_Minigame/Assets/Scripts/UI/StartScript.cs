using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Start - Fade to Black
    // End - Fade from Black
    private Color startColor = new Color (0, 0, 0, 1);
    private Color endColor = new Color(0, 0, 0, 0);

    // Link to TimerController
    private TimerScript m_Timer;

    // Hold Respective Objects
    public GameObject VRPointer = null;
    public GameObject Player = null;

    // Call Routine for starting game
    public void StartGame()
    {
        StartCoroutine(StartProcess());
    }

    // Call Routine for ending game
    public void EndGame()
    {
        StartCoroutine(EndProcess());
    }

    public void Restart()
    {
        m_Timer = GameObject.Find("/TimerController").GetComponent<TimerScript>();
        m_Timer.StartTimer();
    }

    IEnumerator StartProcess()
    {
        // Fade Out + Disable Pointer
        SteamVR_Fade.Start(startColor, 2, true);
        VRPointer.SetActive(false);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Load Minigame scene
        SceneManager.LoadSceneAsync("Minigame");

        // Set Player Position
        Player.transform.position = new Vector3(0f, 0.271f, 0f);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        VRPointer.SetActive(true);

        // Fade In
        SteamVR_Fade.Start(endColor, 3, true);
    }

    IEnumerator EndProcess()
    {
        // Fade Out + Disable Pointer
        SteamVR_Fade.Start(startColor, 2, true);

        // Set pointer to active
        VRPointer.SetActive(false);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Load All objects from VRSpace
        SceneManager.LoadSceneAsync("VRSpace");

        // Set Player Position
        Player.transform.position = new Vector3(0f, 0.271f, 0f);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        VRPointer.SetActive(true);

        // Fade In
        SteamVR_Fade.Start(endColor, 3, true);
    }
}
