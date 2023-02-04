using System;
using UnityEngine;
using JetBrains.Annotations;
using Object = UnityEngine.Object;
using System.Collections;

namespace Features.AbilitySystem.Abilities
{
    internal class JumpAbility : MonoBehaviour,IAbility
    {
        private readonly AbilityItemConfig _config;

        public JumpAbility([NotNull] AbilityItemConfig config) =>
            _config = config ?? throw new ArgumentNullException(nameof(config));


        public void Apply(IAbilityActivator activator)
        {
            Vector3 temp = new Vector3(0, 1, 0);
            GameObject.Find("Car(Clone)").GetComponent<Transform>().position = temp;
            StartCoroutine(CoroutineTest());
            temp = new Vector3(0, 0, 0);
            GameObject.Find("Car(Clone)").GetComponent<Transform>().position = temp;
        }
        private IEnumerator CoroutineTest()
        {
            yield return new WaitForSeconds(5);
        }
    }
}