using UnityEngine;

public class WasLevelCompleted : MonoBehaviour
{
    public GameObject westernCanvas, sentaiCanvas, noirCanvas;

    void Awake()
    {
        if (GameManagment.westernHat == true)
        {
            westernCanvas.SetActive(true);
        }

        if (GameManagment.sentaiHat == true)
        {
            sentaiCanvas.SetActive(true);
        }

        if (GameManagment.noirHat == true)
        {
            noirCanvas.SetActive(true);
        }
    }
}
