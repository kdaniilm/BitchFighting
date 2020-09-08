using BitchFighting.model;
using System;

namespace BitchFighting.viewmodel
{
    class GameWindowViewModel
    {
        Hero firstPlayer, secondPlayer;
        bool firstPlayer_isAttack, secondPlayer_isAttack;

        public GameWindowViewModel(Hero firstPlayer, Hero secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void Attack()
        {
            int powerAttack = 0;

            if (firstPlayer_isAttack)
            {
                powerAttack = firstPlayer.Attack - new Random().Next(0, secondPlayer.Defense);
                
                if(powerAttack > 0)
                {
                    secondPlayer.Hp -= powerAttack;
                }

                firstPlayer_isAttack = false;
            }
            else if(secondPlayer_isAttack)
            {
                powerAttack = secondPlayer.Attack - new Random().Next(0, firstPlayer.Defense);

                if (powerAttack > 0)
                {
                    secondPlayer.Hp -= powerAttack;
                }
                
                secondPlayer_isAttack = false;
            }
        }
    }
}
