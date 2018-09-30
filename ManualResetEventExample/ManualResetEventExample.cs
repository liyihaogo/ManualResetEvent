using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/**
* Author:liyihaogo
* Time  :2018/9/30 11:06:14
* Desc  :ManualResetEvent使用示例
**/
namespace ManualResetEventExample
{
	/// <summary>
	/// 常用方法：Set()、ReSet()、WaitOne()
	///	Set() : 用于向 ManualResetEvent 发送信号，使其取消阻塞状态（唤醒进程）或者开始阻塞进程，这基于 ManualResetEvent 的初始状态。
	///	ReSet() : 将 ManualResetEvent 的状态重置至初始状态（即使用 Set() 方法之前的状态）。
	///	WaitOne() : 使 ManualResetEvent 进入阻塞状态，开始等待唤醒信号。如果有信号，则不会阻塞，直接通过。
	///	信号 : 当 new ManualResetEvent(bool arg) 时，arg参数就是信号状态，假如为false，则表示当前无信号，如果为true，则有信号
	/// </summary>
	public class ManualResetEventExample
	{
		public ManualResetEventExample()
		{
			ThreadTest test = new ThreadTest();
			while (true)
			{
				string str = Console.ReadLine();
				if (str.ToLower().Equals("stop"))
					test.Stop();

				if (str.ToLower().Equals("start"))
					test.Start();
			}
		}
	}

	public class ThreadTest
	{
		private ManualResetEvent m_manualEvent = null;
		public ThreadTest()
		{
			m_manualEvent = new ManualResetEvent(false);

			Thread thread = new Thread(Run);
			thread.IsBackground = true;
			thread.Start();
		}

		private void Run()
		{
			while (true)
			{
				m_manualEvent.WaitOne();
				Console.WriteLine("ManualResetEvent Invoke Once!");
				Thread.Sleep(1000);
			}
		}

		public void Start()
		{
			m_manualEvent.Set();
		}

		public void Stop()
		{
			m_manualEvent.Reset();
		}
	}
}
