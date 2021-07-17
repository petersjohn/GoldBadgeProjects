# Badge Administration Challenge 3

## Requirements: 
> **Create a Badge class with the following properties:**
> 1. A BadgeID (int)
> 2. List of door names (strings).
> 3. A name for the badge.
 

> **Create a badge repository:**
> 1. Create a dictionary of badges.
> 2. The key for the dictionary will be the BadgeID.
> 3. The value for the dictionary will be the Badge.
 

> **The Program will allow a security staff member to do the following:**
> - create a new badge
> - update doors on an existing badge.
> - delete all doors from an existing badge.
> - show a list with all badge numbers and door access

> Note: Make sure to keep the responsibilities of your UI, your repo, and your tests separate.
> Only your UI class should ever take input from the user.


# Objects/Properties

| Crud Type  | Return  | Method Name             | Parameters  | Description                                                                                                                       |
|------------|---------|-------------------------|-------------|-----------------------------------------------------------------------------------------------------------------------------------|
| Create     | bool    | AddNewBadgeToList       | object      | Adds a new badge object to the _badges List                                                                                       |
| Create     | bool    | AddBadgeToDictionary    | int, object | Adds a new badge entry to the the badgeDictionary                                                                                 |
| Read       | bool    | CheckDictionary         | int         | Checks to see if a key value exists in the dictionary                                                                             |
| Read       | List    | GetAllBadgesFromList    |             | Returns all Badges from the _badges List                                                                                          |
| Read       | Object  | GetBadgeByBadgeID       | int         | Returns the badge object by the badge id                                                                                          |
| Update     | void    | RemoveDoorsFromBadge    | int, object | Iterates over the list of doors on the badge, and for each match in the removal list, it removes the door from the parent object  |
| Update     | bool    | UpdateBadgeDictionary   | int, object | Updates the badge object in the badgeDicitionary for the provided key                                                             |
| Update     | bool    | AddNewDoorsToBadge      | int, List   | iterates over a list of badges and adds them to the badge.Doors list. This method is intended for badges that already have doors  |
| Update     | bool    | AddBadgesToNullList     | int, List   | creates a List Object of doors to add to a badge that has a null badge.Doors.                                                     |
| Update     | bool    | RemoveAllDoorsFromBadge | int         | Removes all Doors from a badge                                                                                                    |
