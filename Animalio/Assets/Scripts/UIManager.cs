using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
    GameObject playbtn;
    GameObject talkbtn;
    GameObject feedbtn;
    GameObject mySliderObject;
    GameObject sliderFillHolder;
    GameObject textObject; 

    GameObject[] myMenu;

    public LayerMask animals;

    Text text; 
    Image sliderFill;
    Slider slider;

    public Color green;
    public Color orange;
    public Color red;

    public StringBank stringbank; 
    private AnimalScript activeAnimal;
    private GameObject activeObject;

    private bool isMenuOpen = false; 

	// Use this for initialization
	void Start () {
        playbtn = GameObject.Find("PlayBtn");
        talkbtn = GameObject.Find("TalkBtn");
        feedbtn = GameObject.Find("FeedBtn");
        mySliderObject = GameObject.Find("Slider");
        sliderFillHolder = GameObject.Find("myFill");
        textObject = GameObject.Find("dialogueText");

        if (GameObject.Find("Panel").activeInHierarchy == true)
        {
            slider = mySliderObject.GetComponent<Slider>();
            sliderFill = sliderFillHolder.GetComponent<Image>();
            text = textObject.GetComponent<Text>();

        }

        myMenu = new GameObject[] { playbtn, talkbtn, feedbtn, mySliderObject };

        for (int i = 0; i < myMenu.Length; i++)
        {
            myMenu[i].SetActive(false); 
        }

        textObject.SetActive(false); 

        sliderFill.color = green; 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (onAnimal())
            {
                activeAnimal.amIClicked = true; 
                menuMaker(isMenuOpen);
            }
        }

        if (activeAnimal != null)
        {
            slider.value = activeAnimal.myFood;
            if (activeAnimal.myFood <= 100)
            {
                sliderFill.color = green;
                if (activeAnimal.myFood <= 50)
                {
                    sliderFill.color = orange;
                    if (activeAnimal.myFood <= 30)
                    {
                        sliderFill.color = red;
                    }
                }
            }
        }

	}

    void menuMaker(bool openStatus)
    {
        if (openStatus == false)
        {
            for (int i = 0; i < myMenu.Length; i++)
            {
                myMenu[i].SetActive(true);
            }

            isMenuOpen = true;
        }
        else
        {
            for (int i = 0; i < myMenu.Length; i++)
            {
                myMenu[i].SetActive(false);
            }
            isMenuOpen = false;
            //activeAnimal = null; 
        
        }
    }

    public void buttonClicked(int btnID)
    {
        switch (btnID)
        {
            case 0:
            playAnimal();
            break; 
            case 1:
            feedAnimal();
            break;
            case 2:
            talkAnimal();
            break;
        }
    
    }


    bool onAnimal()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 50f, animals);
        if (hit)
        {
            activeObject = hit.collider.gameObject;
            activeAnimal = activeObject.GetComponent<AnimalScript>();

            return true;
        }
        else
        {
            return false;
        }
    }

    void feedAnimal()
    {
        activeAnimal.myFood += 20; 

    }
    void talkAnimal()
    {
        menuMaker(isMenuOpen); 
        textObject.SetActive(true); 
        text.supportRichText = true; 
        text.text = StringBank.TIGER_01; 

    }

    void playAnimal()
    {
        deactivateObjects();
        loadFoodWebGame();
    }

    void loadFoodWebGame()
    {

    }

    void deactivateObjects()
    {
        for(int i = 0; i < myMenu.Length; i++)
        {
            myMenu[i].SetActive(false);
        }
        activeObject.SetActive(false);
        textObject.SetActive(false);
    }

    void activateObjects()
    {
        for (int i = 0; i < myMenu.Length; i++)
        {
            myMenu[i].SetActive(true);
        }
        activeObject.SetActive(true);
        textObject.SetActive(true);
    }
}
