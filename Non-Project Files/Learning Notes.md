# RPG Learning Notes

## Helpful Hints
Ctrl + r, Ctrl + r = Rename all

m_varName means 'member' variable

To use followcam, tag Player as Player and Camera as MainCamera

## Utilities class
To hold stuff accessible across game
e.g. create a'Layer' enum to hold the integer values of different layers. `Walkable = 10,` etc


## Getters

*Used to expose private things without declaring a new function*

```
RaycastHit m_hit;
public RaycastHit hit{
	get { return m_hit; }
}
```

## Out Parameters
Declare first, then pass as parameter. The method then sets that variable while it runs:
``` 
RaycastHit hit; //used as out parameter
bool hasHit = Physics.Raycast(ray, out hit, distance, layerMask);
if(hasHit){ return hit }
// See?
```

## Nullable parameter
```
MethodType? MethodName(params){}
```
Method is supposed to return something, but may return null.

## Ensure emties (for grouping) are zero-transformed

## Folder Naming
Why bother organising by filetype when you can search by filetype?
Organise by function.

## Affordances
"Though additional meanings have developed, the original definition in psychology includes all transactions that are possible between an individual and their environment. When the concept was applied to design, it started also referring to only those physical action possibilities of which one is aware."

**Also**

Afford:
"The possibility of an action on an object or environment"