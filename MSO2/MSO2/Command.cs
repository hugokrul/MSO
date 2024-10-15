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

    public class RepeatCommand : ICommand
    {
        private List<ICommand> _commands; // List of commands to repeat.
        private int _times; // Number of times to repeat.

        // Constructor to initialize commands and repeat count.
        public RepeatCommand(List<ICommand> commands, int times)
        {
            _commands = commands;
            _times = times;
        }

        // Executes the repeated commands on the creature.
        public void Execute(Creature creature)
        {
            for (int i = 0; i < _times; i++)
            {
                foreach (ICommand command in _commands)
                {
                    command.Execute(creature);
                }
            }
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
}
