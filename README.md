# GildedRose

This project supports the following RESTful API

````
(GET) /api/item => return all items in the inventory
(GET) /api/item/{itemname} => returns a specific item OR a 404 Http Response if the item does not exist
(GET) /api/item/{itemname}/buy => return the item just purchased OR a 401 if credentials are not valid or 404 if item is not valid.
````


For this project, I chose to force API responses to return JSON formatted data. Ideally, I would like to have the user the freedom to specify,
for themselves, which format to return. There are a few ways to go about doing this 
(Using HTTP Headers such as Accept or Content-Type on the request, or a command url parameter or even include the desired format via the RESTful URL itself.)

Example: Get inventory:

`REQUEST`
```css
(GET) http://localhost/api/item
```
`RESPONSE`
```json
[{"Name":"Tomato Soup","Description":"Groceries","Price":1},{"Name":"Yo-yo","Description":"Round thing with string attached","Price":3},{"Name":"First born","Description":"Hardware","Price":16},{"Name":"Trov","Description":"On demand insurance","Price":16}]
```

Testing:

Included are 3 levels of testing:

UnitTest : GildedRoseTests visual studion project as part of the solution. Utilizes the Microsoft.VisualStudio.QualityTools.UnitTestFramework and can be investigated and ran using Visual Studio's Test Explorer
Integration : http://localhost/sandbox.html provides a sample usage of the API in an integrated environment (webpage)
Continuous Integration : http://localhost/autotestapi.html runs and reports on some automatic integration tests and also provides example Javascript usage of the GildedRose JS module. 

NOTE: The web UI and behaviour is by no means complete (or pretty) but, rather, strives to illustrate concepts and ideas.