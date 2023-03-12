using Database.Constants;
using Database.Models;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Access for products table
        /// </summary>
        public DbSet<ProductEntity> Products { get;set;}

        /// <summary>
        /// Access for storage table
        /// </summary>
        public DbSet<StorageEntity> Storages { get; set; }

        /// <summary>
        /// Access for storageItem table
        /// </summary>
        public DbSet<StorageItemEntity> StorageItems { get; set; }


        /// <summary>
        /// Access for favorite product table
        /// </summary>
        public DbSet<FavoriteProductEntity> FavoriteProducts { get; set; }


        /// <summary>
        /// Access for Orders table
        /// </summary>
        public DbSet<OrderEntity> Orders { get; set; }


        /// <summary>
        /// Access for UserDeliveryInfos table
        /// </summary>
        public DbSet<UserDeliveryInfoEntity> UserDeliveryInfos { get; set; }

        /// <summary>
        /// Access for TextPage table
        /// </summary>
        public DbSet<TextPageEntity> TextPages { get; set; }
        /// <summary>
        /// Access to dance directions
        /// </summary>
        public DbSet<DanceDirectionEntity> DanceDirections { get; set; }


        /// <summary>
        /// Access for DanceDirectionUsers table
        /// </summary>
        public DbSet<DanceDirectionUserEntity> DanceDirectionUsers { get; set; }

        /// <summary>
        /// Access for DanceDirectionRegistrations table
        /// </summary>
        public DbSet<DanceDirectionRegistrationEntity> DanceDirectionRegistrations { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        :base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //var t =JsonProvider.Deserialize<List<ProductEntity>>(DatabaseConstants.ProductFileName);
           //modelBuilder.Entity<ProductEntity>().HasData(t);
           
           //modelBuilder.Entity<TextPageEntity>().HasData(
           //JsonProvider.Deserialize<TextPageEntity>(DatabaseConstants.TextPagesFileName));

            var danseDirectionsEntity = new List<DanceDirectionEntity> {
                new DanceDirectionEntity(){Id = 1, Name = "Бачата", MainPhoto= "images/danceDirections/83dfe940-8e63-4138-b4f8-d885009b1ee0.png", SoloDoubleSign=true, Description= "          Бача́та (исп. bachata) — танец родом из Доминиканской Республики, получивший также широкое распространение в латиноамериканских странах Карибского бассейна."},
                new DanceDirectionEntity(){Id = 2, Name = "Сальса", MainPhoto= "images/danceDirections/75950549-20ad-43a6-b242-dd71d60ebfa0.png", SoloDoubleSign=true, Description=@"Сальса — современный социальный танец из США и Латинской Америки, который танцуют парно или в группах. Танец возник в 1970-х годах в Нью-Йорке

С незначительной поправкой на различные стили сальсы, основные движения состоят из быстрого-быстрого-медленного шагов под четыре ударных ритма (счета, бита) в музыке. Каждый четвёртый счёт используется для медленного переноса веса, паузы или, в некоторых стилях, для кика (выброса ноги) или чечётки (удара ногой о пол). Ряд стилей имеет чёткое определение начала танца. Лос-Анджелес, Лондон — начинаются на счёт «1» — сильную долю. Нью-Йорк (= Modern Mambo = Eddie Torres style = On 2), Пуэрто-Рико, Палладиум и кубинский сон — начинаются на счёт «2».

Остальные виды (кубинский, колумбийский, венесуэльский) могут начинаться на любую долю музыки. В некоторых регионах правильной считается сильная доля, в некоторых — tiempo, в некоторых — contratiempo, в каких-то — вообще не закреплено.

Венесуэльский и колумбийский стили также отличаются тем, что в силу специфики ряда элементов в танце может происходить смещение ритма. То есть в течение 1 танца может присутствовать начало движений на «1», и на «2», и на другие счета. Такое происходит после определённых фигур, которые могут менять ритмику танца.

Танец в кубинском стиле не может начинаться на любой счёт, а только на a tiempo y contratiempo, то есть на первую или вторую доли."},
                new DanceDirectionEntity(){Id = 3, Name = "Пилатес", MainPhoto= "images/danceDirections/50367a3c-8265-40fa-8318-617ef09b5613.png", SoloDoubleSign=false, Description= @"Пила́тес (англ. Pilates) — система физических упражнений (фитнеса), разработанная Йозефом Пилатесом в начале XX века для реабилитации после травм.

Автор назвал свою систему контрологией (англ. сontrology), определив её как полную координацию между телом, умом и духом, но в настоящее время она широко известна как «метод Пилатеса» или просто «Пилатес»[1].

Пилатес представляет собой серию упражнений в медленном темпе. Как и у других видов фитнеса или физкультуры, результатом регулярных занятий становятся оздоровление суставов и укрепление мышц, снятие напряжений и болей в теле, коррекция веса, улучшение осанки, нормализация сна, улучшение самочувствия.

Энтузиасты пилатеса утверждают, что им можно заниматься как в фитнес-клубе, так и самостоятельно, что он доступен людям любого возраста и пола, с любым уровнем физической подготовки, и что возможность травм сведена к минимуму. Специалисты по фитнесу предупреждают, что начинать занятия необходимо под контролем тренера на специальных тренажёрах, позволяющих избежать травм, а самостоятельные занятия на матах допускаются только для овладевших «продвинутым» (третьим) уровнем подготовки["},
                new DanceDirectionEntity(){Id = 4, Name = "Соло-Блюз", MainPhoto= "images/danceDirections/b2c7756f-dc29-4729-b973-795cf4fa9057.png", SoloDoubleSign=false, Description= @"Соло-блюз — удивительный танец, позволяющий выразить себя, свой стиль, свои чувства вместе с блюзовой музыкой. Это будто бы еще один способ проявить любовь к блюзу!

Танец блюз пластичен, разнообразен и основан на импровизации. Это свобода движения и самовыражения, находящая выход через тело. Это может быть иногда нежность, гибкость и пластика, а иногда резкость или заземленность. Блюз — это смешение всего того, что вы уже умеете, с тем, чего именно хочется вашему телу в данный момент. А еще вы можете танцевать его где угодно, и даже взаимодействовать вашим танцем с музыкантами.

Если вам нравится блюзовая музыка, те эмоции и атмосфера, которые она создает, то соло-блюз подходит вам, независимо от возраста, пола и степени танцевальной подготовки. Блюз могут танцевать все!"},
            };

            modelBuilder.Entity<DanceDirectionEntity>().HasData(danseDirectionsEntity);

            modelBuilder.Entity<DanceDirectionEntity>()
            .Property(e => e.OtherPhotos)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<DanceDirectionEntity>()
            .Property(e => e.VideoLinks)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));


        }
    } 
}
