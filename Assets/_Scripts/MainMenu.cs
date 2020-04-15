using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public InputField mainInputField;
  public GameObject startText;
  private string Username;

  void Start() {
    Username = PlayerPrefs.GetString("Name", "UNDEFINED");
    if(Username == "UNDEFINED") {
      mainInputField.text = "";
    } else {
      mainInputField.text = Username;
    }
  }

  void Update() {
    if(mainInputField.text.Length > 3) {
      startText.SetActive(true);
      if (Input.GetKeyDown("return")) {
        PlayerPrefs.SetString("Name", mainInputField.text);
        GameController.control.GameStart();
      }
    } else {
      startText.SetActive(false);
    }
  }

}
