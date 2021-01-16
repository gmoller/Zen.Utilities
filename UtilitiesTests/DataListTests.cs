using System;
using NUnit.Framework;
using Zen.Utilities;

namespace Zen.UtilitiesTests
{
    public class DataListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DataList_can_be_created()
        {
            var list = DataList<Foo>.Create();
            list.Add(new Foo(1, "One"));
            list.Add(new Foo(2, "Two"));
            list.Add(new Foo(3, "Three"));

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual(3, list[2].Id);

            list.Remove(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual(3, list[1].Id);

            var o = list.GetById(3);
            Assert.AreEqual(3, o.Id);

            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.Id}");
            }

            Console.WriteLine(list.ToString());
        }

        [Test]
        public void DataList_can_be_created_from_another_list()
        {
            var list1 = DataList<Foo>.Create();
            list1.Add(new Foo(1, "One"));
            list1.Add(new Foo(2, "Two"));
            list1.Add(new Foo(3, "Three"));

            var list2 = DataList<Foo>.Create(list1);

            Assert.AreEqual(3, list2.Count);
            Assert.AreEqual(1, list2[0].Id);
            Assert.AreEqual(2, list2[1].Id);
            Assert.AreEqual(3, list2[2].Id);

            list2.Remove(2);

            Assert.AreEqual(3, list1.Count);
            Assert.AreEqual(1, list1[0].Id);
            Assert.AreEqual(2, list1[1].Id);
            Assert.AreEqual(3, list1[2].Id);
            Assert.AreEqual(2, list2.Count);
            Assert.AreEqual(1, list2[0].Id);
            Assert.AreEqual(3, list2[1].Id);

            foreach (var item in list1)
            {
                Console.WriteLine($"ID: {item.Id}");
            }
            foreach (var item in list2)
            {
                Console.WriteLine($"ID: {item.Id}");
            }
        }

        [Test]
        public void Item_in_DataList_can_be_updated()
        {
            var list = DataList<Foo>.Create();
            list.Add(new Foo(1, "One"));
            var item1 = list.GetById(1);
            var updatedItem = new Foo(item1.Id, "Cripes");

            list.Update(updatedItem);
            var item2 = list.GetById(1);

            Assert.AreEqual("One", item1.Name);
            Assert.AreEqual("Cripes", item2.Name);
        }

        [Test]
        public void Serialize_Deserialize()
        {
            var list1 = DataList<Foo>.Create();
            list1.Add(new Foo(1, "One"));
            list1.Add(new Foo(2, "Two"));
            list1.Add(new Foo(3, "Three"));

            var json = list1.Serialize();
            var list2 = DataList<Foo>.CreateFromJson(json);

            Assert.AreEqual(3, list1.Count);
            Assert.AreEqual(1, list1[0].Id);
            Assert.AreEqual(2, list1[1].Id);
            Assert.AreEqual(3, list1[2].Id);

            Assert.AreEqual(3, list2.Count);
            Assert.AreEqual(1, list2[0].Id);
            Assert.AreEqual(2, list2[1].Id);
            Assert.AreEqual(3, list2[2].Id);
        }

        private struct Foo : IIdentifiedById
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Foo(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
    }
}