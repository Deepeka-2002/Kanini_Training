using Linq;

delegate bool EligiblityCheck(People person);
class Program
{
    public static void Main(string[] args)
    { 
        People[] people =
        {
            new People(){Name= "Deepeka", Age=17},
            new People(){Name= "Dany",  Age=24},
            new People(){Name= "janu", Age=19},
            new People(){Name= "Ram", Age=23},
            new People(){Name= "Ravi", Age=15}
        };
        
        /*
        People[] Voters= new People[people.Length];
        
        int i = 0;

        foreach(People person in people)
        {
            if(person.Age >= 18)
            {
                Voters[i] = person;
                Console.WriteLine(person.Name);
                i++;
            }
        }
        
        List<People> voters =  VoterCheck.where (people, delegate(People person)
        {
            
            return person.Age >= 18;
        });    
        foreach(People voter in voters)
        {
            Console.WriteLine(voter.Name);
        }*/

        People[] voters = people.Where( p => p.Age >= 18).ToArray();

        foreach(People voter in voters)
        {
            Console.WriteLine(voter.Name);   
        }
    }
}