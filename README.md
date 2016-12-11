# Karellen

Karellen � o projeto de conclus�o de curso de [Daniel Ramos](https://www.facebook.com/profile.php?id=100013298985823) e Lucas Coelho

Dispon�vel aqui: http://karellen.azurewebsites.net

> O Karellen � o sistema web para gerenciamento de ocorr�ncias criminais, em que o cidad�o pode colocar no mapa crimes que ocorreram no seu bairro

[![N|Solid](http://i.imgur.com/4Jvx6Ul.png)](http://karellen.azurewebsites.net)

## Depend�ncias

* .NetFramework 4.5
* Visual Studio 2013+
* O banco aponta para sql server 2016+. Alterar se precisar rodar no sql server 2014
* As deped�ncias de front end s�o gerenciadas com Bower. N�o obrigat�rio, mas se quiser adiciona algo, precisa usar o bower, npm e node

## Build

 * Clone
 * Abrir o .sln no visual studio
 * Clean
 * Build
 * Rodar Base inicial e carga.sql
 * Salsa :dancer:

### Ultimas considera��es

* A chave usada � inserida via build. Mesmo a chave que est� no hist�rico dos commits est� desativada
* A chave do sendgrid est� desativada
* TODO: Fazer uma api

Qualquer d�vida, abrir issue :)