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

