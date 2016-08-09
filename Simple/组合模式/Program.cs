using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 组合模式
{

	/*
	 * 组合模式又叫分部与整体模式
	 * **/


	public abstract class Component
	{
		public abstract void add(Component component);

		public abstract void remove(Component component);

		public abstract Component getChild(int i);

		public abstract void operation();
	}

	public class Leaf : Component
	{
		public override void operation()
		{
			//base.operation();
		}


		public override void add(Component component)
		{
			throw new NotImplementedException();
		}

		public override void remove(Component component)
		{
			throw new NotImplementedException();
		}

		public override Component getChild(int i)
		{
			throw new NotImplementedException();
		}
	}

	public class Composite : Component
	{
		IList<Component> components = new List<Component>();

		public override void add(Component component)
		{
			components.Add(component);
		}


		public override void remove(Component component)
		{
			components.Remove(component);
		}


		public override Component getChild(int i)
		{
			return components[i];
		}


		public override void operation()
		{
			foreach (Component component in components)
			{
				component.operation();

			}

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
