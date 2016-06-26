using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject[] animals;
    public AudioClip clip; 
    public AudioSource soundSource; 

    public void makeAnimals()
    {
        foreach (GameObject ele in animals)
        {
            Instantiate(ele); 
        }
    }
    public void PlaySingle()
    {
        soundSource.clip = clip;
        soundSource.Play();
    }
}
