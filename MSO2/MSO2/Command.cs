using System;
using System.Collections.Generic;

namespace MSO2
{
    public interface ICommand
    {
        // Executes the command
        void Execute(Creature creature);
    }

    public class TurnCommand(string direction) : ICommand
    {
        private readonly string _direction = direction;

        // Executes the turn command.
        public void Execute(Creature creature)
        {
            creature.Turn(_direction);
        }

        // Returns a string of the command. Handy for logging
        public override string ToString()
        {
            return $"Turn {_direction}";
        }
    }

    public class MoveCommand(int steps) : ICommand
    {
        private readonly int _steps = steps; // Number of steps to move.

        // Executes the move command.
        public void Execute(Creature creature)
        {
            creature.Move(_steps);
        }

        // Returns a string of the command. handy for logging.
        public override string ToString()
        {
            return $"Move {_steps}";
        }
    }

    public class RepeatUntilCommand(List<ICommand> commandList, Func<Creature, bool> predicate) : ICommand
    {
        // The list of commands, which it needs to execute.
        private readonly List<ICommand> _commandList = commandList;
        // A predicate for when the execution of the _commandList needs to stop.
        private readonly Func<Creature, bool> _predicate = predicate;

        public void Execute(Creature creature)
        {
            // If there are no commands to execute, the _predicate will almost always hold resulting in an infinate loop.
            if (_commandList.Count == 0) { return; }
            while (!_predicate(creature))
            {
                foreach(ICommand command in _commandList)
                {
                    command.Execute(creature);
                }
            }
        }

        public override string ToString()
        {
            return $"Repeat until: [{string.Join(", ", _commandList)}]";
        }
    }

    public class RepeatCommand(List<ICommand> commandList, int amount) : ICommand
    {
        // The list of command, which it needs to execute.
        private readonly List<ICommand> _commandList = commandList;
        // The amount of time the list needs to execute.
        private readonly int _amount = amount;

        public void Execute(Creature creature)
        {
            for (int i = 0; i < _amount; i++)
            {
                foreach (ICommand command in _commandList)
                {
                    command.Execute(creature);
                }
            }
        }

        public override string ToString()
        {
            return $"Repeat {_amount} times: [{string.Join(", ", _commandList)}]";
        }
    }
}
