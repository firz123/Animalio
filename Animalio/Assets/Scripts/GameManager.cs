using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int animalFood;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void changetoActivityScene(int food)
    {
        animalFood = food;
    }

    void returnToMain()
    {
        
    }
}
