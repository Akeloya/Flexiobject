# Custom object application [![License: GPL v3](https://img.shields.io/github/license/Akeloya/CustomObjectApplication.svg)](http://www.gnu.org/licenses/gpl-3.0) [![Build](https://github.com/Akeloya/CustomObjectApplication/workflows/.NET%20Core/badge.svg)](https://github.com/Akeloya/CustomObjectApplication/actions?query=workflow%3A%22.NET+Core%22) [![CodeQL](https://github.com/Akeloya/CustomObjectApplication/workflows/CodeQL/badge.svg)](https://github.com/Akeloya/CustomObjectApplication/actions?query=workflow%3ACodeQL) [![BCH compliance](https://bettercodehub.com/edge/badge/Akeloya/CustomObjectApplication?branch=master)](https://bettercodehub.com/)

Application for creating and using freely customizable configuration of data, forms, actions and other things

## Solution description

| Language | Platform      | Win GUI  | Linux GUI     |
|:--------:|:-------------:|:--------:|:-------------:|
|   c#     | .Net Core 3.1 | WPF app  | Not specified |

## Development

- Make sure you have Visual Studio 2019 Community (or higher)
- Fork this repo
- Clone to computer
- Open solution, run build
- Read [Coding style](https://github.com/Akeloya/CustomObjectApplication/blob/master/CODINGSTYLE.md)

Solution contains several projects:

- Core - this core library with definition of app API
- DbProvider - EF core database schema description and methods work with it
- AppServer - Application server for this app, all app logic implements here
- API - client side api
- WpfClient - GUI application using client API

## Languages

- [English](#English)
- [Russian](#Russian)

## English

### Purpose

This project is an application of custom objects that allows the user to describe objects in the domain using fields in the window interface, add various actions on objects, create forms for editing objects without deep knowledge of programming.

### Description

- The application has a client-server architecture with its own software interface. The client can be any application that implements the processing of the project program interface (console application, service, window client).
- To work, you will need to install the application server, configure the connection to the DBMS, install and run the client.
- An application has its own data schema in the form of a set of tables that store settings and a description of the application object schema that describe the domain model of a user application for a certain domain.

To describe the subject area, the user is offered a basic set of objects:

- Folder - contains a description of the object (fields, actions, forms, object naming rules, user privileges, scripts, object display views)
- Custom object - located in a folder, inherits the folder fields that describe it. Edited through the form linked to the folder.
- Custom fields - a set of fields that can be created to describe an object in a folder (number, string, list, workflow, object link, object list, text field, currency, date)
- Forms in a folder (forms for editing objects, forms for filtering the list)
- Types of displaying objects in a folder (currently only a table)

The current stage of the project is porting from the .Net Framework to .Net Core to be able to build an application for Linux.

### Object structure

```bash
Application
|--Session
   |--Folder
      |--Objects
      |--Forms
      |--Actions
      |--Fields
      |--Scrips
      |--Sub folders
```

### How can you help the project

Everyone can help the project, especially for Linux development.

## Russian

### Цель

Данный проект это приложение настраеваемых объектов, позволяющее пользователю в оконном интерфейсе описать объекты предметной области с помощью полей, добавить различные действия над объектами, создать формы редактирования объектов без глубоких знаний в программировании.

### Описание

- Приложение имеет клиент-серверную архитектуру с собственным программным интерфейсом. Клиентом может являться любое приложение, реализующее обработку программного интерфейса проекта (консольное приложение, служба, оконный клиент).
- Для работы потребуется установка сервера приложений, настройки подключения к СУБД, установки и запуска клиента.
- У приложения имеется собственная схема данных в виде набора таблиц, в которых хранятся настройки и описание схемы объектов приложения, описывающих предметную модель пользовательского приложения для какой-то предметной области.

Для описания предметной области пользователю предлагается основной набор объектов:

- Папка - содержит описание объекта (поля, действия, формы, правила именования объекта, привилегии пользователей, скрипты, представления отображения объектов)
- Пользовательский объект - находится в папке, наследует поля папки, описывающие его. Редактируется через форму, привязанную к папке.
- Пользовательские поля - набор полей, которые можно создать для описания объекта в папке (число, строка, список, рабочий процесс, ссылка на объект, список объектов, текстовое поле, валюта, дата)
- Формы в папке (формы редактирования объектов, формы фильтрации списка)
- Виды отображения объектов в папке (на текущий момент только таблица)

Текущая стадия проекта - портирование с .Net Framework в .Net Core для возможности построения приложения под Linux.

### Чем можно помочь проекту

Проекту можно помочь всем, особенно по разработке под Linux.
