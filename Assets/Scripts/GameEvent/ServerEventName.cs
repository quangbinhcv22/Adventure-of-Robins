

namespace GameEvent
{
    public static class EventName
    {
        public static class Server
        {
            public const string Connected = "ServerConnected";
        }

        public static class CharacterInput
        {
            public const string IsLanding = "isLanding";
            public const string IsRunning = "isRunning";
            public const string Jump = "Jump";
            public const string Attack = "Attack";
            public const string Fall = "Fall";
            public const string Moving = "Moving";
            public const string FallDuringRun = "FallDuringRun";
            
            public const string StartIdleAnimation = "StartIdleAnimation";
            public const string StartRunAnimation = "StartRunAnimation";
            public const string StartJumpAnimation = "StartJumpAnimation";
            public const string StartAttackAnimation = "StartAttackAnimation";
            
            public const string Skill1 = "Skill1";
            public const string Skill2 = "Skill2";
            public const string Skill3 = "Skill3";
        }

        public static class CharactorID
        {
            public const string Gladiator = "Gladiator";
            public const string RobinHood = "RobinHood";
        }
    }
}