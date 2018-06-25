using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
	public class Program
	{
		static void Main(string[] args)
		{
			SweepstakesQueueManager queueManager = new SweepstakesQueueManager();
			SweepstakesStackManager stackManager = new SweepstakesStackManager();

			Sweepstakes sweepstakes = new Sweepstakes("Noah's Ark Giveaway");
			CreateDefaultContestants(sweepstakes);

			queueManager.InsertSweepstakes(sweepstakes);
			stackManager.InsertSweepstakes(sweepstakes);

			sweepstakes = new Sweepstakes("Crazy Bob's Fireworks Giveaway");
			CreateDefaultContestants(sweepstakes);

			queueManager.InsertSweepstakes(sweepstakes);
			stackManager.InsertSweepstakes(sweepstakes);

			sweepstakes = new Sweepstakes("Library Donation Giveaway");
			CreateDefaultContestants(sweepstakes);

			queueManager.InsertSweepstakes(sweepstakes);
			stackManager.InsertSweepstakes(sweepstakes);

			for(int i = 0; i < 3; i++)
			{
				Console.WriteLine($"Running contest number {i+1}:");
				Console.WriteLine("Queue Manager:");
				RunSweepstakes(queueManager);
				Console.WriteLine("Stack Manager:");
				RunSweepstakes(stackManager);
				Console.WriteLine();
			}

			Console.ReadLine();

		}

		private static void RunSweepstakes(ISweepstakesManager sweepstakesManager)
		{
			Sweepstakes sweepstakes = sweepstakesManager.GetSweepstakes();
			Console.WriteLine($"Running {sweepstakes.name}. And the winner is...");

			string winner = sweepstakes.PickWinner();
			Console.WriteLine(winner);
		}

		private static void CreateDefaultContestants(Sweepstakes sweepstakes)
		{
			Contestant contestant = sweepstakes.CreateContestant("Joe", "Schmo", "jschmo@gmail.com");
			sweepstakes.RegisterContestant(contestant);
			contestant = sweepstakes.CreateContestant("John", "Doe", "jdoe@gmail.com");
			sweepstakes.RegisterContestant(contestant);
			contestant = sweepstakes.CreateContestant("Jane", "Doe", "jadoe@gmail.com");
			sweepstakes.RegisterContestant(contestant);
			contestant = sweepstakes.CreateContestant("Jax", "Taylor", "jaxy@gmail.com");
			sweepstakes.RegisterContestant(contestant);
		}
	}
}