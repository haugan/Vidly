# Vidly
I'm building a RESTful web application that performs CRUD operations to a SQL database through Entity Framework, 
in "classic" ASP.NET MVC (plus some nice JavaScript libraries) in order to dwelve deeper and more fully understand 
the foundation ASP.NET Core was built upon, following a great course on Udemy from Mosh Hamedani. The web app will in part be architectured like a Single Page Application (SPA) utilizing ASP.NET Web API (on the server), creating APIs that get "consumed" by jQuery AJAX (on the client). Future updates will work towards making the entire web app a SPA with client-side Angular 4, and all security related authentication and authorization of users will be handled by ASP.NET Identity.



### Pagination, sorting, & search
The index tables feature sorting, pagination, and search - 
made easy (and highly customizable) thanks to the DataTables plugin!

![Customer index table](https://s13.postimg.org/a3nuhovon/vidly1.png)

### Client & server side validations
When creating a new customer, each form input is validated - 
either using default ASP validation or custom business rules like shown below!

![New customer form](https://s21.postimg.org/6ie4z5b6v/vidly2.png)

### Action prompts
Make your users think twice before doing something they (maybe) shouldn't - 
easily customizable prompts using the Bootbox library for jQuery!

![Important action confirmation prompt](https://s9.postimg.org/n049d0een/vidly3.png)
