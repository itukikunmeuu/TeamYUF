using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text playerNumText;
    public GameObject playerObj;
    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerObj.GetComponent<PlayerScript>();
        playerNumText.text = playerScript.playerCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerNumText.text = playerScript.playerCount.ToString();
    }
}
