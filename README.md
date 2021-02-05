# RockwellSnippets

Snippets for testing communication with Rockwell/AllenBradley PLCs


## Setup & Debug

 1. Install vs-code & the Omnisharp/C# extension

 2. Install dotnet-script

	```
	dotnet tool install -g dotnet-script
	```

 3. Debug by opening a `.csx` file and hit F5


 ## DataTypes Conversion

 AllenBradley	C#		Len
 bool			bool	1
 DInt			Int32	32
 Int			Int16	16
 Lint			Int64	64
 LReal			Double
 SInt			Sbyte
 String
 Timer