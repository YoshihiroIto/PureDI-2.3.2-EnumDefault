# Pure.DI 2.3.2 Enum Default Value Repro

This folder contains a minimal reproduction for a Pure.DI 2.3.2 build error:

`CS1503: cannot convert from 'int' to '<EnumType>'`

## Repro structure

- `PureDI.EnumDefault.Repro.csproj`: Console app using `Pure.DI`
- `Program.cs`: DI setup + service with optional enum parameter
- `Repro.Domain/Repro.Domain.csproj`: Separate assembly containing the enum
- `Repro.Domain/FileItemFormats.cs`: Enum where `Archive` is non-zero (`7`)

## Repro steps

1. Build with Pure.DI `2.3.2`:

```powershell
dotnet build PureDI.EnumDefault.Repro.csproj -c Release -p:PureDiVersion=2.3.2
```

2. Confirm it fails with:

```text
error CS1503: Argument 8: cannot convert from 'int' to 'Repro.Domain.FileItemFormats'
```

3. Build with Pure.DI `2.3.1`:

```powershell
dotnet build PureDI.EnumDefault.Repro.csproj -c Release -p:PureDiVersion=2.3.1
```

4. Confirm it succeeds.

## Optional generated code comparison

2.3.2 emits:

```csharp
new global::Service(..., 7);
```

2.3.1 emits:

```csharp
new global::Service(...);
```

This indicates 2.3.2 passes an `int` literal instead of using/omitting the enum optional value.
