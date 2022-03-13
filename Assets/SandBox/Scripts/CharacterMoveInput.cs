using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

// namespace SandBox.Scripts
// {
public class CharacterMoveInput : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Mover mover;
    [SerializeField] private Jumper jumper;
    [SerializeField] private AudioClip jumpSound;


    void OnEnable()
    {
        EventManager.StartListening(EventName.Server.Character.Move, OnMove);

        // EventManager.StartListening(CharacterInput.Moving, Moving);
        EventManager.StartListening(CharacterInput.Jump, Jump);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventName.Server.Character.Move, OnMove);

        // EventManager.StopListening(CharacterInput.Moving, Moving);
        EventManager.StopListening(CharacterInput.Jump, Jump);
    }

    private void OnMove()
    {
        var moveResponse = NetworkController.Instance.events.characterMove.Response.data;
        if (character.Info.id != moveResponse.characterId) return;

        mover.Moving(new Vector2(moveResponse.direction, default));
    }

    private void Jump()
    {
        jumper.Jump();
        var newSound = gameObject.GetComponent<AudioSource>();
        newSound.PlayOneShot(jumpSound, 1f);
    }

    private void Moving()
    {
        var boxingMovingValue = EventManager.GetData(CharacterInput.Moving);
        var movingValue = new Vector2((float)boxingMovingValue, 0);

        mover.Moving(movingValue);
    }
}
// }