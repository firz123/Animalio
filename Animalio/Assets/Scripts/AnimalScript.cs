using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimalScript : MonoBehaviour {

    public float myFood;
    public float foodDecrement;
    public float foodDecTimeValue;
    private float foodDecTime; 

    public float X;
    public float Y;
    public float Width = 150;
    public bool amIClicked = false; 

    private Animator animator;
    float randTime;

    

	// Use this for initialization
	void Start () {
        updateXY();
        animator = GetComponent<Animator>();
        randTime = Random.Range(1, 10);
        foodDecTime = foodDecTimeValue;
        
	}
	
	// Update is called once per frame
	void Update () {
            if (amIClicked == true)
            {
                amIClicked = false; 
                animator.SetTrigger("Click");
                updateXY();
                
            }

            randTime -= Time.deltaTime;

            if (this.tag == "Tiger")
            {
                if (randTime < 0)
                {
                    animator.SetTrigger("RandomMov");
                    randTime = Random.Range(1, 10);
                }

            }

            foodDecTime -= Time.deltaTime;

            if (foodDecTime <= 0)
            {
                myFood -= foodDecrement;
                foodDecTime = foodDecTimeValue;
            }
	}

    void updateXY()
    {
        X = this.transform.position.x * 60;
        Y = this.transform.position.y * 60;
    
    }



}
