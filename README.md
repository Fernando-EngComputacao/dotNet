
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
### 1.2.1 Configuração de Dependências
- **1° Ação:** abra o gerenciador de dependências em: 
  ```Ferramentas``` > ```Gerenciador de Pacotes do NuGet``` > ```Gerenciar Pacotes do NuGet para a Solução...```
- **2° Ação:** na abra do ```NuGet - Solução```, acesse o submenu ```Procurar``` e pesquise por:

```v-5.0.5```
~~~
EntityFrameWorkCore
~~~ 
```v-5.0.3```
~~~
Mysql.EntityFrameWorkCore 
~~~

## 1.3 Configuração Banco de Dados
- **1° Ação:** crie uma pasta, na raiz, de nome ```Data```
- **2° Ação:** crie uma classe na pasta ```Data``` de nome ```FilmeContext```
- **3° Ação:** acesse o ```appsettings.json```
- **4° Ação:** no arquivo acessado, encontre por ```"AllowedHosts": "*"``` e adicione abaixo a seguinte expressão:
~~~
,
"ConnectionStrings": {
    "FilmeConnection": "server=localhost;database=filmeDb;user=root;password=root"
}
~~~
- **5° Ação:** acesse, na raiz, o arquivo ```Startup.cs```
- **6° Ação:** encontre a função: 

```public void ConfigureServices(IServiceCollection service)```
- **7° Ação:** nesta função, faça a seguinte configuração:
~~~
services.AddDbContext<FilmesContext>(opts => opts.UseMySQL(STRING-DE-CONEXAO));
~~~
Substitua em ```STRING-DE-CONEXAO``` (acima no códgio) a sua string de conexão, que neste caso é:
~~~
Configuration.GetConnectionString("FilmeConnection")
~~~


