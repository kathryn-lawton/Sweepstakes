using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
	public class Sweepstakes
	{
		Dictionary<int, Contestant> contestants = new Dictionary<int, Contestant>();
		public string name;
		Random random;
		int contestantCount;

		public Sweepstakes(string name)
		{
			this.name = name;
			this.random = new Random();
			contestantCount = 0;
		}

		public Contestant CreateContestant(string firstName, string lastName, string emailAddress)
		{
			
			contestantCount++;
			Contestant contestant = new Contestant(firstName, lastName, emailAddress, contestantCount);
			return contestant;

		}

		public void RegisterContestant(Contestant contestant)
		{ 
			contestants.Add(contestant.registrationNumber, contestant);
		}

		public string PickWinner()
		{
			int winningNumber = random.Next(1, contestantCount);
			Contestant contestant;
			contestants.TryGetValue(winningNumber, out contestant);
			return $"{contestant.firstName} {contestant.lastName}";
		}

		public void PrintContestantInfo(Contestant contestant)
		{
			foreach (KeyValuePair<int, Contestant> pair in contestants)
			{
				Console.WriteLine(pair.Key + " - " + pair.Value);
			}
		}
	}
}
