﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Zen.Utilities
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class DataList<T> : IEnumerable<T> where T : IIdentifiedById
    {
        protected readonly List<T> Items;

        protected DataList()
        {
            Items = new List<T>();
        }

        private DataList(List<T> items)
        {
            Items = new List<T>();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public static DataList<T> Create()
        {
            return new DataList<T>();
        }

        public static DataList<T> Create(List<T> items)
        {
            return new DataList<T>(items);
        }

        public static DataList<T> Create(IEnumerable<T> items)
        {
            return new DataList<T>(items.ToList());
        }

        public static DataList<T> CreateFromJson(string json)
        {
            var deserialized = JsonSerializer.Deserialize<List<T>>(json);
            var list = Create(deserialized);

            return list;
        }

        public int Count => Items.Count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Items.Count)
                {
                    throw new IndexOutOfRangeException($"Index out of range. Item with index [{index}] not found.");
                }

                return Items[index];
            }
        }

        // CRUD
        public void Add(T item)
        {
            Items.Add(item);
        }

        public T GetById(int id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            throw new Exception($"Id [{id}] not found.");
        }

        public void Update(T item)
        {
            var index = FindIndexOfId(item.Id);
            Items[index] = item;
        }

        public void Remove(int id)
        {
            var index = FindIndexOfId(id);

            Items.RemoveAt(index);
        }

        public string Serialize(bool prettyPrint = false)
        {
            var options = new JsonSerializerOptions {WriteIndented = prettyPrint};
            var serialized = JsonSerializer.Serialize(Items, options);

            return serialized;
        }

        private int FindIndexOfId(int id)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                if (item.Id == id)
                {
                    return i;
                }
            }

            throw new Exception($"Id [{id}] not found.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay => $"{{{typeof(T).Name} List: Count={Items.Count}}}";
    }
}