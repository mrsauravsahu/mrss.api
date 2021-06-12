# mrss

dotnet solution with which I'll be learning dotnet in #100daysofdotnet. If you're learning dotnet as well or just wanna chat, you can find me on twitter - [@mrsauravsahu](https://twitter.com/mrsauravsahu)

## tech

```bash
$ dotnet --version
5.0.301
```

```bash
$ docker --version
Docker version 20.10.6, build 370c289
```

## local setup

### up the services
use docker compose to get started quickly when running the project locally.

Run `$ docker compose up -d` at the root of the project.

### check service status

You should see the services coming up with 
```bash
$ docker compose ps
NAME                SERVICE             STATUS              PORTS
portfolio_api_1     api                 running             0.0.0.0:5000->5000/tcp, :::5000->5000/tcp
```

### head over to the playground

Open up http://localhost:5000/ui/playground to use the GraphQL Playground.

Now, fire away your queries!

Here's the most simple query you can hit

```graphql
{
  about {
    name
    version
  }
}
```

which should give you something like:

```json
{
  "data": {
    "about": {
      "name": "mrss.api",
      "version": "v0.0.1"
    }
  },
  "extensions": {}
}

```

### la fin

That's it! - [Saurav](https://twitter.com/mrsauravsahu)