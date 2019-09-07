# Repository Design Pattern
The Repository design pattern is a way to organize your code so your data retrieval logic is separated from your business logic.  This decouples your data source layer from your business logic so the data source layer can be seamlessly swapped to another source if needed.  The actual Repository is a mediator between the two layers that queries the data.  The benefits to doing this allow for better testing, it centralizes the data logic, and provides a more flexible architecture.  This pattern is useful if you need to isolate the data layer to support unit testing, create a centralized data source that has consistant access rules and logic, and maintain the codes readability.

In this project, we are accomplishing this layer of seperation by adding these classes. . . 

#### Level of Seperation

Register in the startup
```c#
    services.AddScoped<IRepository, RepositoryService>();
```

Create Interface
```c#
````

Create Service, which connects to the DB
```c#
```

Inject on desired controllers/classes
```c#

    public class HomeController : Controller
    {
        private readonly IRepository _context;

        public HomeController(IRepository context)
        {
            _context = context;
        }
    }
```
Notice the seperation. . .







