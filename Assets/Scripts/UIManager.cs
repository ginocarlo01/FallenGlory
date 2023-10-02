using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image HPBar, ManaBar;
    [SerializeField] float scaleSpeed = 1.5f;
    private RectTransform rectHP, rectMana;
    private Vector3 targetScaleHPv3, targetScaleManav3;
    public static UIManager instance;

    [SerializeField] GameObject upgradeScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject swordAttackImage, superAttackImage;
    [SerializeField] TextMeshProUGUI killedEnemiesTxt;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        HideUpgradeScreen();
        HideStartScreen();
        HideInstructions();
        rectHP = HPBar.GetComponent<RectTransform>();
        rectMana = ManaBar.GetComponent<RectTransform>();
        targetScaleHPv3 = rectHP.localScale;
        targetScaleManav3 = rectMana.localScale;

    }

    private void Update()
    {
        rectHP.localScale = Vector3.Lerp(rectHP.localScale, targetScaleHPv3, scaleSpeed * Time.deltaTime);
        rectMana.localScale = Vector3.Lerp(rectMana.localScale, targetScaleManav3, scaleSpeed * Time.deltaTime);
        updateKilledEnemies();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowStartScreen();
        }
    }

    public void UpdateHP(float newHp)
    {
        targetScaleHPv3 = new Vector3(rectHP.localScale.x, newHp, rectHP.localScale.z);
    }

    public void DisableHP()
    {
        HPBar.gameObject.SetActive(false);
    }

    public void UpdateMana(float newMana)
    {
        targetScaleManav3 = new Vector3(rectMana.localScale.x, newMana, rectMana.localScale.z);
    }

    public void DisableMana()
    {
        rectMana.localScale = new Vector3(rectMana.localScale.x, 0, rectMana.localScale.z);
    }

    public void BtnUpMana()
    {
        ManaManager.instance.UpMana(5f);
        HideUpgradeScreen();
    }

    public void BtnUpHP()
    {
        PlayerLife.instance.UpLife(5);
        HideUpgradeScreen();
    }


    public void BtnUpAttackWeapon()
    {
        PlayerAttack.instance.SetWeaponDamage(2f);
        HideUpgradeScreen();
    }

    public void BtnUpAttackSpeed()
    {
        PlayerAttack.instance.SetWeaponSpeed(2f);
        HideUpgradeScreen();
    }

    public void BtnUpAttackRange()
    {
        PlayerAttack.instance.SetWeaponRange(.5f);
        HideUpgradeScreen();
    }

    public void ShowUpgradeScreen()
    {
        upgradeScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void HideUpgradeScreen()
    {
        upgradeScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void SetAttackImage(bool state)
    {
        swordAttackImage.SetActive(state);
    }

    public void SetSuperAttackImage(bool state)
    {
        superAttackImage.SetActive(state);
    }

    private void updateKilledEnemies()
    {
        killedEnemiesTxt.text = EnemyKillManager.instance.GetEnemyCount().ToString();
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void HideStartScreen()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        instructions.SetActive(false);
    }

}
