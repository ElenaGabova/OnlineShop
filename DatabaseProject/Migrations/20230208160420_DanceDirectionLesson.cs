using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class DanceDirectionLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "TextPages",
                keyColumn: "Id",
                keyValue: new Guid("53d4f950-fefd-4f59-96a2-1518614526ee"));

            migrationBuilder.CreateTable(
                name: "DanceDirectionUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceDirectionUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanceDirectionRegistrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DanceDirectionEntityId = table.Column<int>(type: "int", nullable: false),
                    DanceDirectionUserEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeedToCall = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceDirectionRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanceDirectionRegistrations_DanceDirections_DanceDirectionEntityId",
                        column: x => x.DanceDirectionEntityId,
                        principalTable: "DanceDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanceDirectionRegistrations_DanceDirectionUsers_DanceDirectionUserEntityId",
                        column: x => x.DanceDirectionUserEntityId,
                        principalTable: "DanceDirectionUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "DanceDirections",
            //    columns: new[] { "Id", "Description", "MainPhoto", "Name", "OtherPhotos", "SoloDoubleSign", "VideoLinks" },
            //    values: new object[,]
            //    {
            //        { 1, "          Бача́та (исп. bachata) — танец родом из Доминиканской Республики, получивший также широкое распространение в латиноамериканских странах Карибского бассейна.", "images/danceDirections/83dfe940-8e63-4138-b4f8-d885009b1ee0.png", "Бачата", "images/danceDirections/83dfe940-8e63-4138-b4f8-d885009b1ee0.png", true, "" },
            //        { 2, "Сальса — современный социальный танец из США и Латинской Америки, который танцуют парно или в группах. Танец возник в 1970-х годах в Нью-Йорке\r\n\r\nС незначительной поправкой на различные стили сальсы, основные движения состоят из быстрого-быстрого-медленного шагов под четыре ударных ритма (счета, бита) в музыке. Каждый четвёртый счёт используется для медленного переноса веса, паузы или, в некоторых стилях, для кика (выброса ноги) или чечётки (удара ногой о пол). Ряд стилей имеет чёткое определение начала танца. Лос-Анджелес, Лондон — начинаются на счёт «1» — сильную долю. Нью-Йорк (= Modern Mambo = Eddie Torres style = On 2), Пуэрто-Рико, Палладиум и кубинский сон — начинаются на счёт «2».\r\n\r\nОстальные виды (кубинский, колумбийский, венесуэльский) могут начинаться на любую долю музыки. В некоторых регионах правильной считается сильная доля, в некоторых — tiempo, в некоторых — contratiempo, в каких-то — вообще не закреплено.\r\n\r\nВенесуэльский и колумбийский стили также отличаются тем, что в силу специфики ряда элементов в танце может происходить смещение ритма. То есть в течение 1 танца может присутствовать начало движений на «1», и на «2», и на другие счета. Такое происходит после определённых фигур, которые могут менять ритмику танца.\r\n\r\nТанец в кубинском стиле не может начинаться на любой счёт, а только на a tiempo y contratiempo, то есть на первую или вторую доли.", "images/danceDirections/75950549-20ad-43a6-b242-dd71d60ebfa0.png", "Сальса", "images/danceDirections/75950549-20ad-43a6-b242-dd71d60ebfa0.png", true, "" },
            //        { 3, "Пила́тес (англ. Pilates) — система физических упражнений (фитнеса), разработанная Йозефом Пилатесом в начале XX века для реабилитации после травм.\r\n\r\nАвтор назвал свою систему контрологией (англ. сontrology), определив её как полную координацию между телом, умом и духом, но в настоящее время она широко известна как «метод Пилатеса» или просто «Пилатес»[1].\r\n\r\nПилатес представляет собой серию упражнений в медленном темпе. Как и у других видов фитнеса или физкультуры, результатом регулярных занятий становятся оздоровление суставов и укрепление мышц, снятие напряжений и болей в теле, коррекция веса, улучшение осанки, нормализация сна, улучшение самочувствия.\r\n\r\nЭнтузиасты пилатеса утверждают, что им можно заниматься как в фитнес-клубе, так и самостоятельно, что он доступен людям любого возраста и пола, с любым уровнем физической подготовки, и что возможность травм сведена к минимуму. Специалисты по фитнесу предупреждают, что начинать занятия необходимо под контролем тренера на специальных тренажёрах, позволяющих избежать травм, а самостоятельные занятия на матах допускаются только для овладевших «продвинутым» (третьим) уровнем подготовки[", "images/danceDirections/50367a3c-8265-40fa-8318-617ef09b5613.png", "Пилатес",  "images/danceDirections/50367a3c-8265-40fa-8318-617ef09b5613.png", false, "" },
            //        { 4, "Соло-блюз — удивительный танец, позволяющий выразить себя, свой стиль, свои чувства вместе с блюзовой музыкой. Это будто бы еще один способ проявить любовь к блюзу!\r\n\r\nТанец блюз пластичен, разнообразен и основан на импровизации. Это свобода движения и самовыражения, находящая выход через тело. Это может быть иногда нежность, гибкость и пластика, а иногда резкость или заземленность. Блюз — это смешение всего того, что вы уже умеете, с тем, чего именно хочется вашему телу в данный момент. А еще вы можете танцевать его где угодно, и даже взаимодействовать вашим танцем с музыкантами.\r\n\r\nЕсли вам нравится блюзовая музыка, те эмоции и атмосфера, которые она создает, то соло-блюз подходит вам, независимо от возраста, пола и степени танцевальной подготовки. Блюз могут танцевать все!", "images/danceDirections/b2c7756f-dc29-4729-b973-795cf4fa9057.png", "Соло-Блюз", "images/danceDirections/b2c7756f-dc29-4729-b973-795cf4fa9057.png", false, "" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_DanceDirectionRegistrations_DanceDirectionEntityId",
                table: "DanceDirectionRegistrations",
                column: "DanceDirectionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DanceDirectionRegistrations_DanceDirectionUserEntityId",
                table: "DanceDirectionRegistrations",
                column: "DanceDirectionUserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanceDirectionRegistrations");

            migrationBuilder.DropTable(
                name: "DanceDirectionUsers");

            migrationBuilder.DeleteData(
                table: "DanceDirections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanceDirections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanceDirections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanceDirections",
                keyColumn: "Id",
                keyValue: 4);

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
                columns: new[] { "Id", "AboutUsFooter", "AboutUsText", "DirectionsLeft", "DirectionsRight", "FooterText", "HeaderMainText", "HeaderText", "TimetableLeft", "TimetableRight" },
                values: new object[] { new Guid("53d4f950-fefd-4f59-96a2-1518614526ee"), "По всем вопросам обращайтесь к Марине Максимец в личку https://vk.me/dancing_people11 и по телефону 8 (908) 7192551\r\n\r\n\r\n\r\n\r\n\r\n Хорошего вам дня))))", "Добро пожаловать в клуб \"Танцующие люди\"! Мы учим людей танцевать, мы любим неформальное общение и вечеринки!\r\n\r\n                В этой группе мы говорим о танцах в Сыктывкаре и окружающих их людях, рассказываем, где можно танцевать и как хорошо провести время, приглашаем вас в кино, посещаем каток и многое другое.А здесь вы можете узнать о занятиях, открытых уроках и вечеринках.\r\n               Мы обучаем парным и сольным танцам \"social\", таким как танго, бачата, сальса, кизомба, линди хоп, WCS_, сольный джаз и латиноамериканцы, а также у нас есть зумба, йога, растяжка и fit &amp; slim для хорошего здоровья.Нас 17 учителей и около 200 учеников.", "  Сольные направления\r\n\r\n  ВОСТОЧНЫЕ ТАНЦЫ\r\n  ПИЛАТЕС\r\n  СОЛО БАЧАТА\r\n  СОЛО БЛЮЗ\r\n  СОЛО САЛЬСА", "Парные танцы\r\n\r\n  БАЧАТА\r\n  САЛЬСА\r\n  ТАНГО\r\n  БЛЮЗ парный", null, null, null, "СОЛЬНЫЕ НАПРАВЛЕНИЯ\r\n\r\n🌙 ВОСТОЧНЫЕ ТАНЦЫ\r\nпонедельник 18:15 лимонный зал, среда 19:15 уютный зал\r\n\r\n🧘 ПИЛАТЕС!\r\n\r\nвторник, четверг 18:15, воскресенье 10:00 уютный зал\r\n\r\n🦋 СОЛО БАЧАТА\r\nначинающие: среда 20:15 (55 минут), пятница 19:15 (55 минут), суббота 18:00 ( 2 часа подряд) лимонный зал\r\n\r\nпродолжающие: вторник, пятница 20:15 лимонный зал\r\n\r\n🎷 СОЛО БЛЮЗ\r\nвторник, пятница 18:15 лимонный зал\r\n\r\n🌶 СОЛО САЛЬСА\r\nначинающие: среда 18:15, воскресенье 11:00 лимонный зал", "ПАРНЫЕ ТАНЦЫ\r\n\r\n🌴 БАЧАТА\r\nначинающие: понедельник, четверг 19:15 лимонный зал\r\n\r\nпродолжающие: понедельник, четверг 20:15 лимонный зал\r\n\r\n 🌶 САЛЬСА\r\nвторник 19:15, четверг 18:15 лимонный зал\r\n\r\n👠 ТАНГО\r\nначинающие: среда 19:15, суббота 17:00 лимонный зал\r\n\r\n🎺 БЛЮЗ парный\r\nвторник, пятница 19:15 уютный зал" });
        }
    }
}
