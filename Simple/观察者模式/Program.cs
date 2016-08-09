using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式
{
	/*
	 * 功能描述：定义对象的一种一对多的依赖关系，当一个对象的状态发送变化时，多有依赖于它的对象都得到通知或者更新；一个简化的互联网气象站项目
	 */

	public interface IObserver //观察者接口
	{
		void Update(float temperature, float humidity, float pressure);
	}

	public interface ISubject //抽象所有主题，所有主题都维护观察者对象，
	{
		void RegisterObserver(params IObserver[] oBservers);
		void RemoveObserver(IObserver o);
		void NotifyObserver();
	}

	public class ConcreteSubject : ISubject
	{

		List<IObserver> memberList = new List<IObserver>();


		public void RegisterObserver(params IObserver[] oBservers)
		{
			foreach (IObserver o in oBservers)
			{
				if(!memberList.Contains(o))
				memberList.Add(o);
			}
		}
		public void RemoveObserver(IObserver o)
		{
			memberList.Remove(o);
		}

		public void NotifyObserver()
		{
			memberList.ForEach(p => p.Update(0, 0, 0));
		}
	}

	public class ConreteObserver : IObserver
	{

		public ConreteObserver(String name)
		{
			this._mName = name;
		}

		private String _mName;

		public void Update(float temperature, float humidity, float pressure)
		{
			Console.WriteLine(this._mName + ",老师来了，别睡觉了");
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
	}

	class Program
	{
		static void Main(string[] args)
		{
			ISubject subject = new ConcreteSubject();
			IObserver zhangsan = new ConreteObserver("张三");
			IObserver lisi = new ConreteObserver("李四");
			IObserver wangwu = new ConreteObserver("王五");
			subject.RegisterObserver(new IObserver[] { zhangsan, lisi, wangwu });
			subject.RegisterObserver(lisi);
			subject.RegisterObserver(wangwu);
			subject.NotifyObserver();

		}
	}
}
