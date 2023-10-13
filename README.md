## Simple Password Manager

This password manager requires that you run our SQL Scripts found within our project. The first script to run should be the “InitDB_v1.0.sql” file. The commands within it should be run so as to initialize the database, providing it with the same name as what is used within our project connection string. Which is meant to connect to a local instance of your SQL Server. Once the initialization is done, you should run the commands within “StoredProc_v1.0.sql” to generate the stored procedures that are used by our application to execute methods.
When done with the above, you can then run the “WebApi” and the “Password Manager Desktop Client” projects. This should launch our API which will be used by the desktop application to communicate with the database, so you can retrieve your passwords. 

One important note, the desktop client only works on Windows machines. Unfortunately, with the way our application handles some data within the models, using Swagger/Postman will also be an issue. So we will attach a video on how the application works.

The web api is using JWT for authorization and HTTP-Only cookies to ensure that JS can't tamper with it. When a user is created or logs in, their encypted vault is sent to the client (desktop app) where it gets decrypted. The user can then add new entries and when ready encypt back the valt which sends in back to the database. The encyption is done using AES-GCM with key size of 256 bits. Hashing is done with Argon2id with salt size of 128 bits.

Showcase of the password manager descktop client:

https://github.com/Natorden/Simple-Password-Manager/assets/73466420/164c52d3-96ca-4f4e-bc12-ac9bd740e33d

Diagrams:

![Architecture](https://github.com/Natorden/Simple-Password-Manager/assets/40688355/622255f9-2eaf-4401-ae3f-6b57096fb3c1)
![Key Deriviation Flow](https://github.com/Natorden/Simple-Password-Manager/assets/40688355/84035dc0-e76d-487e-b871-3523c259adcf)
![System Sequence Diagram](https://github.com/Natorden/Simple-Password-Manager/assets/40688355/653df35f-e706-461b-bad9-79b0221d7789)
