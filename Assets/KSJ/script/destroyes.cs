using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyes : MonoBehaviour
{
    public GameObject players;
    public bool doors = false;
    // Start is called before the first frame update
    
    private void destroyed()
    {
        if(this.gameObject.name== "SkeletonPBR")
            players.SendMessage("monster1");
        if (this.gameObject.name == "SkeletonPBR (1)")
            players.SendMessage("monster2");
        if (this.gameObject.name == "SkeletonPBR (2)")
            players.SendMessage("monster3");
    }
}
