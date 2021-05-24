﻿using UnityEngine;

public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor
{
    public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

    public abstract void ExecuteSpecificCommand<T>(T command) where T : ICommand;
}