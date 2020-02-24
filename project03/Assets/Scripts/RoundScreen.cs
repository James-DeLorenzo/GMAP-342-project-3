using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundScreen : MonoBehaviour
{
    public void NextRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
