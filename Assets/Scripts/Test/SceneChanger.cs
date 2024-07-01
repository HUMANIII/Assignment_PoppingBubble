using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{    
    void Start()
    {
        GameManager.Instance.gameObject.SetActive(true);
        SceneManager.LoadScene("StageScene");
    }

}
