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

    public class RepeatCommand(List<ICommand> commandList, int amount) : ICommand
    {
        private readonly List<ICommand> _commandList = commandList;
        private readonly int _amount = amount;

        public void Execute(Creature creature)
        {
            foreach (ICommand command in _commandList)
            {
                command.Execute(creature);
            }
        }

        public override string ToString()
        {
            return $"Repeat {_amount} times: {string.Join(',', _commandList)}";
        }
    }
}
