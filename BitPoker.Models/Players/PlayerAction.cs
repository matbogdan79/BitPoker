﻿using System;

namespace BitPoker.Models.Players
{
    public class PlayerAction : Models.IPlayerAction
    {
        private static readonly PlayerAction FoldObject = new PlayerAction(PlayerActionType.Fold);
        private static readonly PlayerAction CheckCallObject = new PlayerAction(PlayerActionType.CheckCall);

        private PlayerAction(PlayerActionType type)
        {
            this.Type = type;
        }

        private PlayerAction(Int64 money)
        {
            this.Type = PlayerActionType.Raise;
            this.Money = money;
        }

        public PlayerActionType Type { get; }

        public Int64 Money { get; set; }

        public static PlayerAction Fold()
        {
            return FoldObject;
        }

        public static PlayerAction CheckOrCall()
        {
            return CheckCallObject;
        }

        /// <summary>
        /// Creates a new object containing information about the player action and the raise amount
        /// </summary>
        /// <param name="withAmount">
        /// The amount to raise with.
        /// If amount is less than the minimum amount for raising then the game will take this minimum amount from the players money.
        /// If amount is more or equal to the players money the player will be in all-in state
        /// </param>
        /// <returns>A new player action object containing information about the player action and the raise amount</returns>
        public static PlayerAction Raise(Int64 withAmount)
        {
            if (withAmount <= 0)
            {
                return CheckOrCall();
            }

            return new PlayerAction(withAmount);
        }

        public override string ToString()
        {
            if (this.Type == PlayerActionType.Raise)
            {
                return $"{this.Type}({this.Money})";
            }
            else
            {
                return this.Type.ToString();
            }
        }
    }
}
