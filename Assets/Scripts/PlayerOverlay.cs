using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOverlay : MonoBehaviour
{

    public GameObject[] players; // player 1 - 4
    public string[] playerNames;
    public Text[] playerNameText;
    public Text[] damageProtectionText;

    private PlayerSpecifics playerVisualScript1;
    private PlayerSpecifics playerVisualScript2;
    private PlayerSpecifics playerVisualScript3;
    private PlayerSpecifics playerVisualScript4;

    private PlayerController playerController1;
    private PlayerController playerController2;
    private PlayerController playerController3;
    private PlayerController playerController4;

    [Header("Player 1")]
    private float p1PushBackBase;
    private float p1TeleportBase;
    public Image p1PushBackImage;
    public Image p1TeleportImage;

    [Header("Player 2")]
    private float p2PushBackBase;
    private float p2TeleportBase;
    public Image p2PushBackImage;
    public Image p2TeleportImage;

    [Header("Player 3")]
    private float p3PushBackBase;
    private float p3TeleportBase;
    public Image p3PushBackImage;
    public Image p3TeleportImage;

    [Header("Player 4")]
    private float p4PushBackBase;
    private float p4TeleportBase;
    public Image p4PushBackImage;
    public Image p4TeleportImage;

    // Start is called before the first frame update
    void Start()
    {
        

        if(players[0].activeInHierarchy != null)
        {
            playerVisualScript1 = players[0].GetComponent<PlayerSpecifics>();
            playerController1 = players[0].GetComponent<PlayerController>();
            playerNameText[0].text = playerVisualScript1.playerName;
            p1PushBackBase = playerController1.basePushBackCooldown;
            p1TeleportBase = playerController1.baseDashCoolDown;
        }

        if (players[1].activeInHierarchy != null)
        {
            playerVisualScript2 = players[1].GetComponent<PlayerSpecifics>();
            playerController2 = players[1].GetComponent<PlayerController>();
            playerNameText[1].text = playerVisualScript2.playerName;
            p2PushBackBase = playerController2.basePushBackCooldown;
            p2TeleportBase = playerController2.baseDashCoolDown;
        }

        if (players[2].activeInHierarchy != null)
        {
            playerVisualScript3 = players[2].GetComponent<PlayerSpecifics>();
            playerController3 = players[2].GetComponent<PlayerController>();
            playerNameText[2].text = playerVisualScript3.playerName;
            p3PushBackBase = playerController3.basePushBackCooldown;
            p3TeleportBase = playerController3.baseDashCoolDown;
        }

        if (players[3].activeInHierarchy != null)
        {
            playerVisualScript4 = players[3].GetComponent<PlayerSpecifics>();
            playerController4 = players[3].GetComponent<PlayerController>();
            playerNameText[3].text = playerVisualScript4.playerName;
            p4PushBackBase = playerController4.basePushBackCooldown;
            p4TeleportBase = playerController4.baseDashCoolDown;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].activeInHierarchy != null)
        {
            damageProtectionText[0].text = playerController1.damageProtection.ToString("f0");
            p1PushBackImage.fillAmount = (playerController1.pushBackCooldown / p1PushBackBase);
            p1TeleportImage.fillAmount = (playerController1.dashCooldown / p1TeleportBase);
        }

        if (players[1].activeInHierarchy != null)
        {
            damageProtectionText[1].text = playerController2.damageProtection.ToString("f0");
            p2PushBackImage.fillAmount = (playerController2.pushBackCooldown / p2PushBackBase);
            p2TeleportImage.fillAmount = (playerController2.dashCooldown / p2TeleportBase);
        }

        if (players[2].activeInHierarchy != null)
        {
            damageProtectionText[2].text = playerController3.damageProtection.ToString("f0");
            p3PushBackImage.fillAmount = (playerController3.pushBackCooldown / p3PushBackBase);
            p3TeleportImage.fillAmount = (playerController3.dashCooldown / p3TeleportBase);
        }

        if (players[3].activeInHierarchy != null)
        {
            damageProtectionText[3].text = playerController4.damageProtection.ToString("f0");
            p4PushBackImage.fillAmount = (playerController4.pushBackCooldown / p4PushBackBase);
            p4TeleportImage.fillAmount = (playerController4.dashCooldown / p4TeleportBase);
        }
    }
}
