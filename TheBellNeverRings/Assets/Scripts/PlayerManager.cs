using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private GameObject activePlayer;
    private CamMovement cam;

    void Start()
    {
        activePlayer = player1;
        SetActiveControl(player1, true);
        SetActiveControl(player2, false);

        cam = FindObjectOfType<CamMovement>();
        cam.target = activePlayer.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C pressed!");
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        SetActiveControl(activePlayer, false);

        if (activePlayer == player1)
            activePlayer = player2;
        else
            activePlayer = player1;

        SetActiveControl(activePlayer, true);

        cam.target = activePlayer.transform;

        Debug.Log($"Switched to {activePlayer.name}");
    }

    void SetActiveControl(GameObject player, bool isActive)
    {
        player.GetComponent<PlayerMovementScript>().enabled = isActive;

        foreach (WeaponController weapon in player.GetComponentsInChildren<WeaponController>())
        {
            weapon.enabled = isActive;
        }

        Camera playerCam = player.GetComponentInChildren<Camera>();
        if (playerCam != null) playerCam.enabled = isActive;

        AudioListener listener = player.GetComponentInChildren<AudioListener>();
        if (listener != null) listener.enabled = isActive;
    }
}
