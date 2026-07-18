using System;

[Serializable]
public class State
{
    public string id;
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(EnemyController enemyController)
    {
        ExecuteActions();
        ExecuteTransisions(enemyController); // TODO: 의존성 프로퍼티화?
    }

    private void ExecuteActions()
    {
        foreach (Action action in actions)
        {
            action.Act();
        }
    }

    private void ExecuteTransisions(EnemyController enemyController)
    {
        if (transitions == null || transitions.Length == 0)
            return;

        foreach (Transition transition in transitions)
        {
            if (transition.decision.Decide())
            {
                enemyController.ChangeState(transition.trueStateId);
            }
            else
            {
                enemyController.ChangeState(transition.falseStateId); // TODO: 필요한가?
            }
        }

        
    }
}
