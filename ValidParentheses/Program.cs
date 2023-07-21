var sol = new Solution();
Console.WriteLine(sol.IsValid("(]"));

public class Solution
{
    public Solution() {
        parenthesisMap.Add('(', ')');
        parenthesisMap.Add(')', '(');
        parenthesisMap.Add('{', '}');
        parenthesisMap.Add('}', '{');
        parenthesisMap.Add('[', ']');
        parenthesisMap.Add(']', '[');
    }

    Dictionary<char, char> parenthesisMap = new Dictionary<char, char>();
    Stack<char> parenthesis = new Stack<char>();

    public bool IsValid(string s)
    {
        foreach (var character in s)
        {
            if(IsOpening(character))
            {
                parenthesis.Push(character);
            }
            else
            {
                if(!parenthesis.TryPop(out char poppedParenthesis))
                {
                    return false;
                }
                else
                {
                    bool bracketsAreAPair = CharactersMatch(character, poppedParenthesis);
                    if(!bracketsAreAPair)
                    {
                        return false;
                    }

                    bool bracketsCorrectlyPair = IsOpening(character) ^ IsOpening(poppedParenthesis);
                    if(!bracketsCorrectlyPair)
                    {
                        return false;
                    }
                }
            }

        }

        if(parenthesis.Count > 0)
        {
            return false;
        }

        return true;
    }

    private bool IsOpening(char character)
    {
        if ("({[".Contains(character)) return true;
        return false;
    }

    private bool CharactersMatch(char characterOne, char characterTwo)
    {
        return parenthesisMap[characterOne] == characterTwo;
    }
}