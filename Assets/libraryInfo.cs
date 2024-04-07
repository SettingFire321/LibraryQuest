using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class libraryInfo : MonoBehaviour
{
    public TextMeshProUGUI libraryName;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < GameManager.libraryNames.Count; i++)
        {
            Debug.Log(GameManager.libraryNames.GetKey(i));
        }
        libraryName.text = "AAAAAAAA";
    }

    
}
