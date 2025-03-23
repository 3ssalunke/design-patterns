namespace Flyweight
{
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    public class CharacterA : ICharacter
    {
        private char _actualCharacter = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    public class CharacterB : ICharacter
    {
        private char _actualCharacter = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();
        public ICharacter? GetCharacter(char charIdentifier)
        {
            if (_characters.ContainsKey(charIdentifier))
            {
                Console.WriteLine("Character reuse");
                return _characters[charIdentifier];
            }

            Console.WriteLine("Character construction");
            switch (charIdentifier)
            {
                case 'a':
                    _characters[charIdentifier] = new CharacterA();
                    return _characters[charIdentifier];
                case 'b':
                    _characters[charIdentifier] = new CharacterB();
                    return _characters[charIdentifier];
                default:
                    return null;
            }
        }

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }

    public class Paragraph : ICharacter
    {
        private List<ICharacter> _characters = new();
        private int _location;
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public Paragraph(List<ICharacter> characters, int location)
        {
            _characters = characters;
            _location = location;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach (var item in _characters)
            {
                item.Draw(_fontFamily, _fontSize);
            }
        }
    }
}