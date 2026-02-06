/*
вывести заголовок программы

создаем генератор случайных чисел
создаем массив слов (предметы)

выбираем случайное слово из массива (функция)
выводим слово 

создаем маску слова (функция)
выводим маску

не конец игры
пока не конец игры
    запрашиваем у пользователя букву
    считываем букву
    сверяем букву с маской (функция)
    выводим маску

    конец игры (заглушка)

выйти из программы
---
строка < получить маску слова (слово)
    создаем пустую строку для маски
    для каждого символа в слове
        добавляем в маску символ '_'
    вернуть маску

строка < обновить маску (слово, маска, буква)
    создаем массив символов из маски
    для каждого символа в слове
        если символ совпадает с буквой
            заменяем соответствующий символ в маске на букву
    возвращаем обновленную маску
*/

WriteTitle("Угадай слово!");

Random rnd = new Random();

string[] words = { "стол", "книга", "окно", "лампа" };
string secretWord = ChooseWord(words);
// временно, для контроля разработки
Console.WriteLine($"[DEBUG] Загаданное слово: {secretWord}");

string maskedWord = CreateMask(secretWord);
Console.WriteLine(maskedWord);

bool gameOver = false;
int counter = 0;

while(!gameOver)
{
    Console.Write("Введи букву: ");
    char letter = Console.ReadLine()[0];

    maskedWord = UpdateMask(secretWord, maskedWord, letter);
    Console.WriteLine(maskedWord);

    // временно завершаем цикл
    if (counter++ == secretWord.Length)
        gameOver = true;
}

ExitApp();

string ChooseWord(string[] words)
{
    int index = rnd.Next(words.Length);
    return words[index];
}

string CreateMask(string word)
{
    string mask = string.Empty;

    for(int i = 0; i < word.Length; i++)
        mask += "_";

    return mask;
}

string UpdateMask(string word, string mask, char letter)
{
    char[] result = mask.ToCharArray();

    for(int i = 0; i < word.Length; i++)
    {
        if(word[i] == letter)
            result[i] = letter;
    }

    return new string(result);
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
