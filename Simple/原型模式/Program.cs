using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 原型模式
{


	public class Engine
	{
		public String Name { get; set; }			//发动机名称
		public String Displacement { get; set; }	//排量
	}
	public class Car : ICloneable
	{
		public String Name { get; set; }			//名称
		public String Color { get; set; }			//颜色
		public Engine Engine { get; set; }			//引擎信息



		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Car carInstance = new Car() { Name = "奥迪", Color = "黑色" };
			Console.WriteLine("车辆名称：{0} 颜色：{1} ", carInstance.Name, carInstance.Color);
			carInstance = (Car)carInstance.Clone();

			Console.WriteLine("车辆名称：{0} 颜色：{1} ", carInstance.Name, carInstance.Color);

		}
	}
}
