using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int ActiveScene;
    private LevelManager lvlManager;
    private LevelData data;
    public List<BasePlatform> activePlatforms;
    public Transform player;

    [Header("Platforms")]
    public BasePlatform StraightPlatform;
    public BasePlatform ChallengePlatform;
    public BasePlatform FinalPlatform;
    private void Awake()
    {
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
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            loadScene();
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
        activePlatforms.RemoveRange(0, activePlatforms.Count);
    }
    public void RestartLevel()
    {
        RemoveAllPlatforms();
        loadScene();
    }
    public void NextLevel()
    {
        ActiveScene++;
        int sceneCount = ActiveScene % 2;
        data = lvlManager.GetLevel(sceneCount);
        RemoveAllPlatforms();
        loadScene();
    }
}
