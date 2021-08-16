using System.Collections.Generic;

namespace JokeMachine
{
    public class DAL
    {
        public List<Joke> dadJokesDanish = new List<Joke>()
        {
            new Joke(){Setup = "Mine sko har lige forladt mig",Punchline = "– De følte sig bundet", Id = 0},
            new Joke(){Setup = "Hvad kalder man en postmands numse?",Punchline = "– Det en post-nummer", Id = 1},
            new Joke(){Setup = "Hvor gammel kan en elg blive?",Punchline = "– Ældgammel!", Id = 3},
            new Joke(){Setup = "Hvordan får man en fisk til at svømme ekstra hurtigt?",Punchline = "– Man tuner den", Id = 4},
            new Joke(){Setup = "Hvad hedder Draculas fætter, som i øvrigt er vegetar?",Punchline = "– Rucola", Id = 5},
            new Joke(){Setup = "Hvad laver tømreren når han langt om længe får fri fra arbejde?",Punchline = "– Lige vatterpass’er ham", Id = 6},
            new Joke(){Setup = "Hvordan bliver man ekspert i tordenvejr?",Punchline = "– Man tager et lynkursus", Id = 7},
            new Joke(){Setup = "Må jeg gerne spise yoghurt i sofaen?",Punchline = "– Far: “Nej put det i en skål?”", Id = 8},
            new Joke(){Setup = "Hvad gør man hvis AGF binder superligaen?",Punchline = "– Slukker for sin Playstation og vender tilbage til det virkelige liv!", Id = 9},
            new Joke(){Setup = "Hvad er det mindst talte sprog i verden? ",Punchline = "– Tegnsprog", Id = 10},
            new Joke(){Setup = "Hvad sagde den ene cykel til den anden?",Punchline = "– Styr dig!", Id = 11},
            new Joke(){Setup = "Hvad fik den lille kannibaldreng, som kom for sent til aftensmaden",Punchline = "– En kold skulder", Id = 12},
            new Joke(){Setup = "Hvad tager flyvermaskine på når den fryser",Punchline = "– Flyverdragt", Id = 13},
            new Joke(){Setup = "Hvilken slags slik kan bilister ikke lide?",Punchline = "– Lak-riser", Id = 14},
            new Joke(){Setup = "Hvad kalder man en fuld frø?",Punchline = "– en sprit tusse", Id = 15},
            new Joke(){Setup = "Hvordan siger man “spion-perler” på engelsk?",Punchline = "– Spy-perls (spegepølse)", Id = 16},
            new Joke(){Setup = "Min datter skreg “Faar hører du overhovedet efter?!!!?!”",Punchline = "– Det en mærkelig måde, at starte en samtale på...", Id = 17},
            new Joke(){Setup = "Hvorfor er katte så grimme?",Punchline = "– Det er fordi de misfarvede", Id = 18},
            new Joke(){Setup = "Mine sko har lige forladt mig",Punchline = "– De følte sig bundet", Id = 19},
            new Joke(){Setup = "Hvad kalder man en postmands numse?",Punchline = "– Det en post-nummer", Id = 20},
            new Joke(){Setup = "Hvor gammel kan en elg blive?",Punchline = "– Ældgammel!", Id = 21},
            new Joke(){Setup = "Hvordan får man en fisk til at svømme ekstra hurtigt?",Punchline = "– Man tuner den", Id = 22 },
            new Joke(){Setup = "Hvad hedder Draculas fætter, som i øvrigt er vegetar?",Punchline = "– Rucola", Id = 23},
            new Joke(){Setup = "Hvad laver tømreren når han langt om længe får fri fra arbejde?",Punchline = "– Lige vatterpass’er ham", Id = 24},
            new Joke(){Setup = "Hvordan bliver man ekspert i tordenvejr?",Punchline = "– Man tager et lynkursus", Id = 25},
            new Joke(){Setup = "Må jeg gerne spise yoghurt i sofaen?",Punchline = "– Far: “Nej put det i en skål?”", Id = 26},
            new Joke(){Setup = "Hvad gør man hvis AGF binder superligaen?",Punchline = "– Slukker for sin Playstation og vender tilbage til det virkelige liv!", Id = 27},
        };

        public List<Joke> dadJokesEnglish = new List<Joke>()
        {
            new Joke(){Setup = "Imagine if you walked into a bar and there was a long line of people waiting to take a swing at you.",Punchline = "– That's the punch line.", Id = 28},
            new Joke(){Setup = "How does a man on the moon cut his hair?",Punchline = "– Eclipse it.", Id = 29},
            new Joke(){Setup = "Air used to be free at the gas station, now it's $1.50. You know why?",Punchline = "– Inflation.", Id = 30},
            new Joke(){Setup = "Why is it a bad idea to iron your four-leaf clover?",Punchline = "– Cause you shouldn't press your luck.", Id = 31},
            new Joke(){Setup = "What rock group has four men that don't sing?",Punchline = "– Mount Rushmore.", Id = 32},
            new Joke(){Setup = "When I was a kid, my mother told me I could be anyone I wanted to be.",Punchline = "– Turns out, identity theft is a crime.", Id = 33},
            new Joke(){Setup = "What do sprinters eat before a race?",Punchline = "– Nothing, they fast!", Id = 34},
            new Joke(){Setup = "What do you call a mac 'n' cheese that gets all up in your face?",Punchline = "– Too close for comfort food!”", Id = 35},
            new Joke(){Setup = "Did you hear about the restaurant on the moon?",Punchline = "– Great food, no atmosphere!", Id = 36}
        };

        public List<Joke> darkJokesDanish = new List<Joke>()
        {
            new Joke(){Setup = "Alle børnene undviger skuddene",Punchline = "– undtagen Finn han var blind", Id = 37},
            new Joke(){Setup = "Hvad står der bag i bedemandens bil?",Punchline = "– Bare overhal mig, jeg kommer og henter dig senere.", Id = 38},
        };

        public List<Joke> darkJokesEnglish = new List<Joke>()
        {
            new Joke(){Setup = "My wife told me she'll slam my head on the keyboard if I don't get off the computer. I'm not too worried, I think she's",Punchline = "– jokinlkjhfakljn m,.nbziyoao78yv87dfaoyuofaytdf", Id = 39},
            new Joke(){Setup = "I just got my doctor's test results and I'm really upset.",Punchline = "– Turns out, I'm not gonna be a doctor.", Id = 40},
            new Joke(){Setup = "As I get older, I remember all the people I lost along the way.",Punchline = "– Maybe a career as a tour guide was not the right choice.", Id = 41},
            new Joke(){Setup = "When my uncle Frank died, he wanted his remains to be buried in his favorite beer mug.",Punchline = "– His last wish was to be Frank in Stein.", Id = 42}
        };
    }
}
