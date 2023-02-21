using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "UserDeliveryInfos",
                columns: new[] { "Id", "Comment", "Email", "Name", "PhoneNumber", "StorageId" },
                values: new object[] { "0", "", "test@gmail.com", "Lena", "123456789", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "UserDeliveryInfos",
                keyColumn: "Id",
                keyValue: "0");
        }
    }
}
