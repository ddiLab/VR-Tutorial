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

    IEnumerator StartProcess()
    {
        // Fade Out + Disable Pointer
        SteamVR_Fade.Start(startColor, 2, true);
        VRPointer.SetActive(false);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Unload All objects from VRSpace
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            g.SetActive(false);
        }

        // Load Minigame scene
        SceneManager.LoadSceneAsync("Minigame", LoadSceneMode.Additive);

        // Set Player Position
        Player.transform.position = new Vector3(0f, 0.271f, 0f);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Fade In
        SteamVR_Fade.Start(endColor, 3, true);
    }

    IEnumerator EndProcess()
    {
        // Fade Out + Disable Pointer
        SteamVR_Fade.Start(startColor, 2, true);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Unload All objects from Minigame
        foreach (GameObject g in SceneManager.GetSceneByName("Minigame").GetRootGameObjects())
        {
            g.SetActive(false);
        }

        // Load All objects from VRSpace
        foreach (GameObject g in SceneManager.GetSceneByName("VRSpace").GetRootGameObjects())
        {
            g.SetActive(true);
        }

        // Set pointer to active
        VRPointer.SetActive(true);

        // Set Player Position
        Player.transform.position = new Vector3(0f, 0.271f, 0f);

        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Fade In
        SteamVR_Fade.Start(endColor, 3, true);
    }
}
