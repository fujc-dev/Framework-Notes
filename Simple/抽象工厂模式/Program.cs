using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 抽象工厂模式
{
	/* 抽象工厂
	 * 多个抽象产品类，每一个抽象产品类可以派生出多个具体的产品
	 * 一个抽象工厂类，可以派生出多个具体的工厂类
	 * 每一个具体的工厂类，可以创建多个具体的产品
	 */


	// 汽车包含：引擎，车身，轮子...
	// demo：构建一个汽车

	/****************抽象产品部分*****************/
	/// <summary>
	/// 
	/// </summary>
	internal interface IEngine
	{
		void Install();
	}
	/// <summary>
	/// 
	/// </summary>
	internal interface IBody
	{
		void Install();
	}
	/// <summary>
	/// 
	/// </summary>
	internal interface IWheel
	{
		void Install();
	}
	/****************抽象产品部分*****************/

	/****************具体产品部分*****************/

	internal class AudiEngine : IEngine
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}
	internal class BenzEngine : IEngine
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}

	internal class AudiBody : IBody
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}
	internal class BenzBody : IBody
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}

	internal class AudiWheel : IWheel
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}
	internal class BenzWheel : IWheel
	{
		public void Install()
		{
			throw new NotImplementedException();
		}
	}

	/****************具体产品部分*****************/


	/****************抽象工厂部分*****************/
	internal interface ICarFactory
	{
		IEngine getEngine();
		IBody getBody();
		IWheel getWheel();

	}

	internal class AudiFactory : ICarFactory
	{
		public IEngine getEngine()
		{
			throw new NotImplementedException();
		}

		public IBody getBody()
		{
			throw new NotImplementedException();
		}

		public IWheel getWheel()
		{
			throw new NotImplementedException();
		}
	}
	internal class BenzFactory : ICarFactory
	{
		public IEngine getEngine()
		{
			throw new NotImplementedException();
		}

		public IBody getBody()
		{
			throw new NotImplementedException();
		}

		public IWheel getWheel()
		{
			throw new NotImplementedException();
		}
	}
	/****************抽象工厂部分*****************/

	/// <summary>
	/// 程序入口
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			ICarFactory audiFactory = new AudiFactory();
			ICarFactory benzFactoty = new BenzFactory();

			IEngine engine = audiFactory.getEngine();
			IBody body = audiFactory.getBody();
			IWheel wheel = audiFactory.getWheel();
			engine.Install();
			body.Install();
			wheel.Install();
		}
	}
}
