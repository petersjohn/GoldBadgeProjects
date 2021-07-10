## Komodo Cafe Challenge 1

### Tasks To Complete
- Create a Menu Class with properties, constructors, and fields.
- Create a MenuRepository Class that has methods needed.
- Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
- Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.


### Menu Class 
- ItemName (string)
- ItemNumber (int)
- ItemDescription (string)
- ItemPrice (decimal)
- ItemIngredients(List)

### Repo Methods

  CRUD Type     Return      MethodName(parameter)

- Create:       **bool**    AddItemsToMenu(*Object*)

- Read:         **List**    GetMenu()
                **Object**  GetMenuContentByItemNumber(*int*)

- Delete:        **bool**   DeleteItemByNumber(*int*)

### Project Status

7/9/21: Achieved minimum viable product
7/10/21: Repo Unit testing complete

