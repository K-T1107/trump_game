using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trump_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cards = new List<int>();

            //カードの番号を4回入力させる
            for (int i = 0; i < 4; i++) 
            {
                //1どの入力で、範囲内の値が入力されるまで繰り返す
                while(true)
                {
                    //カード番号の入力
                    Console.Write($"{i + 1}番目のカードを入力してください(1 - 4) >");

                    //入力内容のチェック
                    if (!int.TryParse(Console.ReadLine(), out int input))
                    {
                        //範囲外の数値が入力されたら、エラー表示して再入力させる
                        Console.WriteLine("1～4の数値を入力してください");
                        continue;
                    }

                    cards.Add(input);
                    break;
                }
            }

            //出力されたカード一覧
            Console.WriteLine("あなたの手札: " + string.Join(", ", cards));

            // グループ化して枚数をカウント
            var grouped = cards.GroupBy(x => x).Select(g => g.Count()).OrderByDescending(c => c).ToList();

            // 役の判定
            if (grouped[0] == 4)
            {
                Console.WriteLine("役：フォーカード");
            }
            else if (grouped[0] == 3)
            {
                Console.WriteLine("役：スリーカード");
            }
            else if (grouped[0] == 2 && grouped.Count(c => c == 2) == 2)
            {
                Console.WriteLine("役：ツーペア");
            }
            else if (grouped[0] == 2)
            {
                Console.WriteLine("役：ワンペア");
            }
            else
            {
                Console.WriteLine("役：ノーペア");
            }

            // 終了待ち
            Console.WriteLine("Enterキーを押して終了してください");
            Console.ReadLine();
        }
    }
}
