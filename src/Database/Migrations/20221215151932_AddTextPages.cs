using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddTextPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AboutUsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionsLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionsRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimetableLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimetableRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextPages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TextPages",
                columns: new[] { "Id", "AboutUsFooter", "AboutUsText", "DirectionsLeft", "DirectionsRight", "TimetableLeft", "TimetableRight" },
                values: new object[] { new Guid("08068b97-4299-45d1-8514-ae1fc0b8c1bc"), "По всем вопросам обращайтесь к Марине Максимец в личку https://vk.me/dancing_people11 и по телефону 8 (908) 7192551\r\n\r\n\r\n\r\n\r\n\r\n Хорошего вам дня))))", "Добро пожаловать в клуб \"Танцующие люди\"! Мы учим людей танцевать, мы любим неформальное общение и вечеринки!\r\n\r\n                В этой группе мы говорим о танцах в Сыктывкаре и окружающих их людях, рассказываем, где можно танцевать и как хорошо провести время, приглашаем вас в кино, посещаем каток и многое другое.А здесь вы можете узнать о занятиях, открытых уроках и вечеринках.\r\n               Мы обучаем парным и сольным танцам \"social\", таким как танго, бачата, сальса, кизомба, линди хоп, WCS_, сольный джаз и латиноамериканцы, а также у нас есть зумба, йога, растяжка и fit &amp; slim для хорошего здоровья.Нас 17 учителей и около 200 учеников.", "  Сольные направления\r\n\r\n  ВОСТОЧНЫЕ ТАНЦЫ\r\n  ПИЛАТЕС\r\n  СОЛО БАЧАТА\r\n  СОЛО БЛЮЗ\r\n  СОЛО САЛЬСА", "Парные танцы\r\n\r\n  БАЧАТА\r\n  САЛЬСА\r\n  ТАНГО\r\n  БЛЮЗ парный", "СОЛЬНЫЕ НАПРАВЛЕНИЯ\r\n\r\n🌙 ВОСТОЧНЫЕ ТАНЦЫ\r\nпонедельник 18:15 лимонный зал, среда 19:15 уютный зал\r\n\r\n🧘 ПИЛАТЕС!\r\n\r\nвторник, четверг 18:15, воскресенье 10:00 уютный зал\r\n\r\n🦋 СОЛО БАЧАТА\r\nначинающие: среда 20:15 (55 минут), пятница 19:15 (55 минут), суббота 18:00 ( 2 часа подряд) лимонный зал\r\n\r\nпродолжающие: вторник, пятница 20:15 лимонный зал\r\n\r\n🎷 СОЛО БЛЮЗ\r\nвторник, пятница 18:15 лимонный зал\r\n\r\n🌶 СОЛО САЛЬСА\r\nначинающие: среда 18:15, воскресенье 11:00 лимонный зал", "ПАРНЫЕ ТАНЦЫ\r\n\r\n🌴 БАЧАТА\r\nначинающие: понедельник, четверг 19:15 лимонный зал\r\n\r\nпродолжающие: понедельник, четверг 20:15 лимонный зал\r\n\r\n 🌶 САЛЬСА\r\nвторник 19:15, четверг 18:15 лимонный зал\r\n\r\n👠 ТАНГО\r\nначинающие: среда 19:15, суббота 17:00 лимонный зал\r\n\r\n🎺 БЛЮЗ парный\r\nвторник, пятница 19:15 уютный зал" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextPages");
        }
    }
}
