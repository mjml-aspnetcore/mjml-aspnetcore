# mjml-aspnetcore

![Nuget](https://img.shields.io/nuget/dt/Mjml.AspNetCore.svg)

MJML is a responsive email templating system. You can find more information on MJML here: https://mjml.io/

Mjml-AspNetCore is built on top of NodeServices (https://github.com/aspnet/AspNetCore/tree/master/src/Middleware/NodeServices)

A render script has been bundled and will call the MJML renderer and return the compiled script.

```csharp
var prehtml = "<mjml><mj-body></mj-body></mjml>";
var result = await _mjmlServices.Render(prehtml);
```

You can also use JSON instead of XML, as described here: https://mjml.io/documentation/#using-mjml-in-json

```csharp
var view = 
@"{
    tagName: 'mjml',
    attributes: {},
    children: [{
        tagName: 'mj-body',
        attributes: {},
        children: [{
            tagName: 'mj-section',
            attributes: {},
            children: [{
                tagName: 'mj-column',
                attributes: {},
                children: [{
                    tagName: 'mj-image',
                    attributes: {
                        'width': '100px',
                        'src': '/assets/img/logo-small.png'
                    }
                },
                {
                    tagName: 'mj-divider',
                    attributes: {
                        'border-color' : '#F46E43'
                    }
                }, 
                {
                    tagName: 'mj-text',
                    attributes: {
                        'font-size': '20px',
                        'color': '#F45E43',
                        'font-family': 'Helvetica'
                    },
                    content: 'Hello World'
                }]
            }]
        }]
    }]
}";
var result = await mjml.RenderFromJson(view);
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
