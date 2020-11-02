using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRelevantButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.RaiseEvent("ButtonCreation");
    }


}
