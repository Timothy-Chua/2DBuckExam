using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCoin : Coin
{
    protected override void Collect()
    {
        GameManager.instance.points += 3;
    }
}
