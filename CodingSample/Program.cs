using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingSample
{
    class Program
    {
        // static void Main(string[] args)
        // {
            // string[] values = { "bird@gmail.com", "c.a.t@gmail.com", "bi+rd.help@gmail.com", "dog@gmail.com", "b.i.r.d@gmail.com", "man@gmail.com", "frog@gmail.com", "cat+help@gmail.com", "unique@example.com", "uni.que@example.com", "unique+test@example.com", "unique@anotherexample.com" };
            // Console.WriteLine(solution(values));
        // }

        // static int solution(string[] L) 
        // {
        //     List<string> finalList = new List<string>();
        //     foreach (var item in L)
        //     {
        //         string local = item.Substring(0, item.IndexOf("@"));
        //         string domain = item.Substring(item.IndexOf("@"));

        //         local = local.Replace(".", "");
        //         if (local.Contains("+"))
        //         {
        //             local = local.Substring(0, local.IndexOf("+"));
        //         }
        //         finalList.Add(local + domain);
        //     }

        //     Dictionary<string, int> result = calculateOccurrences(finalList);
        //     return result.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;
        // }

        // static Dictionary<string, int> calculateOccurrences(List<string> list) {
        //     Dictionary<string, int> finalDictionary = new Dictionary<string, int>();
        //     for (int i = 0; i < list.Count; i++)
        //     {
        //         string item = list[i];
        //         if (finalDictionary.ContainsKey(item))
        //         {
        //             finalDictionary[item]+= 1;
        //         }
        //         else {
        //             finalDictionary.Add(item, 1);
        //         }
        //         Console.WriteLine(item + ": " + finalDictionary[item]);
        //     }
        //     return finalDictionary;
        // }

        static void Main(string[] args)
        {
            int[] values = { 5, 3, 4, 2, 3, 4, 5, 4 };
            // int[] values = {3, 6, 1, 9};
            Console.WriteLine(solution(values));
        }

        static int solution(int[] coupons) {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            Dictionary<int, int> flipped = new Dictionary<int, int>();

            for (int i = 0; i < coupons.Length; i++)
            {
                int key = coupons[i];
                if (counter.ContainsKey(key)) {
                    int distance = i + 1 - counter[key];
                    if (flipped.ContainsKey(key)) {
                        flipped[key] = distance < flipped[key] ? distance : flipped[key];
                    }
                    else {
                        flipped.Add(key, distance);
                    }
                    counter[key] = i;
                }
                else {
                    counter.Add(key, i);
                }
            }

            return flipped.Aggregate((l, r) => l.Value < r.Value ? l : r).Value;

            // Slow solution with n^2 complexity
            // Dictionary <int, int> result = new Dictionary<int, int>();
            // for (int i = 0; i < (coupons.Length - 1); i++)
            // {
            //     int key = coupons[i];
            //     for (int j = i + 1; j < coupons.Length; j++)
            //     {
            //         if (key == coupons[j])
            //         {
            //             int distance = j + 1 - i;
            //             if (result.ContainsKey(key)) {
            //                 result[key] = distance < result[key] ? distance : result[key];
            //             }
            //             else
            //             {
            //                 result.Add(key, distance);
            //             }
            //         }
            //     }
            // }
            // return result.Count == 0 ? -1 : result.Aggregate((l, r) => l.Value < r.Value ? l : r).Value;
        }
    }
}
