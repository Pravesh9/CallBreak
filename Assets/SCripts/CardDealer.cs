using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CardDealer
{

    public List<int> GetTheAllPlayersCard()
    {
        List<int> AllCard = new List<int>();
        for (int i = 0; i < 52; i++)
        {
            AllCard.Add(i + 1);
        }


        return AllCard.ShuffleList();
    }

    
}
