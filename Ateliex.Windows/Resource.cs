using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Ateliex
{
    public abstract class Resource
    {
        protected HttpClient httpClient;

        public Resource()
        {
            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:44362/");

            //httpClient.DefaultRequestHeaders.Add("Accept", "text/xhtml");
        }
    }

    public abstract class ResourceCollection<T> : Resource, ICollection<T> where T : Resource
    {
        private readonly Collection<T> collection;

        public ResourceCollection()
        {
            collection = new Collection<T>();
        }

        public int Count => collection.Count;

        public bool IsReadOnly => true;

        public void Add(T item)
        {
            collection.Add(item);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public bool Contains(T item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
