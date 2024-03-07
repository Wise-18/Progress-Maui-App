**Задание: разработка приложения с чистой (clean) архитектурой, с хранением данных в реляционной базе данных.**
Результат выполнения работы: приложение, обеспечивающее функционал согласно заданию.
**1. Предварительная информация**
Проанализируйте предметную область - Больничная палата – пациенты (обязательное свойство – температура пациента)
Класс, описывающий группу объектов, должен содержать следующие свойства:
− Идентификатор
− Название
− Какое-нибудь дополнительное свойство (дату, продолжительность, стоимость, вес, оклад и т.д.)
− Навигационное свойство – коллекцию объектов-членов группы
Класс, описывающий члена группы, должен содержать следующие свойства:
− Идентификатор
− Название
− Обязательное свойство согласно варианту задания.
− 2-3 дополнительных свойства, описывающие объект
− Навигационные свойства – идентификатор группы, объект класса руппы.
Отношение между классами: один-ко-многим. В одной группе может быть много объектов, но один объект не может принадлежать к разным группам.
**2. Постановка задачи**
1. При выборе группы вывести на этой же странице полную информацию о группе, а также список объектов – членов группы.
2. Выделить цветом объекты, у которых обязательное свойство не соответствует какому-нибудь критерию, например, меньше допустимого значения.
3. При клике на объект в списке должна открыться страница с подробной информацией о выбранном объекте. На странице предусмотреть меню для перехода на страницу редактирования информации, а также удаление объекта.
4. Предусмотреть возможность создания и добавления объектов в группу.
5. Предусмотреть возможность добавления и редактирования групп
6. Предусмотреть сохранение файла изображения объекта. Имя файла должно соответствовать идентификатору объекта.
7. Всю информацию об объектах и группах объектов хранить в базе данных. Для работы с базой данных использовать EntityFramework Core.
**Требования к архитектуре проекта**
1) Реализовать в проекте архитектуру Clean (чистую) и шаблон проектирования UnitOfWork. (с шаблоном UnitOfWork можно познакомиться, например, здесь: https://metanit.com/sharp/mvc5/23.3.php или здесь: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-startedwith-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-anasp-net-mvc-application )
2) Для реализации шаблона CQRS использовать библиотеку MediatR (https://github.com/jbogard/MediatR/wiki )
3) На страницах приложения реализовать шаблон MVVM
4) Для получения объектов сервисов, репозиториев и т.д. использовать внедрение зависимостей
