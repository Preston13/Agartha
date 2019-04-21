using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Transform POI;
    public int radius = 50;
    public Button StartButton;
    public Button QuitButton;
    public Button MeleeButton;
    public Button RangedButton;
    public Text ClassText;
    public Scene startScene;

    public float increaseRate = 0.001f;
    private float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(POI.position.x, POI.position.y - 50, POI.position.z);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(POI.position.x + (radius * Mathf.Sin(i)), POI.position.y - 50, POI.position.z + (radius * Mathf.Cos(i)));
        Vector3 target = transform.position - POI.position;
        transform.rotation = Quaternion.LookRotation(target, Vector3.up);
        i += increaseRate;
    }

    public void SelectClass()
    {
        StartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        MeleeButton.gameObject.SetActive(true);
        RangedButton.gameObject.SetActive(true);
        ClassText.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void selectType(string type)
    {
        switch (type)
        {
            case "Melee":
                PlayerPrefs.SetString("BaseType", "Melee");
                break;
            case "Ranged":
                PlayerPrefs.SetString("BaseType", "Ranged");
                break;
        }

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
