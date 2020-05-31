using System;

namespace StatePattern.States.Abstract {
  public abstract class State {
    protected enum StageType {
      Enter,
      Tick,
      Exit
    }

    private State _nextState;
    protected StageType Stage;

    protected State NextState {
      get => _nextState;
      set {
        _nextState = value ?? throw new ArgumentNullException(nameof(value));
        Stage = StageType.Exit;
      }
    }

    protected virtual void Enter() {
      Stage = StageType.Tick;
    }

    protected virtual void Tick() {
      Stage = StageType.Tick;
    }

    protected virtual void Exit() {
      Stage = StageType.Exit;
    }

    public State Process() {
      if (Stage == StageType.Enter) Enter();
      if (Stage == StageType.Tick) Tick();
      if (Stage != StageType.Exit) return this;
      Exit();
      return NextState;
    }
  }
}