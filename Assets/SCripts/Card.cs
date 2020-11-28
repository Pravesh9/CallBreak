using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public int cardNumber;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(Sprite _img)
    {
        //image.sprite = _img;
        GetComponent<Image>().sprite = _img;
    }

}
        
