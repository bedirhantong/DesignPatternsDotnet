using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern
{
    internal class CombatExample
    {
        static void Main(string[] args)
        {
            Player player = new Player(new DefendStrategy());
            player.applyStrategy();

            player.changeStrategy(new SpeedUpStrategy());
            player.applyStrategy();

            Console.ReadLine();
        }
    }
    class Player
    {
        private IPlayerStrategy playerStrategy;

        public Player(IPlayerStrategy playerStrategy)
        {
            this.playerStrategy = playerStrategy;
        }

        public Player()
        {

        }

        public void changeStrategy(IPlayerStrategy strategy)
        {
            this.playerStrategy = strategy;
        }

        public void applyStrategy()
        {
            this.playerStrategy.behaviour();
        }

    }
    interface IPlayerStrategy
    {
        void behaviour();
    }

    class DefendStrategy : IPlayerStrategy
    {
        public void behaviour()
        {
            Console.WriteLine("Defend");
        }
    }

    class SpeedUpStrategy : IPlayerStrategy
    {
        public void behaviour()
        {
            Console.WriteLine("Speed up bro");
        }
    }

}
