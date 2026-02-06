/*
вывести заголовок программы

создаем генератор случайных чисел
создаем массив слов (предметы)

выбираем случайное слово из массива (функция)
выводим маску слова (функция)

выводим слово

выйти из программы

строка < получить маску слова (слово)
    создаем пустую строку для маски
    для каждого символа в слове
        добавляем в маску символ '_'
    вернуть маску
*/

WriteTitle("Угадай слово!");

Random rnd = new Random();

string[] words = { "стол", "книга", "окно", "лампа" };
string secretWord = ChooseWord(words);

string maskedWord = CreateMask(secretWord);
Console.WriteLine(maskedWord);

// временно, для контроля разработки
Console.WriteLine($"[DEBUG] Загаданное слово: {secretWord}");

ExitApp();

string ChooseWord(string[] words)
{
    int index = rnd.Next(words.Length);
    return words[index];
}

string CreateMask(string word)
{
    //string mask = "";
    string mask = string.Empty;

    for(int i = 0; i < word.Length; i++)
        mask += "_";

    return mask;
}

void WriteTitle(string title)
{
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
    Console.WriteLine();
}

void ExitApp()
{
    Console.WriteLine();
    Console.Write("Для выхода нажми Enter");
    Console.ReadLine();
}
