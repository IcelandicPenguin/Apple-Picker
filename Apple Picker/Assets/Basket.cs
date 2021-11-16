using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]

    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        //Find a refrence to the ScoreCOunter GameObject
        GameObject scoreGo = GameObject.Find("ScoreCounter");

        //Get the Text Component of the GameObject
        scoreGT = scoreGo.GetComponent<Text>();

        //Set the starting number of the points to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The camer z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point of from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this basket to the x postion of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }

        //Parse the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);

        //ADD points for catching the apple
        score += 100;

        //Convert the score back to a string and display it
        scoreGT.text = score.ToString();

       //Track the high score
       if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}