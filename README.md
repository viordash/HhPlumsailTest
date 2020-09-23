Краткое описание к проекту для  «***A programming task for candidates for developer JavaScript, C#.***»

Microsoft Visual Studio 2017, solution “HhPlumsailApp”

Backend, ASP.NET Web Api, C#, проект “HhPlumsailApp”:

- реализованы контроллеры:
  - Account, регистрация пользователя
  - Orders, управление заказами
  - Customers, управление клиентами
- применена Token Based Authentication using ASP.NET Owin, для получения токена используется путь "/token"
- база данных для хранения пользователей, **\Application\HhPlumsailApp\App\_Data**, Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-HhPlumsailApp-20190417125338.mdf
- хранилище для заказов / клиентов, фейковое, только для тестирования. В singletone сервисах **OrderManagmentService** и **CustomerManagmentService**
- отдельный проект для unit-тестов сервера, “HhPlumsailApp.Tests”

Frontend, Angular 2, проект в папке “**\Application\HhPlumsailApp\AngularApp**”, разработка велась в Visual Studio Code :

- команды для сборки/тестирования/запуска описаны в README.md. 
- начинать рекомендую с команды \Application\HhPlumsailApp\AngularApp> **npm install** и затем ng build –prod. 
- Скомпилированный/упакованный frontend, \Application\HhPlumsailApp\AngularApp\dist, уже лежит в архиве, 
- при первом запуске, необходимо авторизоваться в модальном окне Login/SignUp. Регистрация пользователя на закладке SignUp. Затем можно сразу логинится.
- Токен аутентификации хранится в localStorage браузера
- Основная страница, список заказов, http://localhost:4716/orders
- Создание/редактирование заказов в модальных окнах
- Модель заказа: 
  - `    `id: number;
  - `    `date: Date;
  - `    `customer: string;
  - `    `status: object;
  - `    `prepaid: boolean;
  - `    `summ: number;
  - `    `description: string;
- Добавлены основные тесты (Karma) на компоненты и сервисы

