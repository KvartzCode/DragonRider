using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopupTrigger : MonoBehaviour
{
    public int score = 100;
    [SerializeField] GameObject scorePrefab;


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        Play();
    //    }
    //}


    public void Play()
    {
        var spawnPos = transform.position;
        spawnPos.y += (GetComponent<Renderer>().bounds.size.x / 2) + 5;
        var scoreObject = Instantiate(scorePrefab, spawnPos, transform.rotation).GetComponent<ScorePopup>();
        scoreObject.Play(score, transform);
    }
}
