using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour {
    GameObject image1, image2, image3, image4, image5;
    GameObject winpanel, losepanel;
    public UIManager UIscript;
	// Use this for initialization
	void Start () {
        image1 = GameObject.Find("ImageBox1");
        image2 = GameObject.Find("ImageBox2");
        image3 = GameObject.Find("ImageBox3");
        image4 = GameObject.Find("ImageBox4");
        image5 = GameObject.Find("ImageBox5");

        winpanel = GameObject.Find("WinPanel");
        losepanel = GameObject.Find("LosePanel");
        winpanel.SetActive(false);
        losepanel.SetActive(false);
    }

    public void isWin()
    {
        if (image1.CompareTag(image1.transform.parent.gameObject.tag) &&
            image2.CompareTag(image2.transform.parent.gameObject.tag) &&
            image3.CompareTag(image3.transform.parent.gameObject.tag) &&
            image4.CompareTag(image4.transform.parent.gameObject.tag) &&
            image5.CompareTag(image5.transform.parent.gameObject.tag))
        {
            losepanel.SetActive(false);
            winpanel.SetActive(true);
        }
        else
        {
            winpanel.SetActive(false);
            losepanel.SetActive(true);
        }
           
    }

    public void reset()
    {
        winpanel.SetActive(false);
        losepanel.SetActive(false);

        GameObject images = GameObject.Find("Images");
        image1.transform.SetParent(images.transform);
        image2.transform.SetParent(images.transform);
        image3.transform.SetParent(images.transform);
        image4.transform.SetParent(images.transform);
        image5.transform.SetParent(images.transform);
    }

    public void endGame()
    {
        GameObject ui = GameObject.Find("UIManager");
        UIManager other = (UIManager)ui.GetComponent(typeof(UIManager));
        other.activateObjects();
        GameObject bg = GameObject.Find("Background(Clone)");
        Destroy( bg );
    }

}
