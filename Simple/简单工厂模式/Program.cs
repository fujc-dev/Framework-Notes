using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简单工厂模式
{

	/***
	 * 一个抽象产品类，可以派生多个具体产品类；
	 * 一个具体工厂类；
	 * 工厂只能创建一个具体产品。
	 */

	/// <summary>
	/// 汽车抽象类
	/// </summary>
	public interface ICar
	{
		void Print();
	}
	/// <summary>
	/// 奥迪车类
	/// </summary>
	internal class Audi : ICar
	{

		public void Print()
		{
			Console.WriteLine("This is Audi!");
		}
	}
	/// <summary>
	/// 奔驰车类
	/// </summary>
	internal class Benz : ICar
	{

		public void Print()
		{
			Console.WriteLine("This is Benz!");
		}
	}
	/// <summary>
	/// 汽车工厂类
	/// </summary>
	internal class CarFactory
	{

		public ICar createInstace(String configName)
		{
			ICar instance = null;

			switch (configName)
			{
				case "audi": instance = new Audi(); break;
				case "benz": instance = new Benz(); break;
			}
			return instance;
		}
	}
	/// <summary>
	/// 程序入口
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			CarFactory carFactory = new CarFactory();
			ICar carInstance = carFactory.createInstace("audi");
			carInstance.Print();

		}
	}
}
