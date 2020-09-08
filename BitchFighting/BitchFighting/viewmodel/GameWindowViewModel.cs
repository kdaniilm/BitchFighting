using BitchFighting.model;
using System;
using System.Windows;

namespace BitchFighting.viewmodel
{
    class GameWindowViewModel
    {
        Hero firstPlayer, secondPlayer;
        bool firstPlayer_isAttack = true, secondPlayer_isAttack;

        public GameWindowViewModel(Hero firstPlayer, Hero secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public string Attack()
        {
            int powerAttack = 0;
            string log = null;

            if (firstPlayer_isAttack)
            {
                powerAttack = firstPlayer.Attack - new Random().Next(0, secondPlayer.Defense);

                if (powerAttack > 0)
                {
                    secondPlayer.Hp -= powerAttack;
                    log = $"{DateTime.Now.ToShortTimeString()}\tВторой персонаж получил {powerAttack} урона, у него осталось {secondPlayer.Hp} здоровья!";
                }
                else log = $"{DateTime.Now.ToShortTimeString()}\tБроня второго персонажа сдержала весь удар.";

                firstPlayer_isAttack = false;
                secondPlayer_isAttack = true;
            }
            else if(secondPlayer_isAttack)
            {
                powerAttack = secondPlayer.Attack - new Random().Next(0, firstPlayer.Defense);

                if (powerAttack > 0)
                {
                    firstPlayer.Hp -= powerAttack;
                    log = $"{DateTime.Now.ToShortTimeString()}\tПервый персонаж получил {powerAttack} урона, у него осталось {firstPlayer.Hp} здоровья!";
                }
                else log = $"{DateTime.Now.ToShortTimeString()}\tБроня первого персонажа сдержала весь удар.";

                secondPlayer_isAttack = false;
                firstPlayer_isAttack = true;
            }

            return log;
        }

        public string CheckHP(GameWindow parentWindow)
        {
            string log = null;

            if(firstPlayer.Hp <= 0)
            {
                log = $"{DateTime.Now.ToShortTimeString()}\tПервый персонаж пал, победа на стороне второго персонажа!";
                MessageBox.Show("Первый персонаж пал, победа на стороне второго персонажа!");
                new MainWindow().Show();
                parentWindow.Close();
            }
            else if(secondPlayer.Hp <= 0)
            {
                log = $"{DateTime.Now.ToShortTimeString()}\tВторой персонаж пал, победа на стороне первого персонажа!";
                MessageBox.Show("Первый персонаж пал, победа на стороне второго персонажа!");
                new MainWindow().Show();
                parentWindow.Close();
            }

            return log;
        }
    }
}
