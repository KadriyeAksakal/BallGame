using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    public int controlFlag;

   public void Load(int index )
    {
        PlayerPrefs.SetInt("index", index); // il sayfayı index olarak açmıştım yani sahneleri göndermek için
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }


}
