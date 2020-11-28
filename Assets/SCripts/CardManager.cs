using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Sprite> AllCardImage;
    public List<List<int>> AllPlayersCard = new List<List<int>>();
    public GameObject CardPrefab;
    public Transform CardParent;

    private List<GameObject> AllCardGameObject;
    // Start is called before the first frame update
    void Start()
    {

        SetAllPlayerCards();
        AllCardGameObject = new List<GameObject>();
        for (int i = 0; i < 13; i++)
        {
            GameObject obj = Instantiate(CardPrefab);
            obj.transform.SetParent(CardParent);
            obj.name = "Card_" + i.ToString();
            obj.transform.localScale = Vector3.one;
            AllCardGameObject.Add(obj);
        }

        for (int i = 0; i < AllPlayersCard[0].Count; i++)
        {
            AllCardGameObject[i].GetComponent<Card>().cardNumber = AllPlayersCard[0][i];

            AllCardGameObject[i].GetComponent<Card>().SetImage(GetImageAsPerCardNumber(AllPlayersCard[0][i]));
            


        }


        PrintAllPlayerCards();
    }

    private Sprite GetImageAsPerCardNumber(int _val)
    {
        return  AllCardImage[_val-1];
    }

        


    private void SetAllPlayerCards()
    {
        CardDealer cardDealer = new CardDealer();
        List<int> playerscardlist = cardDealer.GetTheAllPlayersCard();

        AllPlayersCard.Add(new List<int>());
        for (int i = 0; i < playerscardlist.Count; i++)
        {
            DebugManager.Log(i + " " + playerscardlist[i]);
            //int value = playerscardlist[i] % 13 != 0 ? playerscardlist[i] % 13 : 1;
            int value = playerscardlist[i];
            AllPlayersCard[AllPlayersCard.Count - 1].Add(value);

            if ((i + 1) % 13 == 0)
            {
                AllPlayersCard.Add(new List<int>());
            }
        }
    }

    private void PrintAllPlayerCards()
    {
        Color[] _playercolor = new Color[] { Color.red, Color.yellow, Color.blue, Color.green, Color.cyan };
        for (int i = 0; i < AllPlayersCard.Count; i++)
        {
            for (int j = 0; j < AllPlayersCard[i].Count; j++)
            {
                DebugManager.LogWithColor($"[{i}][{j}] {AllPlayersCard[i][j]}", _playercolor[i]);

            }
        }
    }



}


