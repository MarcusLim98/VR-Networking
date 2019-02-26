using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SavingName : MonoBehaviour
{
    public Text playerName;
    public string nameOfPlayer;
    public bool attachedToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        nameOfPlayer = PlayerPrefs.GetString("Name", nameOfPlayer);
        PhotonNetwork.playerName = nameOfPlayer;
        playerName.text = PhotonNetwork.playerName;
        if (attachedToPlayer)
        {
            GetComponent<SavingName>().enabled = false;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("NetworkScene");
        }
        if (!attachedToPlayer)
        {
            nameOfPlayer = playerName.text;
        }
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("Name", nameOfPlayer) ;
        PlayerPrefs.Save();
    }
}
