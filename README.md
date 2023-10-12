## Simple Password Manager

This password manager requires that you run our SQL Scripts found within our project. The first script to run should be the “InitDB_v1.0.sql” file. The commands within it should be run so as to initialize the database, providing it with the same name as what is used within our project connection string. Which is meant to connect to a local instance of your SQL Server. Once the initialization is done, you should run the commands within “StoredProc_v1.0.sql” to generate the stored procedures that are used by our application to execute methods.
When done with the above, you can then run the “WebApi” and the “Password Manager Desktop Client” projects. This should launch our API which will be used by the desktop application to communicate with the database, so you can retrieve your passwords. 

One important note, the desktop client only works on Windows machines. Unfortunately, with the way our application handles some data within the models, using Swagger/Postman will also be an issue. So we will attach a video on how the application works.
