
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
