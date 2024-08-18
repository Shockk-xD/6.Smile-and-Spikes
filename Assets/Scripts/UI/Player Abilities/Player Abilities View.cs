using System;
using UnityEngine;

public class PlayerAbilitiesView : MonoBehaviour
{
    [SerializeField] private GameObject _coinAttractionView;
    [SerializeField] private GameObject _playerShieldView;

    public void Show<T>(float lifeTime) where T: MonoBehaviour {
        RechargableAbilityView rechargableAbility;

        if (IsExist<T>()) {
            var uiType = ConvertAbilityToUI(typeof(T));
            var ability = GetComponentInChildren(uiType);
            rechargableAbility = ability.GetComponent<RechargableAbilityView>();
        } else {
            var abilityPrefab = GetAbility(typeof(T));
            rechargableAbility = Instantiate(abilityPrefab, transform).
                GetComponent<RechargableAbilityView>();
        }

        if (rechargableAbility) {
            rechargableAbility.SetTimer(lifeTime);
        }
    }

    private bool IsExist<T>() where T: MonoBehaviour {
        var uiType = ConvertAbilityToUI(typeof(T));
        return GetComponentInChildren(uiType) != null;
    }

    private Type ConvertAbilityToUI(Type abilityType) {
        if (abilityType == typeof(CoinAttractionAbility))
            return typeof(CoinAttractionAbilityView);
        if (abilityType == typeof(PlayerShield))
            return typeof(PlayerShieldView);

        return null;
    }

    private GameObject GetAbility(Type type) {
        if (type == typeof(CoinAttractionAbility))
            return _coinAttractionView;
        if (type == typeof(PlayerShield))
            return _playerShieldView;

        return null;
    }
}
