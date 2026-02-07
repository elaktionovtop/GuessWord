/*
вывести заголовок программы

создаем генератор случайных чисел
создаем массив слов (предметы)

повтор игры
    играть (функция)
    запросить повтор игры
пока повтор игры

выйти из программы

список картинок 
---
< играть()
    выбираем случайное слово из массива (функция)
    выводим слово 

    создаем маску слова (функция)
    выводим маску

    не конец игры
    счетчик ошибок = 0
    счетчик попыток = 0

    пока не конец игры
        запрашиваем у пользователя букву
        считываем букву
        сверяем букву с маской (функция)
        если буква не найдена
            увеличиваем счетчик ошибок
            выводим сообщение об ошибке
        выводим маску
        если маска = слово
            выводим сообщение о победе
            конец игры
        если счетчик попыток достиг количества рисунков
            выводим сообщение о поражении
            конец игры
---
строка < получить маску слова (слово)
    создаем пустую строку для маски
    для каждого символа в слове
        добавляем в маску символ '_'
    вернуть маску
---
bool < обновить маску (слово, ref маска, буква)
    создаем массив символов из маски
    возврат = false
    для каждого символа в слове
        если символ совпадает с буквой
            заменяем соответствующий символ в маске на букву
            возврат = true
    обновляем маску
    возврат
*/

WriteTitle("Угадай слово!");

string[] hangmanPictures =
{
@"
 +---+
 |   |
     |
     |
     |
     |
=========",

@"
 +---+
 |   |
 O   |
     |
     |
     |
=========",

@"
 +---+
 |   |
 O   |
 |   |
     |
     |
=========",

@"
 +---+
 |   |
 O   |
/|   |
     |
     |
=========",

@"
 +---+
 |   |
 O   |
/|\  |
     |
     |
=========",

@"
 +---+
 |   |
 O   |
/|\  |
/    |
     |
=========",

@"
 +---+
 |   |
 O   |
/|\  |
/ \  |
     |
========="
};

string[] words = { "стол", "книга", "окно", "лампа" };

Random rnd = new Random();

bool playAgain;
do
{
    PlayGame();
    Console.Write("Сыграть ещё раз? (д/н): ");
    playAgain = Console.ReadLine().ToLower() == "д";
}
while(playAgain);
ExitApp();

void PlayGame()
{
    string secretWord = ChooseWord(words);
    // временно, для контроля разработки
    Console.WriteLine($"[DEBUG] Загаданное слово: {secretWord}");

    string maskedWord = CreateMask(secretWord);

    bool gameOver = false;
    int attemptCounter = 0;
    int errorCounter = 0;

    Console.WriteLine(hangmanPictures[errorCounter]);
    Console.WriteLine(maskedWord);

    while(!gameOver)
    {
        Console.Write("Введи букву: ");
        string input = Console.ReadLine();
        if(string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Игра прервана.");
            break;
        }
        char letter = input[0];

        if(!UpdateMask(secretWord, ref maskedWord, letter))
        {
            Console.WriteLine($"Неправильно! Ошибок: {++errorCounter}");
            Console.WriteLine(hangmanPictures[errorCounter]);
            if(errorCounter == hangmanPictures.Length - 1)
            {
                Console.WriteLine("Больше попыток нет!");
                gameOver = true;
            }
        }
        else
        {
            Console.WriteLine(maskedWord);

            if(maskedWord == secretWord)
            {
                Console.WriteLine("Слово угадано!");
                gameOver = true;
            }
        }
    }
}

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

bool UpdateMask(string word, ref string mask, char letter)
{
    char[] newMask = mask.ToCharArray();
    bool result = false;

    for(int i = 0; i < word.Length; i++)
    {
        if(word[i] == letter)
        {
            newMask[i] = letter;
            result = true;
        }
    }

    mask = new string(newMask);
    return result;
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
