using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image HPBar, ManaBar;
    [SerializeField] float scaleSpeed = 1.5f;
    private RectTransform rectHP, rectMana;
    private Vector3 targetScaleHPv3, targetScaleManav3;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {

        rectHP = HPBar.GetComponent<RectTransform>();
        rectMana = ManaBar.GetComponent<RectTransform>();
        targetScaleHPv3 = rectHP.localScale;
        targetScaleManav3 = rectMana.localScale;

    }

    private void Update()
    {
        rectHP.localScale = Vector3.Lerp(rectHP.localScale, targetScaleHPv3, scaleSpeed * Time.deltaTime);
        rectMana.localScale = Vector3.Lerp(rectMana.localScale, targetScaleManav3, scaleSpeed * Time.deltaTime);
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
        ManaManager.instance.UpManaRate(0.15f);
    }
}
