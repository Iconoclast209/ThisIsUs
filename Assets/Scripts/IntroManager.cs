using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {
    public string[] jennyStringArray;
    public string[] anthonyStringArray;
    public GameObject jennyChatBubble;
    public GameObject anthonyChatBubble;
    public Text jennyText;
    public Text anthonyText;
    public Button continueButton;
    public int clickCount=0;

    private RectTransform continueButtonRT;

    // Use this for initialization
    void Start () {
        jennyText.text = "";
        anthonyText.text = "";
        jennyChatBubble.SetActive(false);
        anthonyChatBubble.SetActive(false);
        continueButton.enabled = false;
        continueButtonRT = continueButton.GetComponent<RectTransform>();
}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
	}

    public void HandleClick()
    {
        clickCount++;
        print("Click number " + clickCount.ToString());
        if(clickCount == 1)
        {
            jennyChatBubble.SetActive(true);
            jennyText.text = jennyStringArray[0];
        }
        else if (clickCount == 2)
        {
            anthonyChatBubble.SetActive(true);
            anthonyText.text = anthonyStringArray[0];
        }
        else if (clickCount == 3)
        {
            jennyText.text = jennyStringArray[1];
        }
        else if (clickCount == 4)
        {
            anthonyText.text = anthonyStringArray[1];
        }
        else if (clickCount == 5)
        {
            jennyText.text = jennyStringArray[2];
        }
        else if (clickCount == 6)
        {
            anthonyText.text = anthonyStringArray[2];
        }
        else if (clickCount == 7)
        {
            jennyText.text = jennyStringArray[3];
            continueButton.enabled = true;
            continueButtonRT.anchoredPosition = new Vector3(0,-300,0);
        }

    }

}
