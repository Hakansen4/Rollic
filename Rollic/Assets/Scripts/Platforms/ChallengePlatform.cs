using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChallengePlatform : BasePlatform
{
    public override PlatformType _PlatformType => PlatformType.Challenge;
    private Transform Door_L;
    private Transform Door_R;

    private PlayerMovement playerMovement;
    private void Awake()
    {
        Door_L = transform.Find("Door_L");
        Door_R = transform.Find("Door_R");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement = other.GetComponentInParent<PlayerMovement>();
            playerMovement.Deactivate();
            other.GetComponentInParent<CollectedBalls>().ThrowBalls();
            GetComponentInChildren<PlatformChallengeController>().StartChallenge();
        }
    }
    public void ChallengePassed()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Door_L.DORotate(new Vector3(180, -90, -90),1);
        Door_R.DORotate(new Vector3(180, 90, 90), 1).OnComplete(() => playerMove());
    }
    private void playerMove()
    {
        playerMovement.Activate();
    }
}
