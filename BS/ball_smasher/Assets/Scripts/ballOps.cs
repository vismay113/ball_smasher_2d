using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballOps : MonoBehaviour
{
    // configuration variables
    [SerializeField] sliderOps slider_blue;
    [SerializeField] float launch_pos_X = 2f;
    [SerializeField] float launch_pos_y = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // state variables
    Vector2 ballToSliderVector;
    bool hasLaunched = false;

    // cache component variables
    AudioSource ballAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        ballToSliderVector = transform.position - slider_blue.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            lockBallToSlider();
            launchBallFromSlider();
        }
    }

    private void lockBallToSlider()
    {
        Vector2 slider_pos = new Vector2(slider_blue.transform.position.x, slider_blue.transform.position.y);
        transform.position = slider_pos + ballToSliderVector;
    }

    private void launchBallFromSlider()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launch_pos_X, launch_pos_y);
            hasLaunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched)
        {
            AudioClip sound = ballSounds[UnityEngine.Random.Range(0 , ballSounds.Length)];
            ballAudioSource.PlayOneShot(sound);
        }
    }
}
