using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerActivator : MonoBehaviour
{

    public GameObject terraMap;
    public GameObject terraArrow;
    public GameObject terraText;
    public GameObject terraIcon;

    public GameObject cingutarMap;
    public GameObject cingutarArrow;
    public GameObject cingutarText;
    public GameObject cingutarIcon;

    public GameObject solusMap;
    public GameObject solusArrow;
    public GameObject solusText;
    public GameObject solusIcon;

    public GameObject dwarfMap;
    public GameObject dwarfArrow;
    public GameObject dwarfText;
    public GameObject dwarfIcon;

    public GameObject viriosMap;
    public GameObject viriosArrow;
    public GameObject viriosText;
    public GameObject viriosIcon;

    // Update is called once per frame
    void Update()
    {

        if (terraMap.activeSelf)
        {

            terraArrow.SetActive(true);
            terraText.SetActive(true);
            terraIcon.SetActive(true);

        } else
        {

            terraArrow.SetActive(false);
            terraText.SetActive(false);
            terraIcon.SetActive(false);

        }

        if (cingutarMap.activeSelf)
        {

            cingutarArrow.SetActive(true);
            cingutarText.SetActive(true);
            cingutarIcon.SetActive(true);

        } else
        {

            cingutarArrow.SetActive(false);
            cingutarText.SetActive(false);
            cingutarIcon.SetActive(false);

        }

        if (solusMap.activeSelf)
        {

            solusArrow.SetActive(true);
            solusText.SetActive(true);
            solusIcon.SetActive(true);

        }
        else
        {

            solusArrow.SetActive(false);
            solusText.SetActive(false);
            solusIcon.SetActive(false);

        }

        if (dwarfMap.activeSelf)
        {

            dwarfArrow.SetActive(true);
            dwarfText.SetActive(true);
            dwarfIcon.SetActive(true);

        }
        else
        {

            dwarfArrow.SetActive(false);
            dwarfText.SetActive(false);
            dwarfIcon.SetActive(false);

        }

        if (viriosMap.activeSelf)
        {

            viriosArrow.SetActive(true);
            viriosText.SetActive(true);
            viriosIcon.SetActive(true);

        }
        else
        {

            viriosArrow.SetActive(false);
            viriosText.SetActive(false);
            viriosIcon.SetActive(false);

        }

    }
}
