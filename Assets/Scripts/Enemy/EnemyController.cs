using UnityEngine;

// 유한 상태 머신(Finite State Machine) 기능을 수행
public class EnemyController : MonoBehaviour
{
    [SerializeField] private State[] states;
    [SerializeField] private string initStateId;

    public State CurrentState { get; private set; }

    public Transform PlayerTransform { get; set; }

    private void Start()
    {
        ChangeState(initStateId);
    }

    private void Update()
    {
        if (CurrentState == null)
            return;

        CurrentState.UpdateState(this);
    }

    // 현재 상태 변경
    public void ChangeState(string newStateId)
    {
        State newState = GetStateById(newStateId);
        if (newState == null)
            return;

        CurrentState = newState;
    }

    // 상태 ID를 상태 객체로 맵핑해서 반환
    private State GetStateById(string stateId)
    {
        foreach (State state in states)
        {
            if (state.id == stateId)
                return state;
        }

        return null;
    }
}