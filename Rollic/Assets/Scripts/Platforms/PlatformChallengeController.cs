using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlatformChallengeController : MonoBehaviour
{
    private ChallengePlatform chPlatform;
    private int ballCount;
    private int challengeCount;
    public TextMeshProUGUI _text;
    public Material _groundColor;

    private GameObject failedScreen;
    private LevelIndicatorController levelIndicator;
    bool challengeStarted;
    bool challengeFinished;
    float timer;
    float challengeTime;

    private void Awake()
    {
        chPlatform = GetComponentInParent<ChallengePlatform>();
        failedScreen = GameObject.FindGameObjectWithTag("FailedScreen");
        levelIndicator = GameObject.FindGameObjectWithTag("LevelIndicator").GetComponent<LevelIndicatorController>();
        challengeStarted = false;
        challengeFinished = false;
        timer = 0;
        challengeTime = 4.0f;
        ballCount = 0;
    }
    private void Start()
    {
        failedScreen.SetActive(false);
        WriteText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            ballCount++;
            WriteText();
            collision.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if(challengeStarted)
        {
            Challenge();
        }    
    }
    public void SetChallenceCount(int count)
    {
        challengeCount = count;
    }
    private void WriteText()
    {
        _text.text = ballCount + " / " + challengeCount; 
    }
    public void StartChallenge()
    {
        if (!challengeStarted)
        {
            challengeStarted = true;
            timer = Time.time;
        }
    }
    private void Challenge()
    {
        if(Time.time - timer > challengeTime    &&  !challengeFinished)
        {
            challengeFinished = true;
            if (ballCount >= challengeCount)
                Passed();
            else
                Failed();
        }
    }
    private void Passed()
    {
        transform.DOMove(transform.position + Vector3.up, 1);
        _text.gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material = _groundColor;
        chPlatform.ChallengePassed();
        levelIndicator.Passed();
    }
    private void Failed()
    {
        failedScreen.SetActive(true);
    }
}
