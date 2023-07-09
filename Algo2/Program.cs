// C# implementation of counting the
// inversion using merge sort

namespace ArrayInversionCount;

public class Test
{
    public static void Main()
    {
        int[] a = new int[] { -1, 6, 3, 4, 7, 4 };
        var nrOfInversions = MergeSort(a, a.Length);
    }

    private static int MergeSort(int[] arr, int array_size)
    {
        int[] temp = new int[array_size];
        return _mergeSort(arr, temp, 0, array_size - 1);
    }

    private static int _mergeSort(int[] arr, int[] temp, int left, int right)
    {
        int mid, inv_count = 0;
        if (right > left)
        {
            mid = (right + left) / 2;

            inv_count += _mergeSort(arr, temp, left, mid);
            inv_count += _mergeSort(arr, temp, mid + 1, right);

            inv_count += Merge(arr, temp, left, mid + 1, right);
        }
        return inv_count;
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