# Boilerplate SOAP Service in .NET Core

### Set up info

- Using Postman, create a new POST request with the following URL: `http://localhost:5230/ServicePath.asmx`.
- Choose Basic Auth in the Authorization tab and enter Username = "user", Password = "password".
- In the body section select "raw" and paste in the following code:

```xml
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:web="IMySoapService">
    <soap:Body>
        <web:HelloWorld>
            <name>Paul</name>
        </web:HelloWorld>
    </soap:Body>
</soap:Envelope>
```

Note that the service entry point. Note how `IMySoapService` in the XML envelope refers to the interface implemented by `MySoapService`. Also note how `HelloWorld` mapss to the endpoint method name.

```csharp
namespace SoapApi
{
    public class MySoapService : IMySoapService
    {
        public string HelloWorld(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
```