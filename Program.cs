/*
вывести заголовок программы

создаем генератор случайных чисел
создаем массив слов (предметы)
выбираем случайное слово из массива
выводим слово

выйти из программы
*/

WriteTitle("Угадай слово!");

Random rnd = new Random();

string[] words = { "стол", "книга", "окно", "лампа" };
string secretWord = ChooseWord(words);

// временно, для контроля разработки
Console.WriteLine($"[DEBUG] Загаданное слово: {secretWord}");

ExitApp();

string ChooseWord(string[] words)
{
    int index = rnd.Next(words.Length);
    return words[index];
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
