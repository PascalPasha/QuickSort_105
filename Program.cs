using System;

namespace QuickSort
{
    /// <summary>
    /// main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// array untuk bilangan bulat yang diperuntukkan menyimpan nilai
        /// </summary>
        private int[] arr = new int[20];

        /// <summary>
        /// jumlah elemen dalam arraynya
        /// </summary>
        private int n;

        /// <summary>
        /// menampilkan data array
        /// </summary>
        void read()
        {
            while(true)
            {
                Console.Write("Enter the number of elements in the array : ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have max 20 elements.\n");
            }

            Console.WriteLine("\n--------------------");
            Console.WriteLine(" Enter array elements ");
            Console.WriteLine("----------------------");


            //mendapatkan elemen arraynya
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }

        /// <summary>
        /// pertukaran elemen pada indeks x dengan elemen pada indeks y
        /// </summary>
        /// <param name="x">Indeks pertama yang akan ditukar</param>
        /// <param name="y">Indeks kedua yang akan ditukar</param>
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        /// <summary>
        /// penyortiran data menggunakan quick sort
        /// </summary>
        /// <param name="low">indeks low</param>
        /// <param name="high">indeks high</param>
        public void q_sort(int low, int high)
        {
            int pivot, i, j;

            if (low > high)
                return;

            //partisi menjadi dua bagian: yaitu satu yang mengandung elemen kurang dari atau sama dengan pivot dan elemen lain yang mengandung lebih besar dari pivot

            i = low + 1;
            j = high;

            pivot = arr[low];


            while (i <= j)
            {
                /// <remarks>
                /// mencari elemen yang lebih besar dari pivot
                /// </remarks>
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                }


                /// <remarks>
                /// mencari elemen yang kurang dari atau sama dengan pivot
                /// </remarks>
                while ((arr[j] > pivot) && (j >= low))
                {
                    j--;
                }

                /// <remarks>
                /// syarat jika elemen berada di sebelah kiri elemen yang lebih kecil
                /// </remarks>
                /// <return>
                /// menukar elemen i dengan elemen j
                /// </return>
                if (i < j) 
                {
                    swap(i, j);
                }
            }

            /// <remarks>
            /// syarat jika elemen lebih kecil dari elemen j
            /// </remarks>
            /// <return>
            /// memindahkan pivot ke posisi yang benar dalam daftar
            /// </return>
            if (low < j)
            {
                swap(low, j);
            }

            /// <remarks>
            /// mengurutkan daftar di sebelah kiri pivot menggunakan sortir cepat
            /// </remarks>
            q_sort(low, j - 1);

            /// <remarks>
            /// mengurutkan daftar di sebelah kanan pivot menggunakan sortir cepat
            /// </remarks>
            q_sort(j + 1, high);
        }

        /// <summary>
        /// menampilkan hasil sorting data
        /// </summary>
        void display()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine(" Sorted array elements ");
            Console.WriteLine("-----------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
        }

        int getSize()
        {
            return (n);
        }

        /// <summary>
        /// main method yang akan mencari class dari program
        /// </summary>
        /// <param name="args">Parameter tersebut menerima argumen dari tipe string</param>
        static void Main(string[] args)
        {

            Program myList = new Program();
            myList.read();
            myList.q_sort(0, myList.getSize() - 1);
            myList.display();
            Console.WriteLine("\n\nPress Enter to Exit.");
            Console.Read();
        }
    }
}
