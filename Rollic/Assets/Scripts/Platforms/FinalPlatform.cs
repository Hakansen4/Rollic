using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : BasePlatform
{
    public override PlatformType _PlatformType => PlatformType.Final;
    private GameObject CompletedScreen;
    private void Start()
    {
        CompletedScreen = GameObject.FindGameObjectWithTag("CompletedScreen");
        CompletedScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerMovement>().Deactivate();
            CompletedScreen.SetActive(true);
        }
    }
}
