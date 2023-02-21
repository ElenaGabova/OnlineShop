using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class DopTextPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeliveryInfos_Storages_StorageId",
                table: "UserDeliveryInfos");

            migrationBuilder.DeleteData(
                table: "TextPages",
                keyColumn: "Id",
                keyValue: new Guid("177067a2-1779-4ee7-a6a4-fc48ecc25671"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StorageId",
                table: "UserDeliveryInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserDeliveryInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "TextPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderMainText",
                table: "TextPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderText",
                table: "TextPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "TextPages",
                columns: new[] { "Id", "AboutUsFooter", "AboutUsText", "DirectionsLeft", "DirectionsRight", "FooterText", "HeaderMainText", "HeaderText", "TimetableLeft", "TimetableRight" },
                values: new object[] { new Guid("e7a74145-edc6-490d-93d4-b6133c243fc9"), "По всем вопросам обращайтесь к Марине Максимец в личку https://vk.me/dancing_people11 и по телефону 8 (908) 7192551\r\n\r\n\r\n\r\n\r\n\r\n Хорошего вам дня))))", "Добро пожаловать в клуб \"Танцующие люди\"! Мы учим людей танцевать, мы любим неформальное общение и вечеринки!\r\n\r\n                В этой группе мы говорим о танцах в Сыктывкаре и окружающих их людях, рассказываем, где можно танцевать и как хорошо провести время, приглашаем вас в кино, посещаем каток и многое другое.А здесь вы можете узнать о занятиях, открытых уроках и вечеринках.\r\n               Мы обучаем парным и сольным танцам \"social\", таким как танго, бачата, сальса, кизомба, линди хоп, WCS_, сольный джаз и латиноамериканцы, а также у нас есть зумба, йога, растяжка и fit &amp; slim для хорошего здоровья.Нас 17 учителей и около 200 учеников.", "  Сольные направления\r\n\r\n  ВОСТОЧНЫЕ ТАНЦЫ\r\n  ПИЛАТЕС\r\n  СОЛО БАЧАТА\r\n  СОЛО БЛЮЗ\r\n  СОЛО САЛЬСА", "Парные танцы\r\n\r\n  БАЧАТА\r\n  САЛЬСА\r\n  ТАНГО\r\n  БЛЮЗ парный", null, null, null, "СОЛЬНЫЕ НАПРАВЛЕНИЯ\r\n\r\n🌙 ВОСТОЧНЫЕ ТАНЦЫ\r\nпонедельник 18:15 лимонный зал, среда 19:15 уютный зал\r\n\r\n🧘 ПИЛАТЕС!\r\n\r\nвторник, четверг 18:15, воскресенье 10:00 уютный зал\r\n\r\n🦋 СОЛО БАЧАТА\r\nначинающие: среда 20:15 (55 минут), пятница 19:15 (55 минут), суббота 18:00 ( 2 часа подряд) лимонный зал\r\n\r\nпродолжающие: вторник, пятница 20:15 лимонный зал\r\n\r\n🎷 СОЛО БЛЮЗ\r\nвторник, пятница 18:15 лимонный зал\r\n\r\n🌶 СОЛО САЛЬСА\r\nначинающие: среда 18:15, воскресенье 11:00 лимонный зал", "ПАРНЫЕ ТАНЦЫ\r\n\r\n🌴 БАЧАТА\r\nначинающие: понедельник, четверг 19:15 лимонный зал\r\n\r\nпродолжающие: понедельник, четверг 20:15 лимонный зал\r\n\r\n 🌶 САЛЬСА\r\nвторник 19:15, четверг 18:15 лимонный зал\r\n\r\n👠 ТАНГО\r\nначинающие: среда 19:15, суббота 17:00 лимонный зал\r\n\r\n🎺 БЛЮЗ парный\r\nвторник, пятница 19:15 уютный зал" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeliveryInfos_Storages_StorageId",
                table: "UserDeliveryInfos",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeliveryInfos_Storages_StorageId",
                table: "UserDeliveryInfos");

            migrationBuilder.DeleteData(
                table: "TextPages",
                keyColumn: "Id",
                keyValue: new Guid("e7a74145-edc6-490d-93d4-b6133c243fc9"));

            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "TextPages");

            migrationBuilder.DropColumn(
                name: "HeaderMainText",
                table: "TextPages");

            migrationBuilder.DropColumn(
                name: "HeaderText",
                table: "TextPages");

            migrationBuilder.AlterColumn<Guid>(
                name: "StorageId",
                table: "UserDeliveryInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UserDeliveryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TextPages",
                columns: new[] { "Id", "AboutUsFooter", "AboutUsText", "DirectionsLeft", "DirectionsRight", "TimetableLeft", "TimetableRight" },
                values: new object[] { new Guid("177067a2-1779-4ee7-a6a4-fc48ecc25671"), "По всем вопросам обращайтесь к Марине Максимец в личку https://vk.me/dancing_people11 и по телефону 8 (908) 7192551\r\n\r\n\r\n\r\n\r\n\r\n Хорошего вам дня))))", "Добро пожаловать в клуб \"Танцующие люди\"! Мы учим людей танцевать, мы любим неформальное общение и вечеринки!\r\n\r\n                В этой группе мы говорим о танцах в Сыктывкаре и окружающих их людях, рассказываем, где можно танцевать и как хорошо провести время, приглашаем вас в кино, посещаем каток и многое другое.А здесь вы можете узнать о занятиях, открытых уроках и вечеринках.\r\n               Мы обучаем парным и сольным танцам \"social\", таким как танго, бачата, сальса, кизомба, линди хоп, WCS_, сольный джаз и латиноамериканцы, а также у нас есть зумба, йога, растяжка и fit &amp; slim для хорошего здоровья.Нас 17 учителей и около 200 учеников.", "  Сольные направления\r\n\r\n  ВОСТОЧНЫЕ ТАНЦЫ\r\n  ПИЛАТЕС\r\n  СОЛО БАЧАТА\r\n  СОЛО БЛЮЗ\r\n  СОЛО САЛЬСА", "Парные танцы\r\n\r\n  БАЧАТА\r\n  САЛЬСА\r\n  ТАНГО\r\n  БЛЮЗ парный", "СОЛЬНЫЕ НАПРАВЛЕНИЯ\r\n\r\n🌙 ВОСТОЧНЫЕ ТАНЦЫ\r\nпонедельник 18:15 лимонный зал, среда 19:15 уютный зал\r\n\r\n🧘 ПИЛАТЕС!\r\n\r\nвторник, четверг 18:15, воскресенье 10:00 уютный зал\r\n\r\n🦋 СОЛО БАЧАТА\r\nначинающие: среда 20:15 (55 минут), пятница 19:15 (55 минут), суббота 18:00 ( 2 часа подряд) лимонный зал\r\n\r\nпродолжающие: вторник, пятница 20:15 лимонный зал\r\n\r\n🎷 СОЛО БЛЮЗ\r\nвторник, пятница 18:15 лимонный зал\r\n\r\n🌶 СОЛО САЛЬСА\r\nначинающие: среда 18:15, воскресенье 11:00 лимонный зал", "ПАРНЫЕ ТАНЦЫ\r\n\r\n🌴 БАЧАТА\r\nначинающие: понедельник, четверг 19:15 лимонный зал\r\n\r\nпродолжающие: понедельник, четверг 20:15 лимонный зал\r\n\r\n 🌶 САЛЬСА\r\nвторник 19:15, четверг 18:15 лимонный зал\r\n\r\n👠 ТАНГО\r\nначинающие: среда 19:15, суббота 17:00 лимонный зал\r\n\r\n🎺 БЛЮЗ парный\r\nвторник, пятница 19:15 уютный зал" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeliveryInfos_Storages_StorageId",
                table: "UserDeliveryInfos",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
