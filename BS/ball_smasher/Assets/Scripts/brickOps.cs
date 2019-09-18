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
    gameState state;

    private void Start()
    {
        lvl = FindObjectOfType<levelOps>();
        lvl.CalculateTotalBreakingBricks();

        state = FindObjectOfType<gameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NextLevelOnZeroBlock();
    }

    private void NextLevelOnZeroBlock()
    {
        state.addScore();
        AudioSource.PlayClipAtPoint(brickDestroySound, Camera.main.transform.position);
        Destroy(gameObject);
        lvl.BlockDestruction();

    }
}
