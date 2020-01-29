using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> toEnable;
    public List<GameObject> toDisable;
    private bool canBeTriggered = true;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        if (other.gameObject.tag == "Player" && canBeTriggered)
        {
            //Debug.Log("Entro el player");
            for (int i = 0; i < toEnable.Count; i++)
            {
                toEnable[i].SetActive(true);
            }
            for (int i = 0; i < toDisable.Count; i++)
            {
                toDisable[i].SetActive(false);
            }
            canBeTriggered = false;
        }
    }
}
