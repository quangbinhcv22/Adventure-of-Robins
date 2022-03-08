using System;

namespace UI
{
    [Serializable]
    public class ScreenRequest
    {
        public ScreenAction action;
        public ScreenID id;
        public object data;
    }
}