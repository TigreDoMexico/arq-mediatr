# Architecture With MediatR

## What Is MediatR
Mediatr is a .NET library that implements the Mediator Pattern. Each request needs two different classes: <br/>
- Request Content: A Class that implements an IRequest interface
- Request Handler: A Class that implements an IRequestHandler interface

While the Request Content contains what the request require to be successful, the Handler is responsible to get the IRequest and execute the business logic.
<br/>
The MediatR distinguish which Handler will be executed through the Content. That is the work of the Mediator.