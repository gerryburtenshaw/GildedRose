# GildedRose

This project was created in VisualStudio 2015 using Web API 2 and .NET 4.6 Framework

The following RESTful APIs are supported


* `(GET) /api/item` => return all items in the inventory
* `(GET) /api/item/{itemname}` => returns a specific item OR a 404 Http Response if the item does not exist
* `(GET) /api/item/{itemname}/buy` => return the item just purchased OR a 401 if credentials are not valid or 404 if item is not valid.



For this project, I chose to have the API responses return JSON formatted data. It would be ideal to have the user the freedom to specify which format to return. Here are a few strategies as to how to go about doing this: 

* Using HTTP Headers such as Accept or Content-Type on the request
* Command url parameter specifying the return format
* Include the desired format via the RESTful URL itself. For example: api/item/{itemname}.{ext}, where {ext} would represent the response format.

## Example: Get the inventory

`REQUEST`
```css
(GET) http://localhost:50171/api/item
```
`RESPONSE`
```json
[
   {
		"Name": "Tomato Soup",
		"Description": "Groceries",
		"Price": 1
	},
	{
		"Name": "Yo-yo",
		"Description": "Round thing with string attached",
		"Price": 3
	},
	{
		"Name": "First born",
		"Description": "Hardware",
		"Price": 16
	},
	{
		"Name": "Trov",
		"Description": "On demand insurance",
		"Price": 16
	}
]
```

## Authentication Model:

For this exercise, I used HTTP Basic Authentication solely for it's simplicity.  

However, a Digest Authentication would have been a much better choice in this scenario. 
Especially given that we are using HTTP and not HTTPS. (The latter being a requirement in order to make Basic Authentication secure in any sense of the word)

The user credentials that are hardcoded in place, and can be used within the tests, are as follows:
- Dave(Dave123)
- Gerry(Gerry123)

## Testing:

Included are 3 levels of testing:

1. *UnitTest* : GildedRoseTests visual studion project as part of the solution. Utilizes the Microsoft.VisualStudio.QualityTools.UnitTestFramework and can be investigated and ran using Visual Studio's Test Explorer
2. *Integration* : http://localhost:50171/playpen.html provides a sample usage of the API in an integrated environment (webpage) and manual testing
3. *Continuous Integration* : http://localhost:50171/autotestapi.html runs and reports on some automatic integration tests and also provides example Javascript usage of the GildedRose JS module. 

NOTE: The web UI and behaviour is by no means complete (or pretty) but, rather, strives to illustrate concepts and ideas.