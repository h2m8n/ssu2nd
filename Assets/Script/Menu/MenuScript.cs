using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
       //SceneManager.GetActiveScene().buildIndex + 1
    }

    public void HowToPlay(){
        SceneManager.LoadScene("HowToPlay");
       //SceneManager.GetActiveScene().buildIndex + 2
    }

        public void X(){
        SceneManager.LoadScene("MenuScene");
    }

         public void Retry(){
        SceneManager.LoadScene("SampleScene");
    }



    public void ExitGame() {
        Application.Quit();
    }
}
