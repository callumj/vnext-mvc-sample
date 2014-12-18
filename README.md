## MvcApp

An example ASP.NET 5 vNext MVC application, built as a example project for *nix platforms.

This project provides a basic web application that manages a list of todos. You can create, delete and (un)complete a todo.

Currently it is backed by an in-memory Entity Framework context, meaning that during application restarts the data will be lost. This will be moved to a more robust storage provider (SQLite) when the ASP.NET team provides a working sample.

## Installation

* Make sure the K environment is setup, see [aspnet/Home](https://github.com/aspnet/Home#os-x)
* Npm is recommended as it provides a few packages for running this project more comfortably

## Included scripts

* `script/setup`: Will use npm to install the required node modules
* `script/server`: Using gulp.js, invokes a watcher that restarts the kestrel web server when `.cs` files change