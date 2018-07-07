using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextLine : MonoBehaviour {
    public InputField line;
    public Button ok;
    public static string nickname;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        line.onValueChange.AddListener(delegate { ChangeText(); });
        ok.onClick.AddListener(JoinLobby);
    }

    void JoinLobby()
    {
        if (nickname.Length > 0)
        {  
            SceneManager.LoadScene("Hub"); 
        }
    }

    public void ChangeText()
    {
        nickname = line.text;
    }

    public string getNick()
    {
        return nickname;
    }
}
