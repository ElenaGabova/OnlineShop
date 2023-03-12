using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class add_tier_architecture2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageItems_Orders_OrderId",
                table: "StorageItems");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TextPages",
                keyColumn: "Id",
                keyValue: new Guid("7e330593-50e2-4113-bfce-acef8273e53b"));

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "StorageItems",
                newName: "OrderEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_StorageItems_OrderId",
                table: "StorageItems",
                newName: "IX_StorageItems_OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageItems_Orders_OrderEntityId",
                table: "StorageItems",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageItems_Orders_OrderEntityId",
                table: "StorageItems");

            migrationBuilder.RenameColumn(
                name: "OrderEntityId",
                table: "StorageItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_StorageItems_OrderEntityId",
                table: "StorageItems",
                newName: "IX_StorageItems_OrderId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "Сost" },
                values: new object[,]
                {
                    { 1, "Для новичков. Первое занятие бесплатно", "FreeClasses.jpg", "Бесплатное занятие", 1m },
                    { 2, "Разовое посещение без абонемента", "ProductMainImage.jpg", "Разовое посещение", 300m },
                    { 3, "Всегда сможем договориться об удобных для вас условиях. \r\nЦена зависит от вида деятельности и количества арендуемых часов. От 100 рублей в дневное время.\r\n\r\nГотовые помещения 70, 55 и 35 (автономный) кв. м для вашего бизнеса.\r\nПлатите только за те часы, которыми\r\nпользуетесь.\r\n\r\nПРИМЕНЕНИЕ\r\n\r\nБерут для:\r\n-Уроков танцев, йоги, фитнеса;\r\n -Мастер - классов по рукоделию;\r\n -Корпоративов, спектаклей;\r\n -Настольных игр;\r\n -Уроков гитары, пианино;\r\n -Офиса, презентаций;\r\n -Вечеринок.", "RentImage.jpg", "Аренда зала", 100m },
                    { 4, "Абонемент на 10 уроков, бессрочный. При постоянном посещеении действуют скидки", "ProductMainImage.jpg", "Абонемент на 10 уроков", 2200m },
                    { 5, "Абонемент на 10 уроков для пары, бессрочный. При постоянном посещеении действуют скидки", "ProductMainImage.jpg", "Абонемент для пары на 10 уроков", 4000m },
                    { 6, "Абонемент на 10 уроков для cтудентов и пенсионеров, бессрочный. При постоянном посещеении действуют скидки", "ProductMainImage.jpg", "Специальные 10 уроков(студенты и пенсионеры)", 2000m },
                    { 7, "Проход на любую вечеринку нашего клуба.", "ProductMainImage.jpg", "Вечеринки", 300m }
                });

            migrationBuilder.InsertData(
                table: "TextPages",
                columns: new[] { "Id", "AboutUsFooter", "AboutUsText", "DirectionsLeft", "DirectionsRight", "TimetableLeft", "TimetableRight" },
                values: new object[] { new Guid("7e330593-50e2-4113-bfce-acef8273e53b"), "По всем вопросам обращайтесь к Марине Максимец в личку https://vk.me/dancing_people11 и по телефону 8 (908) 7192551\r\n\r\n\r\n\r\n\r\n\r\n Хорошего вам дня))))", "Добро пожаловать в клуб \"Танцующие люди\"! Мы учим людей танцевать, мы любим неформальное общение и вечеринки!\r\n\r\n                В этой группе мы говорим о танцах в Сыктывкаре и окружающих их людях, рассказываем, где можно танцевать и как хорошо провести время, приглашаем вас в кино, посещаем каток и многое другое.А здесь вы можете узнать о занятиях, открытых уроках и вечеринках.\r\n               Мы обучаем парным и сольным танцам \"social\", таким как танго, бачата, сальса, кизомба, линди хоп, WCS_, сольный джаз и латиноамериканцы, а также у нас есть зумба, йога, растяжка и fit &amp; slim для хорошего здоровья.Нас 17 учителей и около 200 учеников.", "  Сольные направления\r\n\r\n  ВОСТОЧНЫЕ ТАНЦЫ\r\n  ПИЛАТЕС\r\n  СОЛО БАЧАТА\r\n  СОЛО БЛЮЗ\r\n  СОЛО САЛЬСА", "Парные танцы\r\n\r\n  БАЧАТА\r\n  САЛЬСА\r\n  ТАНГО\r\n  БЛЮЗ парный", "СОЛЬНЫЕ НАПРАВЛЕНИЯ\r\n\r\n🌙 ВОСТОЧНЫЕ ТАНЦЫ\r\nпонедельник 18:15 лимонный зал, среда 19:15 уютный зал\r\n\r\n🧘 ПИЛАТЕС!\r\n\r\nвторник, четверг 18:15, воскресенье 10:00 уютный зал\r\n\r\n🦋 СОЛО БАЧАТА\r\nначинающие: среда 20:15 (55 минут), пятница 19:15 (55 минут), суббота 18:00 ( 2 часа подряд) лимонный зал\r\n\r\nпродолжающие: вторник, пятница 20:15 лимонный зал\r\n\r\n🎷 СОЛО БЛЮЗ\r\nвторник, пятница 18:15 лимонный зал\r\n\r\n🌶 СОЛО САЛЬСА\r\nначинающие: среда 18:15, воскресенье 11:00 лимонный зал", "ПАРНЫЕ ТАНЦЫ\r\n\r\n🌴 БАЧАТА\r\nначинающие: понедельник, четверг 19:15 лимонный зал\r\n\r\nпродолжающие: понедельник, четверг 20:15 лимонный зал\r\n\r\n 🌶 САЛЬСА\r\nвторник 19:15, четверг 18:15 лимонный зал\r\n\r\n👠 ТАНГО\r\nначинающие: среда 19:15, суббота 17:00 лимонный зал\r\n\r\n🎺 БЛЮЗ парный\r\nвторник, пятница 19:15 уютный зал" });

            migrationBuilder.AddForeignKey(
                name: "FK_StorageItems_Orders_OrderId",
                table: "StorageItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
