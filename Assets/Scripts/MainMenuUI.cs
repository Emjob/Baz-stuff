using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Slider volumeSlider;

    public float speed = 50f; // The speed at which the buttons move
    public float amplitude = 10f; // The maximum distance the buttons move from their starting position
    public float frequency = 1f; // The frequency of the buttons' movement

    private Vector3[] startingPositions; // The starting position of each button
    private RectTransform[] buttons; // The buttons to move

    void Start()
    {
        buttons = GetComponentsInChildren<RectTransform>();

        // Store the starting position of each button
        startingPositions = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            startingPositions[i] = buttons[i].localPosition;
        }

        // Add listeners to buttons and slider
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void Update()
    {
        // Move each button in a sinusoidal motion
        for (int i = 0; i < buttons.Length; i++)
        {
            Vector3 position = startingPositions[i];
            position.y += amplitude * Mathf.Sin(Time.time * speed + i * frequency);
            buttons[i].localPosition = position;
        }
    }

    void OnPlayButtonClicked()
    {
        // Start the game
        Debug.Log("Starting the game...");
    }

    void OnExitButtonClicked()
    {
        // Quit the application
        Debug.Log("Quitting the application...");
        Application.Quit();
    }

    void OnVolumeChanged(float volume)
    {
        // Change the volume of the audio listener
        AudioListener.volume = volume;
    }
}
