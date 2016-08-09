using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式
{

	/**
	 * 将一个接口转换成一个新的接口
	 */

	public interface ITarget
	{
		void Request();
	}

	public class Target : ITarget
	{
		public void Request()
		{
			Console.WriteLine("原始接口请求结果");
		}
	}

	public interface IAdapter : ITarget
	{
	}

	public class MyAdapter : IAdapter
	{
		ITarget mTarget = null;

		public MyAdapter(ITarget target)
		{
			mTarget = target;
		}

		public void Request()
		{
			if (mTarget != null)
			{
				mTarget.Request();
				Console.WriteLine("新的适配器请求结果");
			}
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			ITarget target = new Target();
			IAdapter adapter = new MyAdapter(target);
			adapter.Request();
		}
	}
}
