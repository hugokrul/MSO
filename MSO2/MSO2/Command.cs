using System;
using System.Collections.Generic;

namespace MSO2
{
    public interface ICommand
    {
        // Executes the command
        void Execute(Creature creature);
    }

    public class TurnCommand : ICommand
    {
        private string _direction;

        // Constructor to initialize the turn direction.
        public TurnCommand(string direction)
        {
            _direction = direction;
        }

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

    public class MoveCommand : ICommand
    {
        private int _steps; // Number of steps to move.

        // Constructor to initialize the number of steps.
        public MoveCommand(int steps)
        {
            _steps = steps;
        }

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

    public class RepeatCommand : ICommand
    {
        private List<ICommand> commandList;
        private int _amount;

        public RepeatCommand(List<ICommand> commandList, int amount)
        {
            this.commandList = commandList;
            _amount = amount;
        }

        public void Execute(Creature creature)
        {
            foreach (ICommand command in commandList)
            {
                command.Execute(creature);
            }
        }

        public override string ToString()
        {
            return $"Repeat {_amount} times: {string.Join(',', commandList)}";
        }
    }
}
