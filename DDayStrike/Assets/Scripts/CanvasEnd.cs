using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasEnd : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public GameObject Skip;
    public Button actionButton;
    public float fadeInDuration = 40.0f;
    public float growDuration = 40.0f;
    public float targetScale = 2.0f;
    public float titleDelay = 10.0f; // Delay for title appearance in seconds
    public float buttonDelay = 40.0f; // Delay for button appearance in seconds

    private bool isSkipping = false;

    void Start()
    {
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0f);
        titleText.transform.localScale = Vector3.zero;
        actionButton.gameObject.SetActive(false);

        Invoke("StartTitleAnimation", titleDelay); // Delay before starting title animation
        Invoke("ActivateButton", titleDelay + buttonDelay); // Activate button after total animation duration + delay
    }

    void Update()
    {
        // Check for skip input
        if (Input.GetKeyDown(KeyCode.V))
        {
            Skip.SetActive(false);
            isSkipping = true;
            // Skip both title and button animations instantly
            SkipAnimations();
        }
    }

    void StartTitleAnimation()
    {
        InvokeRepeating("TitleAnimationStep", 0f, 0.1f); // Invoke the title animation step every 0.1 seconds
    }

    void TitleAnimationStep()
    {
        if (!isSkipping)
        {
            float alpha = Mathf.Clamp01(Time.time / fadeInDuration);
            titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, alpha);

            float scale = Mathf.Lerp(0f, targetScale, Time.time / growDuration);
            titleText.transform.localScale = new Vector3(scale, scale, 1f);

            if (alpha >= 1f)
            {
                CancelInvoke("TitleAnimationStep"); // Stop the repeating invocation
            }
        }
    }

    void SkipAnimations()
    {
        // Skip both title and button animations instantly
        CancelInvoke("TitleAnimationStep");
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 1f);
        titleText.transform.localScale = new Vector3(targetScale, targetScale, 1f);
        ActivateButton(); // Activate the button immediately
    }

    void ActivateButton()
    {
        actionButton.gameObject.SetActive(true);
    }

}
