using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 建造者模式
{

	//抽象工厂和建造者模式的使用那就是见仁见智，更喜欢那个用那个？
	/*
	 *  建造者模式的核心：将一个复杂对象的算法、组件、组装方式分离，组件可以被复用，组装方式可以应对不同的变化，不同的算法可以得到不同的结果。
	 *  
	 *  将一个复杂的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
	 */

	public class Car /*车是一个复杂的对象，因为车有很多种构建方式，不同的品牌，不同的零件等*/
	{
		private String _carInfo = "";
		public Car(String carInfo)
		{
			_carInfo = carInfo;
		}
		public void Print()
		{
			Console.WriteLine(_carInfo);
		}
	}

	public abstract class Builder    //建造者，就用来组装车辆的类，一个建造者的抽象类
	{
		public abstract Car createCar();
	}

	public class AudiBuilder : Builder
	{

		public override Car createCar()
		{
			return new Car("奥迪车建造完成");
		}
	}

	public class BenzBuilder : Builder
	{
		public override Car createCar()
		{
			return new Car("奔驰车建造完成");
		}
	}

	public class Director
	{
		private Builder _builder = null;

		public Director(Builder builder)
		{
			_builder = builder;
		}

		public void Building()
		{
			_builder.createCar();
		}

	}

	public class DirectorEx
	{
		public DirectorEx()
		{
			//
		}

		public Car crateBuilder()
		{
			Builder builder = new AudiBuilder();
			return builder.createCar();
		}
		public Car crateBuilder(String paramenters)
		{
			return null;
		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			Builder builder = new AudiBuilder(); //如果通过配置或者参数来构建
			Director director = new Director(builder);
			director.Building();
			Car carInfo = builder.createCar();
			carInfo.Print();

			DirectorEx directorEx = new DirectorEx();
			Car carInfos = directorEx.crateBuilder();
			carInfos.Print();

		}
	}
}
