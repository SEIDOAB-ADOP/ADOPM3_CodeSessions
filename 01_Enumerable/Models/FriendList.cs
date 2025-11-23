using System.Collections;
using Seido.Utilities.SeedGenerator;

namespace _01_Enumerable.Models;

public class FriendList: IEnumerable<Friend>
{
    private  List<Friend> MyFriends {get; }= new List<Friend>(); 

    public int Count => MyFriends.Count;
    public Friend this[int idx] => MyFriends[idx];

    public override string ToString()
    {
        string sRet = "";
        foreach (var item in MyFriends)
        {
            sRet += item.ToString() + "\n";
        }
        return sRet;
    }

    public IEnumerator<Friend> GetEnumerator()
    {
        foreach (var item in MyFriends)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public FriendList(int nrOfFriends)
    {
        var rnd = new SeedGenerator();
        for (int i = 0; i < nrOfFriends; i++)
        {
            MyFriends.Add(new Friend().Seed(rnd));
        }
    }
}
