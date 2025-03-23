using Flyweight;

Console.Title = "FlyWeight";

var aBunchOfCharacters = "abba";

var CharFactory = new CharacterFactory();

var charObj = CharFactory.GetCharacter(aBunchOfCharacters[0]);
charObj?.Draw("Arial", 10);
charObj = CharFactory.GetCharacter(aBunchOfCharacters[1]);
charObj?.Draw("Comic Sans", 10);
charObj = CharFactory.GetCharacter(aBunchOfCharacters[2]);
charObj?.Draw("Trebuchet", 10);
charObj = CharFactory.GetCharacter(aBunchOfCharacters[3]);
charObj?.Draw("Times New Roman", 10);

var paragraph = CharFactory.CreateParagraph(new List<ICharacter> { charObj }, 1);
paragraph.Draw("Italics", 8);
