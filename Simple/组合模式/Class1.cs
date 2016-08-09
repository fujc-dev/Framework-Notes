using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 组合模式
{
	/*
	 * （安全模式）组合模式格式，根据定义的意图：用户可以忽略单个对象和组合对象的区别，统一使用组合结构中的对象；
	 *  组合模式中的单个对象和组合对象具有一致性；
	 *  
	 * **/


	public abstract class View
	{

	}

	public class GroupView : View
	{
		private View[] mChildren;
		/**
		 * Adds a child view.
		 */
		public void addView(View child)
		{
			//...
		}

		public void removeView(View view)
		{
			//...
		}

		/**
		 * Returns the view at the specified position in the group.
		 */
		public View getChildAt(int index)
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

		//other methods

	}

	public class TextView : View
	{

	}

	public class LinerLayout : GroupView
	{

	}


}
