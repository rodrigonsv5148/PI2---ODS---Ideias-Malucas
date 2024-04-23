using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeiras : MonoBehaviour
{
    static public bool NPCaqui = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            NPCaqui = true;
            print("NPC sentou");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            NPCaqui = false;
            print("NPC saiu");
        }
    }
}
