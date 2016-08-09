using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 工厂方法模式
{

	/*
	 * 工厂方法
	 * 一个抽象的产品类，派生多个产品类
	 * 一个抽象工厂类，派生多个工厂类
	 * 一个具体的工厂只能创建一个具体的产品
	 */

	internal interface ICar
	{
		void Print();
	}

	internal class Audi : ICar
	{

		public void Print()
		{
			Console.WriteLine("这是一辆奥迪车.");
		}
	}

	internal class Benz : ICar
	{
		public void Print()
		{
			Console.WriteLine("这是一辆奔驰车.");
		}
	}

	internal abstract class CarFactory
	{
		public abstract ICar createInstace();
	}

	class AudiFactory : CarFactory
	{
		public override ICar createInstace()
		{
			return new Audi();
		}
	}

	class BenzFacoty : CarFactory
	{
		public override ICar createInstace()
		{
			return new Benz();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			CarFactory carFatory = new AudiFactory();
			ICar carInstance = carFatory.createInstace();
			carInstance.Print();

		}
	}
}
