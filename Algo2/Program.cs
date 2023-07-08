﻿// C# implementation of counting the
// inversion using merge sort
using System;
public class Test
{
    public static void Main()
    {
        int[] a = new int[] { -1, 6, 3, 4, 7, 4 };
        var nrOfInversions = mergeSort(a, a.Length);
    }

    static int mergeSort(int[] arr, int array_size)
    {
        int[] temp = new int[array_size];
        return _mergeSort(arr, temp, 0, array_size - 1);
    }

    static int _mergeSort(int[] arr, int[] temp, int left, int right)
    {
        int mid, inv_count = 0;
        if (right > left)
        {
            mid = (right + left) / 2;

            inv_count += _mergeSort(arr, temp, left, mid);
            inv_count += _mergeSort(arr, temp, mid + 1, right);

            inv_count += merge(arr, temp, left, mid + 1, right);
        }
        return inv_count;
    }

    static int merge(int[] arr, int[] temp, int left, int mid, int right)
    {
        int i, j, k;
        int inv_count = 0;

        i = left;
        j = mid;
        k = left;

        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];
                inv_count = inv_count + (mid - i);
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

        return inv_count;
    }


}