using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOps : MonoBehaviour
{
    // configuration variables
    [SerializeField] int totalBreakingBricks; // Serialized for debugging.

    // cache components variables
    ScenePlayer sceneOps;

    public void CalculateTotalBreakingBricks()
    {
        totalBreakingBricks++;
    }

    public void BlockDestruction()
    {
        totalBreakingBricks--;

        if (totalBreakingBricks <= 0)
        {
            sceneOps.sceneLoader();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneOps = FindObjectOfType<ScenePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
