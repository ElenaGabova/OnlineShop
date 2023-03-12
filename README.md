Проект онлайн-магазина школы танцев. 
В проекте реализован основной функционал онлайн-магазина, необходимый для совершения покупок пользователями (выбор товара, поиск по каталогу, добавление в корзину/избранное/к сравнению, оформление заказа), реализован механизм авторизации и регистрации при помощи встроенной в ASP.NET Core технологии Identity, а также панель администратора, позволяющая пользователю в роли администратора редактировать данные заказов, пользователей, товаров на сайте. 
Все данные заносятся и хранятся в базе данных MS SQL. Сделано web-api для работы с сущностями через Swagger.
<br><br>
Документация с описание проекта:
<br>https://github.com/ElenaGabova/OnlineShop/blob/main/Описание%20веб-приложения%20школы%20танцев.docx

Используемые бибилиотеки и фреймворки:

ASP. NET 6, Razor pages - основной стек
<br>
Bootstrap, HTML, CSS - фронт для веб-приложения
<br>
EntityFrameworkCore - работа с базой данных.
<br>
Identity - работа с пользователями, авторизация и регистарция, роли
<br>
AutoMapper - маппинг сущностей
<br>
Seriolog - логирование, запись в консоль и файл 
<br>
Swagger - доступ с веб-апи.
<br>
Jwt bearer - авторизация в апи.
<br>
<br>
Проект сайта и апи размещены в докер конейнере, поднять конейнеры можно с помощью команд:
<br>
<br>api: 
<br>docker build -t online-shop-web-api -f OnlineShopWebApi_Dockerfile_Debug .
<br>
Основной сайт: 
<br>docker build -t online-shop-web-app -f OnlineShopWebApp_Dockerfile_Debug .
<br><br>
Структура проекта:
<br>
<br>Constants&emsp;&emsp;&emsp;&emsp;- общие константы.
<br>Database&emsp;&emsp;&emsp;&emsp;- Репозитории для работы с базой данных. 
<br>Domain&emsp;&emsp;&emsp;&emsp;     - сущности в сервисах
<br>Entities&emsp;&emsp;&emsp;&emsp;&emsp;- сущности в базе данных
<br>ViewModels&emsp;&emsp;&emsp;&emsp;&emsp;- сущности на клиенте
<br>Mappers &emsp;&emsp;&emsp;&emsp;&emsp;- описание маппинга для AutoMapper
<br>Service&emsp;&emsp;&emsp;&emsp;&emsp;- оснвоные сервисы и репозитории
<br>OnlineShop.Api&emsp;&emsp;&emsp;- веб-апи
<br>OnlineShopWebApp&emsp;- веб-приложение










