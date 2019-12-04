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

            int distance = ShortestDistanceBetweenUsers(users[0], users[11]);
            Console.WriteLine(distance);
            Console.WriteLine("Friend of Friends:");
            ListFriendsOfFriendsAtDistance(users[0], 1);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static int ShortestDistanceBetweenUsers(UserNode user1, UserNode user2)
        {
            if (user1.Equals(user2))
            {
                return 0;
            }

            Queue<UserNode> toVisit = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Dictionary<UserNode, int> distanceFromRoot = new Dictionary<UserNode, int>();


            toVisit.Enqueue(user1);
            visited.Add(user1);
            distanceFromRoot.Add(user1, 0);

            while (toVisit.Count > 0)
            {
                UserNode user = toVisit.Dequeue();
                int currentDistance;
                distanceFromRoot.TryGetValue(user, out currentDistance);
                if (user.Friends.Contains(user2))
                {
                    return currentDistance + 1;
                }
                foreach(var friend in user.Friends)
                {
                    if (!visited.Contains(friend))
                    {
                        toVisit.Enqueue(friend);
                        visited.Add(friend);
                        distanceFromRoot.Add(friend, currentDistance + 1);
                    }
                }
            }

            throw new ArgumentOutOfRangeException("User not found among friends!");
        }

        private static void ListFriendsOfFriendsAtDistance(UserNode user, int distance)
        {
            Queue<UserNode> toVisit = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Dictionary<UserNode, int> distanceFromRoot = new Dictionary<UserNode, int>();

            HashSet<UserNode> friendOfFriends = new HashSet<UserNode>();


            toVisit.Enqueue(user);
            visited.Add(user);
            distanceFromRoot.Add(user, 0);

            while (toVisit.Count > 0)
            {
                UserNode CurrentUser = toVisit.Dequeue();
                int currentDistance;
                distanceFromRoot.TryGetValue(CurrentUser, out currentDistance);

                if(currentDistance > distance) { break; }
                
                foreach (var friend in CurrentUser.Friends)
                {
                    if (!visited.Contains(friend))
                    {
                        toVisit.Enqueue(friend);
                        visited.Add(friend);
                        friendOfFriends.Add(friend);
                        distanceFromRoot.Add(friend, currentDistance + 1);
                    }
                }
            }

            foreach (var friend in friendOfFriends)
            {
                Console.WriteLine(friend.ToString());
            }
        }

        // BONUS EXCERCISE
        //private static void ShortestPaths(UserNode user1, UserNode user2)
        //{

        //}

    }
}
