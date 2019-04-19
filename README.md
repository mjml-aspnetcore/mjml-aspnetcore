mjml-aspnetcore

![Nuget](https://img.shields.io/nuget/dt/Mjml.AspNetCore.svg)

MJML is a responsive email templating system. You can find more information on MJML here: https://mjml.io/

Mjml-AspNetCore is built on top of NodeServices (https://github.com/aspnet/AspNetCore/tree/master/src/Middleware/NodeServices)

A render script has been bundled and will call the MJML renderer and return the compiled script.

```csharp
var prehtml = "<mjml><mj-body></mj-body></mjml>";
var result = await _mjmlServices.Render(prehtml);
```

You can add dependancy support in your startup.cs file like this:

```csharp
// add render services
services.AddMjmlServices(o =>
{
    if (Environment.IsDevelopment())
    {
        o.DefaultKeepComments = true;
        o.DefaultBeautify = true;
    }
    else
    {
        o.DefaultKeepComments = false;
        o.DefaultMinify = true;
    }
});
```
