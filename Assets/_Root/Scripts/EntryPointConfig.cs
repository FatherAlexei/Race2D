using Profile;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(EntryPointConfig), menuName = "Configs/" + nameof(EntryPointConfig))]
internal class EntryPointConfig : ScriptableObject
{
    [field: SerializeField] public float speedCar { get; private set; }
    [field: SerializeField] public GameState initialState { get; private set; }
}