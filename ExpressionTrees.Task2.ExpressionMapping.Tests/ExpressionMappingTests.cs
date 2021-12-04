using ExpressionTrees.Task2.ExpressionMapping.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTrees.Task2.ExpressionMapping.Tests
{
    [TestClass]
    public class ExpressionMappingTests
    {
        [TestMethod]
        public void Mapper_WhenPassingOnlySimilarProps_PropsSuccessfullyCopied()
        {
            var nameToCopy = "name";
            var AgeToCopy = 100;
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var res = mapper.Map(new Foo(){ Name = nameToCopy, Age = AgeToCopy});

            Assert.AreEqual(res.Name , nameToCopy);
            Assert.AreEqual(res.Age, AgeToCopy);
        }

        [TestMethod]
        public void Mapper_WhenPassingOnlyNonSimilarProps_NonSimilarPropsNotCopied()
        {
            var intVal = 100;
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var res = mapper.Map(new Foo() { UniqueIntForFoo = intVal });

            Assert.AreNotEqual(res.UniqueIntForBar, intVal);
        }


        [TestMethod]
        public void Mapper_WhenPassingMixedProps_NonSimilarPropsNotCopied()
        {
            var intVal = 100;
            var stringVal = "some value";
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var res = mapper.Map(new Foo() { UniqueIntForFoo = intVal, Age = intVal, Name = stringVal, UniqueStringForFoo = stringVal});

            Assert.AreEqual(res.Name, stringVal);
            Assert.AreEqual(res.Age, intVal);
            Assert.AreNotEqual(res.UniqueIntForBar, intVal);
        }

        [TestMethod]
        public void Mapper_WhenPassingPromSameNameDifferentType_NonSimilarPropsNotCopied()
        {
            var demoVal = "some value";
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var res = mapper.Map(new Foo() { SameNameDifferentType = demoVal});

            Assert.AreNotEqual(res.SameNameDifferentType, demoVal);
        }
    }
}
