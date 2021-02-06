# Common features

## Use Flags and directives

Use flags and directives in code, so that you can come back later and work on it.

You can use the #warning and #error directives,

```csharp
#warning This is dirty code...
#error Fix this before everything explodes!
```

Also you can mark it with "//TODO:" or "//FIXME:" comments that show up in the task pane in IDE or for fast search.

# Classes

## Declaration order

- Static:
  - Static constructor (if needed)
  - Private
  - Public
  - Protected
- All constructors and descructors
  - public first  
- Non Static:
  - private fields
  - public properties
  - public methods
  - protected methods
  - private methods

# Formating

## Indent

Use spaces (not tabulation) for writing code. Every indent (tab space) should contain 4 spaces.

## Blank lines

One blank line should always be used between:

- Methods
- Properties
- Logical sections inside a method to improve readability.

## Line length

Maximum line length 150 characters.
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

