using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public int cardNumber;
    public Image image;
    public int index;
    public float cardMoveSpeed;

    private Transform initialParent;
    private Transform fakeParent;
    private bool canMoveToTable;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        initialParent = transform.parent;
        fakeParent = initialParent.transform.parent;
        offset = image.rectTransform.sizeDelta.y / 2;
    }

    public void SetImage(Sprite _img)
    {
        //image.sprite = _img;
    }

    public void SetDetails(Sprite _img, int _cardNumber, int _index)
    {
        GetComponent<Image>().sprite = _img;
        cardNumber = _cardNumber;
        index = _index;
    }

    public void MoveToDeckAgain()
    {
        transform.SetParent(initialParent);
        transform.SetSiblingIndex(index);
    }

    public void MoveToTable()
    {
        //transform.GetComponent<RectTransform>().localPosition = Vector2.zero;
        canMoveToTable = true;
    }

    public void SetFakeParent()
    {
        transform.SetParent(fakeParent);

    }

    void Update()
    {
        if (canMoveToTable)
        {
            if (Vector2.Distance(Vector2.zero, transform.GetComponent<RectTransform>().localPosition) > offset)
            {
                transform.GetComponent<RectTransform>().localPosition =
                    Vector2.MoveTowards(transform.GetComponent<RectTransform>().localPosition, Vector2.zero, cardMoveSpeed * Time.deltaTime*100f);
            }
            else
            {
                canMoveToTable = false;
            }

        }

    }

}
        
