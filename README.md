# Компетенции сотрудников (Hall Of Fame)
Представьте, что вы работаете в IT-компании, где множество сотрудников владеют разными навыками на разных уровнях. Сотрудники периодически повышают уровень существующих навыков, овладевают новыми навыками, и руководитель хочет видеть актуальные компетенции команды. Вам дают задание разработать backend-часть одностраничного приложения для просмотра и редактирования навыков персонала.

1.	На стороне backend используется ASP.NET Core версии 6.
2.	База данных: MS SQL ORM: EF Core. Структура БД приводится к кодовой базе при помощи миграций.
3. Backend предоставляет интерфейс Swagger

# Структура владеет следующими сущностями:

Person (Сотрудник)

Skill (Навык)


# Реализованы следующие API-запросы:

GET api/v1/persons - 
Возвращает массив объектов типа Person

GET api/v1/person/[id] - 
Где id – уникальный идентификатор сотрудника.
Возвращает объект типа Person.

POST api/v1/person - 
Где id – уникальный идентификатор сотрудника.
Создаёт нового сотрудника в системе с указанными навыками.

PUT api/v1/person/[id] - 
Где id – уникальный идентификатор сотрудника.
Обновляет данные сотрудника согласно значениям, указанным в объекте Person в теле. Обновляет навыки сотрудника согласно указанному набору.

DELETE api/v1/person/[id] - 
Где id – уникальный идентификатор сотрудника.
Удаляет с указанным id сотрудника из системы.

#

Сервер отслеживает изменения в навыках сотрудника при сохранении.

Статусы ответов:

200 – успешное выполнение запроса.

400 – неверный запрос.

404 – сущность не найдена в системе.

500 – серверная ошибка 




