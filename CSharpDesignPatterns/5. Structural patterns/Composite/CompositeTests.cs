namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using NUnit.Framework;

    [TestFixture]
    public class CompositeTests
    {
        private readonly IComposite leaf1 = new Leaf("L1");
        private readonly IComposite leaf2 = new Leaf("L2");
        private readonly IComposite leaf3 = new Leaf("L3");
        private readonly IComposite leaf4 = new Leaf("L4");

        [Test]
        public void Leaf_ProperlyDisplaysItsName()
        {
            var composite = new Leaf("Leaf");

            Assert.AreEqual("Leaf", composite.Print());
        }

        [Ignore("1")]
        [Test]
        public void CompositeWith3ChildrenProperlyPrints()
        {
            var composite = new Composite();
            composite.Add(this.leaf1);
            composite.Add(this.leaf2);
            composite.Add(this.leaf1);

            Assert.AreEqual("[L1,L2,L1]", composite.Print());
        }

        [Ignore("2")]
        [Test]
        public void ParentWith2SubCompositesProperlyPrints()
        {
            var parent = new Composite();

            var composite1 = new Composite();
            composite1.Add(this.leaf1);

            var composite2 = new Composite();
            composite2.Add(this.leaf2);

            parent.Add(composite1);
            parent.Add(composite2);

            Assert.AreEqual("[[L1],[L2]]", parent.Print());
        }

        [Ignore("3")]
        [Test]
        public void TreeStructureWithOneBranchOnlyProperlyPrints()
        {
            var l4 = new Composite();
            l4.Add(this.leaf4);

            var l3 = new Composite();
            l3.Add(this.leaf3);
            l3.Add(l4);

            var l2 = new Composite();
            l2.Add(this.leaf2);
            l2.Add(l3);

            var root = new Composite();
            root.Add(this.leaf1);
            root.Add(l2);

            Assert.AreEqual("[L1,[L2,[L3,[L4]]]]", root.Print());
        }

        [Ignore("4")]
        [Test]
        public void ComplexExampleProperlyPrints()
        {
            var l4 = new Composite();
            l4.Add(this.leaf4);

            var l3 = new Composite();
            l3.Add(this.leaf3);
            l3.Add(l4);

            var l2 = new Composite();
            l2.Add(this.leaf2);
            l2.Add(l3);
            l2.Add(this.leaf1);

            var root = new Composite();
            root.Add(new Leaf("Left"));
            root.Add(l2);
            root.Add(new Leaf("Right"));

            Assert.AreEqual("[Left,[L2,[L3,[L4]],L1],Right]", root.Print());
        }
    }
}