// C# implementation of counting the
// inversion using merge sort

namespace ArrayInversionCount;

public class Test
{
    public static void Main()
    {
        var a = new int[] { -1, 6, 3, 4, 7, 4 };
        var nrOfInversions = MergeSort(a, a.Length);
        Console.WriteLine(nrOfInversions);
    }

    private static int MergeSort(IList<int> arr, int arraySize)
    {
        var temp = new int[arraySize];
        return MergeSort(arr, temp, 0, arraySize - 1);
    }

    private static int MergeSort(IList<int> arr, IList<int> temp, int left, int right)
    {
        var invCount = 0;
        if (right <= left) return invCount;
        var mid = (right + left) / 2;

        invCount += MergeSort(arr, temp, left, mid);
        invCount += MergeSort(arr, temp, mid + 1, right);

        invCount += Merge(arr, temp, left, mid + 1, right);
        return invCount;
    }

    private static int Merge(IList<int> arr, IList<int> temp, int left, int mid, int right)
    {
        var invCount = 0;

        var i = left;
        var j = mid;
        var k = left;

        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];
                invCount += (mid - i);
            }
        }


        while (i <= mid - 1)
        {
            temp[k++] = arr[i++];
        }

        while (j <= right)
        {
            temp[k++] = arr[j++];
        }

        for (i = left; i <= right; i++)
        {
            arr[i] = temp[i];
        }

        return invCount;
    }


}