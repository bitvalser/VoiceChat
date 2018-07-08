using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class TouchRace : MonoBehaviour
{

    public bool isRacePressed = false;
    public bool isbrakePressed = false;
    public Button btnVoice;
    public GameObject startVoice;
    public GameObject endVoice;
    public Sprite NoVoice;
    public Sprite Voice;

    void Start()
    {

    }

    void Update()
    {
        if (isRacePressed || Input.GetKey(KeyCode.Space))
        {
            btnVoice.image.sprite = Voice;
            if(Input.GetKeyDown(KeyCode.Space)) Destroy(Instantiate(startVoice, Vector3.zero, Quaternion.identity), 0.5f);
        }

        else if (!isRacePressed)
        {
            btnVoice.image.sprite = NoVoice;
            if (Input.GetKeyUp(KeyCode.Space)) Destroy(Instantiate(endVoice, Vector3.zero, Quaternion.identity), 0.5f);
        }
    }
    public void onPointerDownRaceButton()
    {
        isRacePressed = true;
        btnVoice.image.sprite = Voice;
        Destroy(Instantiate(startVoice, Vector3.zero, Quaternion.identity), 0.5f);
    }
    public void onPointerUpRaceButton()
    {
        isRacePressed = false;
        btnVoice.image.sprite = NoVoice;
        Destroy(Instantiate(endVoice, Vector3.zero, Quaternion.identity), 0.5f);
    }
}
