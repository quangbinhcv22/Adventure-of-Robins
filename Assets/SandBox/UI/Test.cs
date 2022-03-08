using UI;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ScreenFrame screenframe;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            screenframe.Request(new ScreenRequest{action = ScreenAction.New, id = ScreenID.BattleResultWindow});
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            screenframe.Request(new ScreenRequest{action = ScreenAction.Recall, id = ScreenID.BattleResultWindow});

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            screenframe.Request(new ScreenRequest{action = ScreenAction.Close, id = ScreenID.BattleResultWindow});
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            screenframe.Request(new ScreenRequest{action = ScreenAction.Open, id = ScreenID.BattleResultWindow});
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            screenframe.Request(new ScreenRequest{action = ScreenAction.Switch, id = ScreenID.LobbyWindow});
        }
    }
}
