namespace CSharpDesignPatterns._5._Structural_patterns.Composite
{
    using NUnit.Framework;

    [TestFixture]
    public class CompositeTests
    {
        private readonly IComposite leaf1 = new CompositeLeaf("L1");
        private readonly IComposite leaf2 = new CompositeLeaf("L2");
        private readonly IComposite leaf3 = new CompositeLeaf("L3");
        private readonly IComposite leaf4 = new CompositeLeaf("L4");

        [Test]
        public void ComplexExampleProperlyPrints()
        {
            var l4 = new CompositeNode();
            l4.Add(this.leaf4);

            var l3 = new CompositeNode();
            l3.Add(this.leaf3);
            l3.Add(l4);

            var l2 = new CompositeNode();
            l2.Add(this.leaf2);
            l2.Add(l3);
            l2.Add(this.leaf1);

            var root = new CompositeNode();
            root.Add(new CompositeLeaf("Left"));
            root.Add(l2);
            root.Add(new CompositeLeaf("Right"));

            Assert.AreEqual("[Left,[L2,[L3,[L4]],L1],Right]", root.Print());
        }

        [Test]
        public void CompositeWith3ChildrenProperlyPrints()
        {
            var composite = new CompositeNode();
            composite.Add(this.leaf1);
            composite.Add(this.leaf2);
            composite.Add(this.leaf1);

            Assert.AreEqual("[L1,L2,L1]", composite.Print());
        }

        [Test]
        public void Leaf_ProperlyDisplaysItsName()
        {
            var composite = new CompositeLeaf("CompositeLeaf");

            Assert.AreEqual("CompositeLeaf", composite.Print());
        }

        [Test]
        public void ParentWith2SubCompositesProperlyPrints()
        {
            var parent = new CompositeNode();

            var composite1 = new CompositeNode();
            composite1.Add(this.leaf1);

            var composite2 = new CompositeNode();
            composite2.Add(this.leaf2);

            parent.Add(composite1);
            parent.Add(composite2);

            Assert.AreEqual("[[L1],[L2]]", parent.Print());
        }

        [Test]
        public void TreeStructureWithOneBranchOnlyProperlyPrints()
        {
            var l4 = new CompositeNode();
            l4.Add(this.leaf4);

            var l3 = new CompositeNode();
            l3.Add(this.leaf3);
            l3.Add(l4);

            var l2 = new CompositeNode();
            l2.Add(this.leaf2);
            l2.Add(l3);

            var root = new CompositeNode();
            root.Add(this.leaf1);
            root.Add(l2);

            Assert.AreEqual("[L1,[L2,[L3,[L4]]]]", root.Print());
        }
    }
}