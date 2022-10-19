
# API Web em ASP NET Core - Fernando Furtado :boy:
Este é um projeto ASP NET Core API REST.   
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)  
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://choosealicense.com/licenses/gpl-3.0/)  
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](https://choosealicense.com/licenses/gpl-3.0/)

# 1. Passo a passo
## 1.1. Iniciar Projeto
- **1° Ação:** clique em criar projeto;

- **2° Ação:** digite ```api``` e selecione o primeiro elemento de pesquisa;

- **3° Ação:** digite o nome do projeto e clique em "Próximo";

- **4° Ação:** em ```FrameWork``` selecione  ```.NET 5``` e confirme;

- **5° Ação:** apagar o arquivo dentro de ```Controllers``` e o arquivo ```WeatherForecast.cs```;

## 1.2. Configurar Projeto
- **1° Ação:** para alterar a porta, basta entrar em ```Properties/launchSettings.json``` e alterar as portas em ```applicationUrl```, exemplo:
    ~~~
    "applicationUrl": "https://localhost:5000;http://localhost:5001",
    ~~~ 
- **2° Ação:**

## Configurações do projeto no Spring Start  
- **Project:** Maven Project 
- **Language:** Java
- **Spring Boot:** 2.7.4
- **Packagem:** JAR
- **Java:** 11
- **Dependeces:** 
    - Spring Web
    - H2 Database
    - Spring Data JPA
    - Spring Boot DevTools
    - Spring Data JDBC
    - Validation

 ## Properties (application.properties)
**Propriedades:** entre em -> src/main/resources/application.properties
~~~bash  
server.port=8081

# data source
spring.datasource.driver-class-name=org.h2.Driver
spring.datasource.driverClassName=org.h2.Driver
spring.datasource.url=jdbc:h2:mem:alura-forum
spring.datasource.username=sa
spring.datasource.password=

# jpa
spring.jpa.database-platform=org.hibernate.dialect.H2Dialect
spring.jpa.hibernate.ddl-auto=update
spring.jpa.properties.hibernate.show_sql=true
spring.jpa.properties.hibernate.format_sql=true

# Nova propriedade a partir da versao 2.5 do Spring Boot:
spring.jpa.defer-datasource-initialization=true

# h2
spring.h2.console.enabled=true
spring.h2.console.path=/h2-console
~~~

**Base de dados:** entre em -> src/main/resources e crie um documento de nome (data.sql). Após copie e cole o código abaixo: 

~~~bash  
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Advenders Ultimato','Fantasia',215,1);
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Avatar 2','Aventura',255,2);
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Procurando Nemo','Fantasia',185,3);
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Minha mãe é uma peça','Drama',225,4);
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Adão Negro','Fantasia',205,5);
INSERT INTO MOVIE(nome, genero, duracao, posicao) VALUES('Iti','Terror',195,6);
~~~

# Classe Startup

**1.** Se seu projeto é .NET 5 ou anterior a classe ```Startupc.cs``` já existe.

**2.** Agora, se você está utilizando .NET 6 ou versão superior, uma das possíbilidade é criar esta classe na pasta raíz e inserir o seguinte código:
~~~bash
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}

~~~
**2.1** Renomeie o ```WebApplication1```, no código acima para o nome de seu projeto criado. 

**2.2** Em seguida, substitua os códigos da classe ```Program.cs``` por:

~~~
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
~~~

**3.** Agora, insira o seguinte código na pasta ```Startup.cs``` e adicione no método ```ConfigureServices```, conforme o código abaixo:
~~~
using Movie;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();


~~~ 

**3.1** Perceba, no código acima, que o 'using Movie;' é o nome do projeto, por isso o substitua pelo nome de seu projeto (raiz).