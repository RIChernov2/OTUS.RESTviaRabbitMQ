using Notifications.Manager.Models;
using FluentMigrator;
using System;

namespace Notifications.Manager.Migrations
{
    [Profile("FirstStart")]
    public class InitialDataMigration : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("messages")
            .Row(new { user_id = "1", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ сформирован." })
            .Row(new { user_id = "5", type = Enum.GetName(typeof(MessageType), MessageType.Warning), text = "Срок действия подарочной карты истекает." })
            .Row(new { user_id = "2", type = Enum.GetName(typeof(MessageType), MessageType.Ads), text = "Специальное предложение для вас." })
            .Row(new { user_id = "1", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ направлен курьеру." })
            .Row(new { user_id = "1", type = Enum.GetName(typeof(MessageType), MessageType.Warning), text = "Срок действия подарочной карты истекает." })
            .Row(new { user_id = "6", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ сформирован." })
            .Row(new { user_id = "3", type = Enum.GetName(typeof(MessageType), MessageType.Ads), text = "Специальное предложение для вас." })
            .Row(new { user_id = "6", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ направлен курьеру." })
            .Row(new { user_id = "4", type = Enum.GetName(typeof(MessageType), MessageType.Ads), text = "Специальное предложение для вас." })
            .Row(new { user_id = "4", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ сформирован." })
            .Row(new { user_id = "4", type = Enum.GetName(typeof(MessageType), MessageType.Info), text = "Ваш заказ направлен курьеру." })
            .Row(new { user_id = "1", type = Enum.GetName(typeof(MessageType), MessageType.Warning), text = "Срок действия подарочной карты истекает." });
        }

        public override void Down()
        {
        }
    }
}
