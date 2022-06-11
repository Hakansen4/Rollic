using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    private Rigidbody physic;
    private void Awake()
    {
        physic = GetComponent<Rigidbody>();
    }
    public void SetActive(bool active)
    {
        if (active)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void Throw()
    {
        physic.DOMoveZ(transform.position.z + 4f, 1f);
    }
}
