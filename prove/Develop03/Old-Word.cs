// class Word
// {
//     private string _text;
//     private bool _hidden = false;
//     public bool Hidden { get { return _hidden; } }

//     public Word(string text)
//     {
//         _text = text;
//     }

//     public void HideWord()
//     {
//         this._hidden = true;
//     }

//     public string GetWord()
//     {
//         if (!_hidden)
//         {
//             return _text;
//         }
//         else
//         {
//             return new String('_', _text.Length);
//         }
//     }

// }