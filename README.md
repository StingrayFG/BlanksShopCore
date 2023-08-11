This project implements backend features of the BlanksShop application. Frontend project can be found here: https://github.com/StingrayFG/BlanksShopUI.

Infrastructure layer is used to interact with the database. Repositories and database-compatible entities are implemented here. This layer is based on Entity Framework.

Presentation layer includes controllers based on ASP NET Core and Swagger. It interacts with Application layer and services, implemented there. This layer implements API which can be used to interact with frontend part of this application. 

Application layer implements services which are used to work with three other layers. Services are used to convert data coming from Presentation layer to entities, which can be used in business logic.

Domain layer includes POCO Entities, which are used by application layer and services, located there.
