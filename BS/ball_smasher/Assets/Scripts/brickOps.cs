using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class brickOps : MonoBehaviour
{
    // configuration variables
    [SerializeField] AudioClip brickDestroySound;

    // cache component variables
    levelOps lvl;

    private void Start()
    {
        lvl = FindObjectOfType<levelOps>();
        lvl.CalculateTotalBreakingBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(brickDestroySound, Camera.main.transform.position);
        lvl.DecreseTotalBreakingBricks();
        Destroy(gameObject);
    }
}
