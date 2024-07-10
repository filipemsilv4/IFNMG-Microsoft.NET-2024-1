using System;
using System.Collections.Generic;

// Interface que define o contrato para as estratégias de ordenação
public interface IOrdenacao
{
    void Sort(List<string> lista);
}

// Implementação da estratégia QuickSort
public class QuickSort : IOrdenacao
{
    public void Sort(List<string> lista)
    {
        QuickSortHelper(lista, 0, lista.Count - 1);
    }

    private void QuickSortHelper(List<string> lista, int esquerda, int direita)
    {
        if (esquerda < direita)
        {
            int pivotIndex = Particionar(lista, esquerda, direita);
            QuickSortHelper(lista, esquerda, pivotIndex - 1);
            QuickSortHelper(lista, pivotIndex + 1, direita);
        }
    }

    private int Particionar(List<string> lista, int esquerda, int direita)
    {
        string pivot = lista[direita];
        int i = esquerda - 1;

        for (int j = esquerda; j < direita; j++)
        {
            if (string.Compare(lista[j], pivot, StringComparison.Ordinal) <= 0)
            {
                i++;
                (lista[i], lista[j]) = (lista[j], lista[i]);
            }
        }

        (lista[i + 1], lista[direita]) = (lista[direita], lista[i + 1]);
        return i + 1;
    }
}

// Implementação da estratégia MergeSort
public class MergeSort : IOrdenacao
{
    public void Sort(List<string> lista)
    {
        if (lista.Count <= 1) return;

        List<string> left = new List<string>();
        List<string> right = new List<string>();

        int meio = lista.Count / 2;
        for (int i = 0; i < meio; i++)
            left.Add(lista[i]);
        for (int i = meio; i < lista.Count; i++)
            right.Add(lista[i]);

        Sort(left);
        Sort(right);
        Merge(lista, left, right);
    }

    private void Merge(List<string> lista, List<string> left, List<string> right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Count && j < right.Count)
        {
            if (string.Compare(left[i], right[j], StringComparison.Ordinal) <= 0)
            {
                lista[k++] = left[i++];
            }
            else
            {
                lista[k++] = right[j++];
            }
        }

        while (i < left.Count)
        {
            lista[k++] = left[i++];
        }

        while (j < right.Count)
        {
            lista[k++] = right[j++];
        }
    }
}

// Classe contexto que usa a estratégia de ordenação
public class ListaOrdenada
{
    private List<string> lista;
    private IOrdenacao estrategia;

    public ListaOrdenada()
    {
        lista = new List<string>();
    }

    public void Add(string nome)
    {
        lista.Add(nome);
    }

    public void SetEstrategia(IOrdenacao estrategia)
    {
        this.estrategia = estrategia;
    }

    public void Sort()
    {
        estrategia.Sort(lista);
        Console.WriteLine("Lista ordenada:");
        foreach (var nome in lista)
        {
            Console.WriteLine(nome);
        }
    }
}

// Programa principal para testar a funcionalidade
public class Program
{
    public static void Main()
    {
        ListaOrdenada estudantes = new ListaOrdenada();
        estudantes.Add("Jose");
        estudantes.Add("Ana");
        estudantes.Add("Paulo");
        estudantes.Add("Maria");
        estudantes.Add("Carlos");
        
        estudantes.SetEstrategia(new QuickSort());
        estudantes.Sort();

        estudantes.SetEstrategia(new MergeSort());
        estudantes.Sort();
    }
}