using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderOps : MonoBehaviour
{
    [SerializeField] float screenWInUnits = 16f;
    [SerializeField] float minScreenX = 1.3f;
    [SerializeField] float maxScreenX = 14.7f;

    // cache variables
    ballOps ball;
    gameState gs;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<ballOps>();
        gs = FindObjectOfType<gameState>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sliderPos = new Vector2(transform.position.x , transform.position.y);
        sliderPos.x = Mathf.Clamp(getXPos(), minScreenX, maxScreenX);
        transform.position = sliderPos;
    }

    private float getXPos()
    {
        if (gs.autoplaySwitch())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWInUnits;
        }
    }
}

// notes

// Debug.Log("mouse Position " + Input.mousePosition + " X : " + Input.mousePosition.x + " Y : " + Input.mousePosition.y + " Z : " + Input.mousePosition.z);
// Debug.Log("Screen Width : " + Screen.width + " Height : " + Screen.height);
//Debug.Log(Input.mousePosition.x / Screen.width * screenWInUnits); // mouse mosition in units with screen aspect ration
