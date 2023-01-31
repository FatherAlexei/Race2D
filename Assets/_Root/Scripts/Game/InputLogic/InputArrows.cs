using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Game.InputLogic
{
    internal class InputArrows : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 25f;

        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
           UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            Vector3 direction = CalcDirection();
            float moveValue = Speed * _inputMultiplier * Time.deltaTime * direction.x;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else if (sign < 0)
                OnLeftMove(abs);
        }

        private Vector3 CalcDirection()
        {
            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
            return direction;
        }


    }
}
