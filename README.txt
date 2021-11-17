Приложение необходимо запускать на отладку в "мультирежиме" 
(solution  => properties  => StartupProject => multiple startup projects)
1. Noticifacion.Manager
2. WebApi

Для корректной работы приложения необходимо наличе PostgresSQL, в котором имеется:
- Database = otus
- Username = otus
- Password = otus
пользователь otus должен создать БД (otus), или иметь права на ее изменение

Программа создаст схему rest_homework и поместит в нее необходимые таблицы.

Если вам требуется инициализация стартовых значений (заполнение созданных таблиц данными)
необходимо в проектах WebApi и Noticifacion.Manager в классах Startup, в методах Configure()
раскомментировать стоку Configuration.FluentMigratorProfile = "FirstStart", запустить приложение,
остановить отладку, закомментировать строки назад, запустить приложение снова.

Интерфейс ввода - swagger.

Принципы REST показаны на примере двух контроллеров (UsersController, MessagesController)
Первый работает локально, второй через RabbitMQ.

Для работы контроллера на основе RabbitMQ (MessagesController) необходимо наличие установленного
и запущенного приложения RabbitMQ Server
