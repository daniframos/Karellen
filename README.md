# Karellen

Karellen é o projeto de conclusão de curso de [Daniel Ramos](https://www.facebook.com/profile.php?id=100013298985823) e Lucas Coelho

Disponível aqui: http://karellen.azurewebsites.net

> O Karellen é o sistema web para gerenciamento de ocorrências criminais, em que o cidadão pode colocar no mapa crimes que ocorreram no seu bairro

[![N|Solid](http://i.imgur.com/4Jvx6Ul.png)](http://karellen.azurewebsites.net)

## Dependências

* .NetFramework 4.5
* Visual Studio 2013+
* O banco aponta para sql server 2016+. Alterar se precisar rodar no sql server 2014
* As depedências de front end são gerenciadas com Bower. Não obrigatório, mas se quiser adiciona algo, precisa usar o bower, npm e node

## Build

 * Clone
 * Abrir o .sln no visual studio
 * Clean
 * Build
 * Rodar Base inicial e carga.sql
 * Salsa :dancer:

### Ultimas considerações

* A chave usada é inserida via build. Mesmo a chave que está no histórico dos commits está desativada
* A chave do sendgrid está desativada
* TODO: Fazer uma api

Qualquer dúvida, abrir issue :)