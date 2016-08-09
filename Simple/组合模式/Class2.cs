using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 组合模式.Ex
{

	/*
	 * (透明模式) 组合模式：用户可以忽略单个对和组合对象的区别，统一使用组合结构中的对象，组合模式中的单个对象和组合对象具有一致性；
	 * **/

	abstract class Component
	{

		public abstract void Add(Component component);

		public abstract void Remove(Component component);

		public abstract Component getChildAt(int index);
	}

	class Composite : Component
	{

		private List<Component> mChildren = new List<Component>();

		public override void Add(Component component)
		{
			throw new NotImplementedException();
		}

		public override void Remove(Component component)
		{
			throw new NotImplementedException();
		}

		public override Component getChildAt(int index)
		{
			try
			{
				return mChildren[index];
			}
			catch (Exception ex) //IndexOutOfBoundsException Java中边界异常
			{
				return null;
			}
		}
	}

	class Leaf : Component
	{

		public override void Add(Component component)
		{
			throw new NotImplementedException();
		}

		public override void Remove(Component component)
		{
			throw new NotImplementedException();
		}

		public override Component getChildAt(int index)
		{
			throw new NotImplementedException();
		}

	}
}
