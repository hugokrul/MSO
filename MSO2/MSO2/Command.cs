using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal interface ICommand
    {
        void Execute(Creature creature);
    }

    internal class TurnCommand : ICommand
    {
        private string _direction;

        public TurnCommand(string direction)
        {
            _direction = direction;
        }

        public void Execute(Creature creature)
        {
            creature.Turn(_direction);
        }

        public override string ToString()
        {
            return $"Turn {_direction}";
        }
    }

    internal class RepeatCommand : ICommand
    {
        private List<ICommand> _commands;
        private int _times;

        public RepeatCommand(List<ICommand> commands, int times)
        {
            _commands = commands;
            _times = times;
        }

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

    internal class MoveCommand : ICommand
    {
        private int _steps;

        public MoveCommand(int steps)
        {
            _steps = steps;
        }

        public void Execute(Creature creature)
        {
            creature.Move(_steps);
        }

        public override string ToString()
        {
            return $"Move {_steps}";
        }
    }
}
