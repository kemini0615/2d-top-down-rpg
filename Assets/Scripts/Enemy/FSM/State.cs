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
        ExecuteTransitions(enemyController); // TODO: 의존성 프로퍼티화?
    }

    private void ExecuteActions()
    {
        if (actions == null || actions.Length == 0)
            return;

        foreach (Action action in actions)
        {
            action.Act();
        }
    }

    private void ExecuteTransitions(EnemyController enemyController)
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
                enemyController.ChangeState(transition.falseStateId);
            }
        }

        
    }
}
