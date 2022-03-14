// using System;
// using SandBox.Scripts;
// using TigerForge;
// using UnityEngine;
// using EventName = Network.Events.EventName;
//
// namespace GamePlay.MovementSimulation
// {
//     public class CharacterAnimator : MonoBehaviour
//     {
//         [SerializeField] private Animator animator;
//         [SerializeField] private Character character;
//         [SerializeField] private Transform groundCheck;
//         [SerializeField] private LayerMask ground;
//
//         private string currentState;
//         private bool _isOnGround;
//
//         private void Update()
//         {
//             _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
//             Debug.Log(_isOnGround);
//         }
//
//         private void CharacterAnimatorSwitch(string newState)
//         {
//             if (currentState == newState) return;
//
//             animator.Play(newState);
//
//             currentState = newState;
//         }
//
//         public void Idle()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     if (_isOnGround) CharacterAnimatorSwitch("Idle");
//
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     if (_isOnGround) CharacterAnimatorSwitch("Idle");
//
//                     break;
//                 }
//             }
//         }
//
//         public void Run()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     if (_isOnGround) CharacterAnimatorSwitch("Run");
//
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     if (_isOnGround) CharacterAnimatorSwitch("Run");
//
//                     break;
//                 }
//             }
//         }
//
//         public void Jump()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     CharacterAnimatorSwitch("Jump");
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     CharacterAnimatorSwitch("Jump");
//                     break;
//                 }
//             }
//         }
//
//         public void Attack()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     CharacterAnimatorSwitch("Attack");
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     CharacterAnimatorSwitch("Attack");
//                     break;
//                 }
//             }
//         }
//
//         public void Die()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     animator.SetTrigger(CharacterInput.Die);
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     animator.SetTrigger(CharacterInput.Die);
//                     break;
//                 }
//             }
//         }
//
//         public void Landing()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     animator.SetBool(CharacterInput.IsLanding, true);
//                     animator.ResetTrigger(CharacterInput.Jump);
//                     animator.ResetTrigger(CharacterInput.Fall);
//
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     animator.SetBool(CharacterInput.IsLanding, true);
//                     animator.ResetTrigger(CharacterInput.Jump);
//                     animator.ResetTrigger(CharacterInput.Fall);
//
//                     break;
//                 }
//             }
//         }
//
//         public void FallDuringRun()
//         {
//             switch (character.Info.heroID)
//             {
//                 case HeroID.Gladiator:
//                 {
//                     animator.SetBool(CharacterInput.IsLanding, false);
//
//                     break;
//                 }
//                 case HeroID.RobinHood:
//                 {
//                     animator.SetBool(CharacterInput.IsLanding, false);
//
//                     break;
//                 }
//             }
//         }
//     }
// }