# Naming rules

Use PascalCase

```csharp
TheMethod
```
Or  camelCase

```csharp
theMember
```
in all naming.

Naming rules:

- Use only PascalCase or camelCase;
- Naming consts, readonly fields, classes, methods, properties, namespaces, structures, enumes, etc., use PascalCase;
- Naming variables, private fields, parameters in methods, constructors, etc use camelCase;
- Use prefix '_ ' with camelCase for private fields;
- No type-prefix for any variables;
- Don't use any word 'enum' or 'flags' for enums;
- Intefrace must be like 'INameIntefrace';
- Don't use names for classes, which match classes from .Net Framework;
- Any Exception must ends with 'Exception' word.

## Use Flags and directives

Use flags and directives in code, so that you can come back later and work on it.

You can use the #warning and #error directives,

```csharp
#warning This is dirty code...
#error Fix this before everything explodes!
```

Also you can mark it with "//TODO:" or "//FIXME:" comments that show up in the task pane in IDE or for fast search.

# Formating

## File formating

- First license text or file description
- All 'using'
- Current namespace with code of class, enum, interface, etc.
- Don't leave code commented out. The code should be in Git in previous commits. Leave comments.

## Declaration order

- Consts and fields
- Propertis from private to public
- Constructors
- All methods from public to private in the end

## Methods
- The maximum number of parameters is 7, preferably 5, if more - a structure or class is created
- out-parameters declare in the end
- use minimum required type
- Try to write the method in height of the screen, large methods should be divided into smaller ones

## Indent

Use spaces (never tabulation) for writing code. Every indent (tab space) should contain 4 spaces.

## Blank lines

One blank line should always be used between:

- Methods
- Properties
- Logical sections inside a method to improve readability.

## Line length

Maximum line length 120 characters.
Preferred line length is 80-100 characters, taking into consideration the recommendations below:

- Break after a comma.
- Break after an operator.
- Align the new line with the beginning of the expression at the same level on the previous line.

## Spaces in line

One space must be

- After comma (if comma last character - space unnesesary)
- By the left and right side of:
  - any operator
  - colon
  - lambda operator
  - opening and closing block brackets '{' and '}'

No space between method name and parameter opening bracket

This good:
```csharp
public class Rectangle : Geometric, IRectangle
{
  public int RectangleArea(int x, int y)
  {
    return x * y;
  }
  
  public int RectanglePerimeter(int x, int y) => x * 2 + y * 2; 
}
```

