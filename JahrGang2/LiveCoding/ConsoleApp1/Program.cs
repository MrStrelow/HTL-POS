Console.OutputEncoding = System.Text.Encoding.UTF8;

void Tausche<T>(T[] a, T[] b)
{
    T temp = a[0];
    a[0] = b[0];
    b[0] = temp;
}

//int x = 1, y = 2;
//Tausche<int>(x, y);
string[] s1 = { "🐶" };
string[] s2 = {"🐱"};
Tausche<string>(s1, s2);

//Console.WriteLine($"x:{x} - y:{y}");
Console.WriteLine($"x:{s1[0]} - y:{s2[0]}");