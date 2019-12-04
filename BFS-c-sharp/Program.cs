using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private int ShortestDistanceBetweenUsers(UserNode user1, UserNode user2)
        {
            return 0;
        }

        private void ListFriendsOfFriendsAtDistance(UserNode user, int ditance)
        {
            List<UserNode> friendsOfFriends = new List<UserNode>();

            foreach(var friend in friendsOfFriends)
            {
                Console.WriteLine($"{friend.FirstName} {friend.LastName} [{friend.Id}]");
            }
        }

        // BONUS EXCERCISE
        //private void ShortestPaths(UserNode user1, UserNode user2)
        //{

        //}
    }
}
