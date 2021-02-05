#!/usr/bin/env dotnet-script


#r "nuget: libplctag, 1.0.3"

using libplctag;
using libplctag.DataTypes;
using System;
using System.Net;
using System.Threading;

public class Udt
{
	public bool MyBool { get; set; }
	public Int32 MyDint {get;set;}
	public Int16 MyInt {get;set;}
	public SByte MySint {get;set;}
	public float MyReal {get;set;}
	public Double MyLReal {get;set;}
	public AbTimer MyTimer {get;set;}
	public string MyString{get;set;}
	public Int64 MyLint {get;set;}
}

public class CrosserUdtMapper : PlcMapperBase<Udt>, IPlcMapper<Udt>, IPlcMapper<Udt[]>
{
	public override int? ElementSize => 972;

	public override Udt Decode(Tag tag, int offset)
	{
		Udt udt = new();
		udt.MyBool = tag.GetBit(offset + 0);
		udt.MyDint = tag.GetInt32(offset + 4);
		udt.MyInt = tag.GetInt16(offset + 8);
		udt.MySint = tag.GetInt8(offset + 12);
		udt.MyReal = tag.GetFloat32(offset + 16);
		udt.MyLReal = tag.GetFloat64(offset + 24);

		return udt;
	}

	public override void Encode(Tag tag, int offset, Udt value)
	{
		return;
	}
}

//Instantiate the tag with the proper mapper and datatype

/*
 AllenBradley	C#		Len
 bool			bool	1
 DInt			Int32	32
 Int			Int16	16
 Lint			Int64	64
 LReal			Double
 Real			float
 SInt			Sbyte
 String
 Timer
*/

// Path = 1, 0... 1 for ethernet, 0 for slot
var settings = new {
	Gateway = "192.168.1.1",
	NamePrefix = "Program:MainProgram.",
	Path = "1,0",
};

var tags = new List<ITag>();

// tags.Add(new Tag<CrosserUdtMapper, Udt>()
// {
// 	Name = $"{settings.NamePrefix}udt",
// 	Gateway = settings.Gateway,
// 	Path = settings.Path,
// 	PlcType = PlcType.ControlLogix,
// 	Protocol = Protocol.ab_eip,
// 	Timeout = TimeSpan.FromSeconds(5)
// });

tags.Add(new Tag<DintPlcMapper, Int32>()
{
	Name = $"{settings.NamePrefix}dint_array",
	//ArrayDimensions = new int[2],
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<DintPlcMapper, Int32[]>()
{
	Name = $"{settings.NamePrefix}dint_array2",
	ArrayDimensions = new int[2],
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<DintPlcMapper, Int32>()
{
	Name = $"{settings.NamePrefix}dint_array3[1][1][1]",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<DintPlcMapper, Int32>()
{
	Name = $"{settings.NamePrefix}dint",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<DintPlcMapper, Int32>()
{
	Name = $"{settings.NamePrefix}dint_nowrite",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<DintPlcMapper, Int32>()
{
	Name = $"{settings.NamePrefix}dint_noread",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<BoolPlcMapper, bool>()
{
	Name = $"{settings.NamePrefix}bool",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<IntPlcMapper, Int16>()
{
	Name = $"{settings.NamePrefix}int",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<RealPlcMapper, float>()
{
	Name = $"{settings.NamePrefix}real",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<LrealPlcMapper, Double>()
{
	Name = $"{settings.NamePrefix}lreal",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<SintPlcMapper, SByte>()
{
	Name = $"{settings.NamePrefix}sint",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<StringPlcMapper, string>()
{
	Name = $"{settings.NamePrefix}string",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

tags.Add(new Tag<TimerPlcMapper, AbTimer>()
{
	Name = $"{settings.NamePrefix}timer",
	Gateway = settings.Gateway,
	Path = settings.Path,
	PlcType = PlcType.ControlLogix,
	Protocol = Protocol.ab_eip,
	Timeout = TimeSpan.FromSeconds(5)
});

// tags.Add(new Tag<TagInfoPlcMapper, TagInfo[]>()
// {
// 	Name = $"Program:MainProgram",
// 	Gateway = settings.Gateway,
// 	Path = settings.Path,
// 	PlcType = PlcType.ControlLogix,
// 	Protocol = Protocol.ab_eip,
// 	Timeout = TimeSpan.FromSeconds(5)
// });

foreach(var tag in tags)
{
	try
	{
		Console.WriteLine($"Writing... {tag.Name} on {tag.PlcType.Value}");
		SetValue(tag);
		await tag.WriteAsync();
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error writing: {ex.Message}");
	}

	try
	{

		Console.WriteLine($"Reading... {tag.Name} from {tag.PlcType.Value}");
		await tag.ReadAsync();
		Console.WriteLine($"{tag.Name} : {GetValue(tag)}");
	}
	catch(Exception ex)
	{
		Console.WriteLine($"Error reading: {ex.Message}");
	}
}

dynamic GetValue(ITag tag)
{
	switch(tag)
	{
		case Tag<DintPlcMapper, Int32> dint:
			return dint.Value;
		case Tag<DintPlcMapper, Int32[]> dinta:
			return dinta.Value;
		case Tag<BoolPlcMapper, bool> b:
			return b.Value;
		case Tag<IntPlcMapper, Int16> i16:
			return i16.Value;
		case Tag<LrealPlcMapper, Double> d:
			return d.Value;
		case Tag<RealPlcMapper, float> f:
			return f.Value;
		case Tag<SintPlcMapper, SByte> sb:
			return sb.Value;
		case Tag<StringPlcMapper, string> str:
			return str.Value;
		case Tag<TimerPlcMapper, AbTimer> t:
			return t.Value.Accumulated;
		default:
		return 0;
	}
}

void SetValue(ITag tag)
{
	switch (tag)
	{
		case Tag<DintPlcMapper, Int32> dint:
			dint.Value = 111;
			break;
		case Tag<BoolPlcMapper, bool> b:
			b.Value = true;
			break;
		case Tag<IntPlcMapper, Int16> i16:
			i16.Value = 16;
			break;
		case Tag<LrealPlcMapper, Double> d:
			d.Value = 123.33d;
			break;
		case Tag<RealPlcMapper, float> f:
			f.Value = 321.444f;
			break;
		case Tag<SintPlcMapper, SByte> sb:
			sb.Value = 1;
			break;
		case Tag<StringPlcMapper, string> str:
			str.Value = "Monkey";
			break;
		case Tag<TimerPlcMapper, AbTimer> t:
			t.Value = new AbTimer(){
				Preset = 3000,
	 			Accumulated = 45,
				Enabled = true,
			};
			break;
		default:
			return;
	}
}


Console.WriteLine("Hello world!");
