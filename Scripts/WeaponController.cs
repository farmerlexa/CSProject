using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    int currentWeaponIndex = 0;
    public WeaponStat currentWeaponStats;
    [SerializeField] RectTransform weaponDisplay_P;
    Image[] weaponDisplays = new Image[5];
    PlayerController player;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            weaponDisplays[i] = weaponDisplay_P.GetChild(i).GetComponent<Image>();
        }

        player = GetComponentInParent<PlayerController>();

        SwitchWeapon();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.E) && !player.build.isBuilding)
        {
            if (currentWeaponIndex >= transform.childCount - 1)
                currentWeaponIndex = 0;
            else
                currentWeaponIndex++;

            SwitchWeapon();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && !player.build.isBuilding)
        {
            if (currentWeaponIndex <= 0)
                currentWeaponIndex = transform.childCount - 1;
            else
                currentWeaponIndex--;

            SwitchWeapon();
        }

        weaponDisplays[currentWeaponIndex].GetComponentInChildren<TextMeshProUGUI>().text = currentWeaponStats.ammo.ToString();
    }

    void SwitchWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
                currentWeaponStats = weapon.gameObject.GetComponent<WeaponStat>();
                weaponDisplays[i].GetComponent<RectTransform>().localPosition = new Vector2(weaponDisplays[i].GetComponent<RectTransform>().localPosition.x, 7);
            }
            else
            {
                weapon.gameObject.SetActive(false);
                weaponDisplays[i].GetComponent<RectTransform>().localPosition = new Vector2(weaponDisplays[i].GetComponent<RectTransform>().localPosition.x, 0);
            }

            //if (weapon.GetComponent<WeaponStat>().Name != "Axe")
            //{
                weaponDisplays[i].gameObject.SetActive(true);
                weaponDisplays[i].transform.GetChild(0).GetComponent<Image>().sprite = weapon.GetComponent<WeaponStat>().img;
                //weaponDisplays[i].GetComponentInChildren<TextMeshProUGUI>().text = currentWeaponStats.ammo.ToString();

                i++;
            //}
        }

    }

    public void Equip()
    {
        if (transform.childCount < 5)
        {

        }
        else
        {

        }
    }
}
