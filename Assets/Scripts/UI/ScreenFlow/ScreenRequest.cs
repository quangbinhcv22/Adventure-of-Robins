using System;

namespace UI.ScreenFlow
{
    [Serializable]
    public class ScreenRequest
    {
        public ScreenAction action;
        public ScreenID id;
        public object data;
    }
}