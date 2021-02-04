# Custom object application (Приложение настраиваемых объектов)

![Build](https://github.com/Akeloya/CustomObjectApplication/workflows/.NET%20Core/badge.svg)
![CodeQL](https://github.com/Akeloya/CustomObjectApplication/workflows/CodeQL/badge.svg)

Application for creating and using freely customizable configuration of data, forms, actions and other things

## Languages

- English
- [Russian](#Russian)

## English

This project is an application of custom objects that allows the user to describe objects in the domain using fields in the window interface, add various actions on objects, create forms for editing objects without deep knowledge of programming.

The application has a client-server architecture with its own programming interface. The client can be any application that implements the processing of the project program interface (console application, service, window client).

To describe the subject area, the user is offered a basic set of objects:

- Folder - contains a description of the object (fields, actions, forms, object naming rules, user privileges, scripts, object display views)
- Custom object - located in a folder, inherits the folder fields that describe it. Edited through the form linked to the folder.
- Custom fields - a set of fields that can be created to describe an object in a folder (number, string, list, workflow, object link, object list, text field, currency, date)
- Forms in a folder (forms for editing objects, forms for filtering the list)
- Types of displaying objects in a folder (currently only a table)

The current stage of the project is porting from the .Net Framework to .Net Core to be able to build an application for Linux.

## Russian

Данный проект это приложение настраеваемых объектов, позволяющее пользователю в оконном интерфейсе описать объекты предметной области с помощью полей, добавить различные действия над объектами, создать формы редактирования объектов без глубоких знаний в программировании.

Приложение имеет клиент-серверную архитектуру с собственным программным интерфейсом. Клиентом может являться любое приложение, реализующее обработку программного интерфейса проекта (консольное приложение, служба, оконный клиент).

Для описания предметной области пользователю предлагается основной набор объектов:

- Папка - содержит описание объекта (поля, действия, формы, правила именования объекта, привилегии пользователей, скрипты, представления отображения объектов)
- Пользовательский объект - находится в папке, наследует поля папки, описывающие его. Редактируется через форму, привязанную к папке.
- Пользовательские поля - набор полей, которые можно создать для описания объекта в папке (число, строка, список, рабочий процесс, ссылка на объект, список объектов, текстовое поле, валюта, дата)
- Формы в папке (формы редактирования объектов, формы фильтрации списка)
- Виды отображения объектов в папке (на текущий момент только таблица)

Текущая стадия проекта - портирование с .Net Framework в .Net Core для возможности построения приложения под Linux.
