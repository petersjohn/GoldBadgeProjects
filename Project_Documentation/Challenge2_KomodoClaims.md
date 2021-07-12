## Komodo Claims Challenge 2

### Tasks to Complete
> Show a claims agent a menu:
> Choose a menu item:
> 1. See all claims
> 2. Take care of next claim
> 3. Enter a new claim

For #2, when a claims agent needs to deal with an item they see the next item in the queue.

### Example:
> - ClaimID: 1
> - Type: Car
> - Description: Car Accident on 464.
> - Amount: $400.00
> - DateOfAccident: 4/25/18
> - DateOfClaim: 4/27/18
> - IsValid: True
> - Do you want to deal with this claim now(y/n)? y
> -  When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent >  presses 'n', it will go back to the main menu.
 >

## Objects/Properties
### Claims
- ClaimID (int)
- TypeOfClaim (enum ClaimType)
- Description (string)
- DateOfAccident (DateTime)
- DateOfClaim (DateTime)
- IsValid (bool -- readonly property)

## Repository Methods
| CRUD Type | Return | Method Name     | Parameter(s)   |
|-----------|--------|-----------------|----------------|
| Create    | bool   | AddClaimToList  | Claims(object) |
| Create    | bool   | AddClaimToQueue | Claims(object) |
| Read      | list   | ReturnAllClaims |                |
| Read      | Queue  | ReturnQueue     |                |
| Delete    | bool   | Delete Claim    | Claims(Object) |
| Delete    | bool   | RemoveFromQueue |                |


### Project Status

- 7/10/21 Basic CRUD Complete, REPO completed, UI started to test displaying the list/queue of claims
- 7/11/21 minimum viable product! Still need unit testing
- 7/11/21 unit testing complete for mvp


