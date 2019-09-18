using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class brickOps : MonoBehaviour
{
    // configuration variables
    [SerializeField] AudioClip brickDestroySound;
    [SerializeField] GameObject brickParticleVFX;
    [SerializeField] Sprite[] hitSprites;

    // fix values
    private string breakableTag = "Breakable";
    private string UnBreakableTag = "Unbreakable";

    // cache component variables
    levelOps lvl;
    gameState state;

    // state variables
    int hitsOfBrick; // Serialize this variable for Debug perpose

    private void Start()
    {
        CountBreakableBricks();
        state = FindObjectOfType<gameState>();
    }

    private void CountBreakableBricks()
    {
        lvl = FindObjectOfType<levelOps>();
        if (tag == breakableTag)
        {
            lvl.CalculateTotalBricks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == breakableTag)
        {
            manageHitsOfBrick();
        }
    }

    private void manageHitsOfBrick()
    {
        hitsOfBrick++;
        int maxHitsOfBrick = hitSprites.Length + 1;
        if (hitsOfBrick >= maxHitsOfBrick)
        {
            NextLevelOnZeroBlock();
        }
        else
        {
            DisplayNextHitImg();
        }
    }

    private void DisplayNextHitImg()
    {
        int imgIndex = hitsOfBrick - 1;
        if (hitSprites[imgIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[imgIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite is missing from array for Game Object : " + gameObject); // or "gameObject.name"
        }
    }

    private void NextLevelOnZeroBlock()
    {
        scoreAndAudio();
        manageDestruction();
        startParticleVFX();
    }

    private void manageDestruction()
    {
        Destroy(gameObject);
        lvl.BlockDestruction();
    }

    private void scoreAndAudio()
    {
        state.addScore();
        AudioSource.PlayClipAtPoint(brickDestroySound, Camera.main.transform.position);
    }

    private void startParticleVFX()
    {
        GameObject particalVFX = Instantiate(brickParticleVFX, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(particalVFX, 3f);
    }
}
