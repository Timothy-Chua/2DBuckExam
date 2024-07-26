using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCoin : Coin
{
    protected override void Collect()
    {
        GameManager.instance.points += 5;
    }
}
