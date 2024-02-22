# Iteramico .NET CORE Backend

Оваа апликација го претставува backend делот на Iteramico апликацијата.

За правилно функционирање и тестирање на истата, потребен е следниов софтер да биде инсталиран.

- Visual Studio 2022 Community Edition
- SQL Server верзија поголема од 18
- Microsoft SQL Server Management Studio

# Стартување

1.	 За да правилно биде стартувана апликацијата, потребно е претходно да биде креиран корисник на sql server на моменталната машина.
2. Се отвара Iteramico.sln фајлот со Visual Studio 2022
3. Во Solution Explorer-от се навигира до Domain/DomainAPI/appsettings.json
4. Се менува "Iteramico" connection string-от во зависност од претходно креираниот користник на SQL Server.
5. Следно, Tools ->  NuGet Package Manager -> Package Manager Console
6. Во конзолата се пишува командата Update-Database со цел да се извршат миграциите и да се креира базата.
7. Доколку претходните чекори се успешни, едноставно се стартува проектот со кликање на Start или F5


# Дополнителни информации
Апликацијата е изградена врз .NET CORE 8. Постои WEB API, кое всушност е комуницирано од frontend апликацијата. Во позадина користи Entity Framework Core 8, за комуникација со базата на податоци.
