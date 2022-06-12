using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int ActiveScene;
    public LevelIndicatorController levelIndicator;
    private LevelManager lvlManager;
    private LevelData data;
    public List<BasePlatform> activePlatforms;
    public List<GameObject> activeBalls;
    public Transform player;
    private Saveobjects Save;

    [Header("Platforms")]
    public BasePlatform StraightPlatform;
    public BasePlatform ChallengePlatform;
    public BasePlatform FinalPlatform;

    [Header("Balls")]
    public GameObject StraightBall;
    public GameObject ArrowHeadBalls;
    private void Start()
    {
        Save = SaveManager.Load();
        ActiveScene = Save.Level;
        levelIndicator.SetLevel(ActiveScene);
        lvlManager = GetComponent<LevelManager>();
        data = lvlManager.GetLevel(ActiveScene);
        loadScene();
    }
    public void loadScene()
    {
        var platforms = data.Platforms;
        player.position = new Vector3(0, 0.6f,-5);
        foreach (var item in platforms)
        {
            var platform = ReturnPlatform(item.Type);
            platform = Instantiate(platform, transform);
            platform.transform.position = item.Position;
            activePlatforms.Add(platform);
            var challenge = platform.GetComponentInChildren<PlatformChallengeController>();
            if(challenge != null)
            {
                challenge.SetChallenceCount(item.ChallenceCount);
            }
        }
        var balls = data.Balls;
        foreach (var item in balls)
        {
            var ball = returnBall(item.Type);
            ball = Instantiate(ball, transform);
            ball.transform.position = item.Position;
            activeBalls.Add(ball);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            loadScene();
        }
    }
    private GameObject returnBall(BallsType type)
    {
        switch (type)
        {
            case BallsType.Straight:
                return StraightBall;
                break;
            case BallsType.ArrowHead:
                return ArrowHeadBalls;
                break;
            default:
                return null;
                break;
        }
    }
    private BasePlatform ReturnPlatform(PlatformType type)
    {
        switch (type)
        {
            case PlatformType.Challenge:
                return ChallengePlatform;
                break;
            case PlatformType.Straight:
                return StraightPlatform;
                break;
            case PlatformType.Final:
                return FinalPlatform;
                break;
            default:
                Debug.Log("Platform couldnt found");
                return null;
                break;
        }
    }
    public void RemoveAllPlatforms()
    {
        foreach (var item in activePlatforms)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in activeBalls)
        {
            Destroy(item);
        }
        activeBalls.RemoveRange(0, activeBalls.Count);
        activePlatforms.RemoveRange(0, activePlatforms.Count);
    }
    public void RestartLevel()
    {
        levelIndicator.ResetLevel();
        RemoveAllPlatforms();
        loadScene();
    }
    public void NextLevel()
    {
        ActiveScene++;
        Save.Level = ActiveScene;
        SaveManager.Save(Save);
        levelIndicator.ResetLevel();
        levelIndicator.SetLevel(ActiveScene);
        int sceneCount = ActiveScene % 2;
        data = lvlManager.GetLevel(sceneCount);
        RemoveAllPlatforms();
        loadScene();
    }
}