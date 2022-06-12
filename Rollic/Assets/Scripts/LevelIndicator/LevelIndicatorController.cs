using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelIndicatorController : MonoBehaviour
{
    [SerializeField] private Image FirstChallege;
    [SerializeField] private Image SecondChallenge;
    [SerializeField] private TextMeshProUGUI CurrentLevel;
    [SerializeField] private TextMeshProUGUI NextLevel;

    private Color32 passed = new Color32(255, 108, 0, 255);
    private Color32 notPassed = new Color32(255, 255, 255, 255);

    private int turn = 1;

    public void Passed()
    {
        if (turn == 1)
            FirstChallege.color = passed;
        else
            SecondChallenge.color = passed;
        turn++;
    }
    public void ResetLevel()
    {
        turn = 1;
        FirstChallege.color = notPassed;
        SecondChallenge.color = notPassed;
    }
    public void SetLevel(int level)
    {
        level++;
        CurrentLevel.text = level.ToString();
        level++;
        NextLevel.text = level.ToString();
    }
}
