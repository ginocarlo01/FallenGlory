using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{

    [SerializeField] private float maxMana;
    [SerializeField] private float actualMana;
    [SerializeField] private float upManaRate;
    public static ManaManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        actualMana += Time.deltaTime * upManaRate;

        float partialMana = actualMana / maxMana;

        UIManager.instance.UpdateMana(partialMana);

        if(actualMana >= maxMana)
        {
            RestartMana();
        }
    }

    public void UpMana(float value)
    {
        actualMana += value;
    }

    private void RestartMana()
    {
        SFXManager.instance.PlaySound(5);
        UIManager.instance.DisableMana();
        UIManager.instance.ShowUpgradeScreen();
        PlayerAttack.instance.EnableSuperAttack();
        actualMana = 0;

    }

}
