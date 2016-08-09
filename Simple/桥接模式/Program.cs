using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 桥接模式
{
	/*
	 * 将抽象部分与实现部分分离，使他们都可以独立变化；
	 * 例如：当时在SS中看见的日志模块，日志可以根据配置不同分别以Console、Text、DB存储等方式打印
	 * 接口与实现相对分离；
	 * 
	 **/



	public abstract class HouseKeep
	{
		protected Work work;

		public HouseKeep(Work work)
		{
			this.work = work;
		}

		public virtual void manage()
		{
			this.work.work();
		}
	}

	public class HouseKeeperA : HouseKeep
	{

		public HouseKeeperA(Work work)
			: base(work)
		{

		}
		public override void manage()
		{
			Console.WriteLine("管家A指派");
			base.manage();

		}
	}

	public class HouseKeeperB : HouseKeep
	{

		public HouseKeeperB(Work work)
			: base(work)
		{

		}

		public override void manage()
		{
			Console.WriteLine("管家B指派");
			base.manage();
		}
	}

	public interface Work
	{
		void work();
	}

	public class woker1 : Work
	{
		public void work()
		{
			Console.WriteLine("工人1工作");
		}
	}

	public class worker2 : Work
	{
		public void work()
		{
			Console.WriteLine("工人2工作");
		}

	}

	// "抽象者"
	class Abstraction
	{

		// Fields
		protected Implementor implementor;
		// Properties
		public Implementor Implementor
		{
			set { implementor = value; }
		}
		// Methods
		virtual public void Operation()
		{
			implementor.Operation();
		}
	}

	// "RefinedAbstraction"
	class RefinedAbstraction : Abstraction
	{
		// Methods
		override public void Operation()
		{
			implementor.Operation();
		}
	}
	// "实现者"
	abstract class Implementor
	{
		abstract public void Operation();
	}

	// "ConcreteImplementorA"
	class ConcreteImplementorA : Implementor
	{
		// Methods
		override public void Operation()
		{
			Console.WriteLine("ConcreteImplementorA Operation");
		}
	}
	// "ConcreteImplementorB"
	class ConcreteImplementorB : Implementor
	{
		// Methods
		override public void Operation()
		{
			Console.WriteLine("ConcreteImplementorB Operation");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//你让管家A指挥工人1
			HouseKeep keep = new HouseKeeperA(new woker1());
			keep.manage();

			//你让管家A指挥工人2
			keep = new HouseKeeperA(new worker2());
			keep.manage();

			//你让管家B指挥工人1
			keep = new HouseKeeperB(new woker1());
			keep.manage();

			//你让管家B指挥工人2
			keep = new HouseKeeperB(new worker2());
			keep.manage();

			Abstraction abstraction = new Abstraction();
			// Set implementation and call
			abstraction.Implementor = new ConcreteImplementorA();
			abstraction.Operation();
			// Change implemention and call
			abstraction.Implementor = new ConcreteImplementorB();
			abstraction.Operation();
		}
	}
}
