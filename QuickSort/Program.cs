public class QuicksortAlgo
{

    public static void Main()
    {
        var a = new int[] { 10, 80, 30, 90, 40, 50, 70};
        Quicksort(a, 0, a.Length - 1);
    }

    public static void Quicksort(int[] a, int low, int high)
    {
        int partitionIndex;
        if (low < high)
        {
            partitionIndex = Partition(a, low, high);

            Quicksort(a, low, partitionIndex - 1);
            Quicksort(a, partitionIndex + 1, high);
        }
    }

    public static int Partition(int[] a, int low, int high)
    {
        int pivot = a[high];
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (a[j] < pivot)
            {
                i++;
                Swap(ref a[i], ref a[j]);
            }
        }

        Swap(ref a[i + 1], ref a[high]);

        return i + 1;
    }

    public static void Swap(ref int a, ref int b)
    {
        int aux;
        aux = a;
        a = b;
        b = aux;
    }

}